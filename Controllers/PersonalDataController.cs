using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI_week1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly TodoDb _context;

        public PersonalDataController(TodoDb context)
        {
            _context = context;
        }

        [HttpGet("GetPersonalDatas")]
        public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalDatas()
        {
            return await _context.PersonalDatas.Include(p => p.Address).ToListAsync();
        }

        [HttpGet("GetPersonalDataById/{id}")]
        public async Task<ActionResult<PersonalData>> GetPersonalDataById(int id)
        {
            if (id < 0)
            {
                return NotFound("The ID is invalid, it shouldn t be negative"); 
            }
            
            var personalData = await _context.PersonalDatas.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);

            if (personalData == null)
            {
                return NotFound("The specified ID has no person attached to it.");
            }

            return personalData;
        }

        [HttpGet("GetPersonalDataByName/{name}")]
        public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalDataByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("The name is null or empty");
            }

            var lowerCaseName = name.ToLower();

            var personalDataList = await _context.PersonalDatas
                .Include(pd => pd.Address) // Optionally include related addresses
                .Where(pd => pd.Name != null && pd.Name.ToLower().Contains(lowerCaseName))
                .ToListAsync();

            if (personalDataList == null || !personalDataList.Any())
            {
                return NotFound("No personal data found with the specified name.");
            }

            return Ok(personalDataList);

        }

        [HttpPost("PostPersonalData")]
        public async Task<ActionResult<PersonalData>> PostPersonalData(PersonalData personalData)
        {
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

            return CreatedAtAction(nameof(GetPersonalDataById), new { id = personalData.Id }, personalData);
        }

        [HttpPut("PutPersonalData/{id}")]
        public async Task<IActionResult> PutPersonalData(int id, PersonalData personalData)
        {
            if (id != personalData.Id)
            {
                return BadRequest();
            }

            var existingPersonalData = await _context.PersonalDatas
        .Include(p => p.Address)
        .FirstOrDefaultAsync(p => p.Id == id);
            if (existingPersonalData == null)
            {
                return NotFound();
            }

            if (personalData.Name.Length > 2)
            {
                existingPersonalData.Name = personalData.Name;
            } 
            else { return BadRequest("The name written is too short to be updated"); }

            if (personalData.PhoneNumber.Length < 10)
            {
                return BadRequest("The phone number length is too short, the number is unavailable");
            }
            existingPersonalData.PhoneNumber = personalData.PhoneNumber;

            if (existingPersonalData == null)
            {
                Address adresa = new Address();
                adresa.Street = personalData.Address.Street;
                adresa.City = personalData.Address.City;
                adresa.State = personalData.Address.State;
                adresa.PostalCode = personalData.Address.PostalCode;

            }
            else
            {
                existingPersonalData.Address.Street = personalData.Address.Street;
                existingPersonalData.Address.City = personalData.Address.City;
                existingPersonalData.Address.State = personalData.Address.State;
                existingPersonalData.Address.PostalCode = personalData.Address.PostalCode; 
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("DeletePersonalDataById/{id}")]
        public async Task<IActionResult> DeletePersonalDataById(int id)
        {
            var personalData = await _context.PersonalDatas.FindAsync(id);
            if (personalData == null)
            {
                return NotFound("There wasn't any person with the ID provided.");
            }

            var addressId = await _context.Addresses.FindAsync(personalData.AddressId);
            _context.PersonalDatas.Remove(personalData);

            if (addressId != null)
            {
                _context.Addresses.Remove(addressId);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoExists(int id)
        {
            return _context.PersonalDatas.Any(e => e.Id == id);
        }
    }
}
