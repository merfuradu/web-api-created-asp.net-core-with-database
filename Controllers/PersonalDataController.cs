using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebAPI_week1.DTOs;
using WebAPI_week1.Models;

namespace WebAPI_week1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly PersonsDB _context;
        private readonly IMapper _mapper;

        public PersonalDataController(PersonsDB context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetPersonalDatas")]
        public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalDatas()
        {
            var personalDataList = await _context.PersonalDatas.Include(pd => pd.Addresses).ToListAsync();
            var personalDataDtoList = _mapper.Map<List<PersonalData>>(personalDataList);
            return Ok(personalDataDtoList);
        }

        [HttpGet("GetPersonalDataById/{id}")]
        public async Task<ActionResult<PersonalData>> GetPersonalDataById(int id)
        {
            if (id < 0)
            {
                return NotFound("The ID is invalid, it shouldn t be negative");
            }

            var personalData = await _context.PersonalDatas.Include(p => p.Addresses).FirstOrDefaultAsync(p => p.Id == id);

            if (personalData == null)
            {
                return NotFound("The specified ID has no person attached to it.");
            }

            var personalDataDto = _mapper.Map<PersonalData>(personalData);

            return Ok(personalDataDto);
        }

        //[HttpGet("GetPersonalDataByName/{name}")]
        //public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalDataByName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return BadRequest("The name is null or empty");
        //    }

        //    var lowerCaseName = name.ToLower();

        //    var personalDataList = await _context.PersonalDatas
        //        .Include(pd => pd.Address) // Optionally include related addresses
        //        .Where(pd => pd.Name != null && pd.Name.ToLower().Contains(lowerCaseName))
        //        .ToListAsync();

        //    if (personalDataList == null || !personalDataList.Any())
        //    {
        //        return NotFound("No personal data found with the specified name.");
        //    }

        //    return Ok(personalDataList);

        //}

        [HttpPost("PostPersonalData")]
        public async Task<ActionResult<PersonalData>> PostPersonalData(PersonalDataDTO personalDataDto)
        {
            var personalData = _mapper.Map<PersonalData>(personalDataDto);

            if (string.IsNullOrEmpty(personalData.Name) || personalData.Name.Length < 2)
            {
                return BadRequest("The name should have at least 2 caracters");
            }
            if (string.IsNullOrEmpty(personalData.PhoneNumber) || personalData.PhoneNumber.Length < 10)
            {
                return BadRequest("The phone number lenght is too short to post, number not available.");
            }
            _context.PersonalDatas.Add(personalData);
            await _context.SaveChangesAsync();

            var createdDto = _mapper.Map<PersonalDataDTO>(personalData);
            return CreatedAtAction(nameof(GetPersonalDataById), new { id = personalData.Id }, createdDto);
        }

        [HttpPut("PutPersonalData/{id}")]
        public async Task<IActionResult> PutPersonalData(int id, PersonalDataDTO updatedPersonalDataDto)
        {
            if (id != updatedPersonalDataDto.Id)
            {
                return BadRequest();
            }

            var existingPersonalData = await _context.PersonalDatas
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPersonalData == null)
            {
                return NotFound();
            }

            if (updatedPersonalDataDto.Name.Length < 2)
            {
                return BadRequest("The name was to short to be updated");
            }

            if (updatedPersonalDataDto.PhoneNumber.Length < 10)
            {
                return BadRequest("The phone number length is too short, the number is unavailable");
            }
            existingPersonalData.Name = updatedPersonalDataDto.Name;
            existingPersonalData.PhoneNumber = updatedPersonalDataDto.PhoneNumber;

            if (updatedPersonalDataDto.Addresses != null && updatedPersonalDataDto.Addresses.Any()) 
            {
                _context.Addresses.RemoveRange(existingPersonalData.Addresses);

                foreach (var addressDto in updatedPersonalDataDto.Addresses)
                {
                    var address = _mapper.Map<Address>(addressDto);
                    existingPersonalData.Addresses.Add(address);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updatedPersonalDataDtoResponse = _mapper.Map<PersonalDataDTO>(existingPersonalData);
            return Ok(updatedPersonalDataDtoResponse);
        }

        [HttpDelete("DeletePersonalDataById/{id}")]
        public async Task<IActionResult> DeletePersonalDataById(int id)
        {
            var personalData = await _context.PersonalDatas
                .Include(p => p.Addresses).FirstOrDefaultAsync(pd => pd.Id == id);

            if (personalData == null)
            {
                return NotFound("There wasn't any person with the ID provided.");
            }

            if (personalData.Addresses != null && personalData.Addresses.Any())
            {
                _context.Addresses.RemoveRange(personalData.Addresses);
            }

            _context.PersonalDatas.Remove(personalData);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteAllPersonalData")]
        public async Task<IActionResult> DeleteAllPersonalData()
        {
            var allPersonalData = await _context.PersonalDatas
                .Include(p => p.Addresses)
                .ToListAsync();

            if (allPersonalData == null || !allPersonalData.Any())
            {
                return NotFound("There weren t any fields to delete");
            }

            foreach (var pd in allPersonalData)
            {
                if (pd.Addresses != null && pd.Addresses.Any())
                {
                    _context.Addresses.RemoveRange(pd.Addresses);
                }
            }

            _context.PersonalDatas.RemoveRange(allPersonalData);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        private bool PersonalDataExists(int id)
        {
            return _context.PersonalDatas.Any(e => e.Id == id);
        }
    }
}