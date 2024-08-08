using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_week1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly TodoDb _context;

        public AddressController(TodoDb context)
        {
            _context = context;
        }

        [HttpGet("getaddresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        [HttpGet("getAddressesById/{id}")]
        public async Task<ActionResult<Address>> GetAddressesById(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null) 
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost("PostAddress")]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddressesById), new {id = address.Id}, address);
        }

        [HttpPut("PutAddress/{id}")]
        //[Route("api/addresses/update/{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            var existingAddress = await _context.Addresses.FindAsync(id);
            if (existingAddress == null)
            {
                return NotFound();
            }

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.PostalCode = address.PostalCode;

            //_context.Update(existingAddress);

            //_context.Entry(existingAddress).State = EntityState.Modified;

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
            if (id < 0) { return BadRequest(); }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(a => a.Id == id);
        }

    }
}
