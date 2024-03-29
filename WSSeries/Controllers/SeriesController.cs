﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSSeries.Models.EntityFramework;

namespace WSSeries.Controllers
{
    [Route("api/series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesDbContext _context;

        public SeriesController(SeriesDbContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
          if (_context.Series == null)
          {
              return NotFound();
          }
          return await _context.Series.ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
          if (_context.Series == null)
          {
              return NotFound();
          }
            var serie = await _context.Series.FindAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.Serieid)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
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

        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
          if (_context.Series == null)
          {
              return Problem("Entity set 'SeriesDbContext.Series'  is null.");
          }
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Serieid }, serie);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            if (_context.Series == null)
            {
                return NotFound();
            }
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieExists(int id)
        {
            return (_context.Series?.Any(e => e.Serieid == id)).GetValueOrDefault();
        }
    }
}
