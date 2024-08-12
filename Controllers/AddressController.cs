using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_week1.DTOs;
using WebAPI_week1.Models;

namespace WebAPI_week1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PersonsDB _context;

        public AddressController(PersonsDB context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAddresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var addresses = await _context.Addresses.ToListAsync();
            var addressesDto = _mapper.Map<List<Address>>(addresses);
            return Ok(addressesDto);
        }

        [HttpGet("GetAddressesById/{id}")]
        public async Task<ActionResult<Address>> GetAddressesById(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            var addressDto = _mapper.Map<Address>(address);

            if (addressDto == null) 
            {
                return NotFound();
            }

            return Ok(addressDto);
        }

        [HttpPost("PostAddress")]
        public async Task<ActionResult<Address>> PostAddress(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddressesById), new {id = address.Id}, _mapper.Map<AddressDTO>(address));
        }

        [HttpPut("PutAddress/{id}")]
        //[Route("api/addresses/update/{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressDTO addressDto)
        {
            if (id != addressDto.Id)
            {
                return BadRequest("The id s in the request are not the same");
            }

            var existingAddress = await _context.Addresses.FindAsync(id);
            if (existingAddress == null)
            {
                return NotFound();
            }

            _mapper.Map(addressDto, existingAddress);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (id < 0) { return BadRequest("Invalid ID"); }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound("Address not found.");
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeleteAllAddresses")]
        public async Task<IActionResult> DeleteAllAddresses()
        {
            var allAddresses = _context.Addresses.ToList();

            if (!allAddresses.Any() || allAddresses == null)
            {
                return NotFound("There weren t any addresses to be deleted in the first place");
            }

            _context.Addresses.RemoveRange(allAddresses);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(a => a.Id == id);
        }

    }
}
