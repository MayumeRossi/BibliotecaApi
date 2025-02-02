﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.BD;
using BibliotecaApi.Model;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadesController : ControllerBase
    {
        private readonly BANCO _context;

        public DisponibilidadesController(BANCO context)
        {
            _context = context;
        }

        // GET: api/Disponibilidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disponibilidade>>> GetDisponibilidades()
        {
            return await _context.Disponibilidades.ToListAsync();
        }

        // GET: api/Disponibilidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disponibilidade>> GetDisponibilidade(int id)
        {
            var disponibilidade = await _context.Disponibilidades.FindAsync(id);

            if (disponibilidade == null)
            {
                return NotFound();
            }

            return disponibilidade;
        }

        // PUT: api/Disponibilidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisponibilidade(int id, Disponibilidade disponibilidade)
        {
            if (id != disponibilidade.Id)
            {
                return BadRequest();
            }

            _context.Entry(disponibilidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadeExists(id))
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

        // POST: api/Disponibilidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Disponibilidade>> PostDisponibilidade(Disponibilidade disponibilidade)
        {
            _context.Disponibilidades.Add(disponibilidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisponibilidade", new { id = disponibilidade.Id }, disponibilidade);
        }

        // DELETE: api/Disponibilidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilidade(int id)
        {
            var disponibilidade = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidade == null)
            {
                return NotFound();
            }

            _context.Disponibilidades.Remove(disponibilidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisponibilidadeExists(int id)
        {
            return _context.Disponibilidades.Any(e => e.Id == id);
        }
    }
}
