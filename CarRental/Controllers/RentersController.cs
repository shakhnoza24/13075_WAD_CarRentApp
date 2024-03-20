using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;
using CarRental.Repositories;

namespace CarRental.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentersController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        private readonly IRentersRepository _rentersRepository;

        public RentersController(IRentersRepository rentersRepository)
        {
            _rentersRepository = rentersRepository;
        }

        // GET: api/Renters
        [HttpGet]
        public async Task<IEnumerable<Renter>> GetRenters()
        {
            return await _rentersRepository.GetAllRenters();
        }

        // GET: api/Renters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Renter>> GetRenter(int id)
        {
            var renter = await _rentersRepository.GetSingleRenter(id);

            if (renter == null)
            {
                return NotFound();
            }

            return Ok(renter);
        }

        // PUT: api/Renters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenter(int id, Renter renter)
        {
            if (id != renter.Id)
            {
                return BadRequest();
            }


            await _rentersRepository.UpdateRenter(renter);
            return NoContent();
        }

        // POST: api/Renters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Renter>> PostRenter(Renter renter)
        {
            _rentersRepository.CreateRenter(renter);

            return CreatedAtAction("GetRenter", new { id = renter.Id }, renter);
        }

        // DELETE: api/Renters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenter(int id)
        {
            _rentersRepository.DeleteRenter(id);

            return NoContent();
        }
    }
}
