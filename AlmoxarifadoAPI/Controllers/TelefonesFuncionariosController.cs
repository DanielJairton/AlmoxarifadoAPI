﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoAPI;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesFuncionariosController : ControllerBase
    {
        private readonly db_almoxarifadoContext _context;

        public TelefonesFuncionariosController(db_almoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/TelefonesFuncionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonesFuncionario>>> GetTelefonesFuncionarios()
        {
          if (_context.TelefonesFuncionarios == null)
          {
              return NotFound();
          }
            return await _context.TelefonesFuncionarios.ToListAsync();
        }

        // GET: api/TelefonesFuncionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelefonesFuncionario>> GetTelefonesFuncionario(int id)
        {
          if (_context.TelefonesFuncionarios == null)
          {
              return NotFound();
          }
            var telefonesFuncionario = await _context.TelefonesFuncionarios.FindAsync(id);

            if (telefonesFuncionario == null)
            {
                return NotFound();
            }

            return telefonesFuncionario;
        }

        // PUT: api/TelefonesFuncionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefonesFuncionario(int id, TelefonesFuncionario telefonesFuncionario)
        {
            if (id != telefonesFuncionario.IdTelefone)
            {
                return BadRequest();
            }

            _context.Entry(telefonesFuncionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonesFuncionarioExists(id))
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

        // POST: api/TelefonesFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TelefonesFuncionario>> PostTelefonesFuncionario(TelefonesFuncionario telefonesFuncionario)
        {
          if (_context.TelefonesFuncionarios == null)
          {
              return Problem("Entity set 'db_almoxarifadoContext.TelefonesFuncionarios'  is null.");
          }
            _context.TelefonesFuncionarios.Add(telefonesFuncionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefonesFuncionario", new { id = telefonesFuncionario.IdTelefone }, telefonesFuncionario);
        }

        // DELETE: api/TelefonesFuncionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefonesFuncionario(int id)
        {
            if (_context.TelefonesFuncionarios == null)
            {
                return NotFound();
            }
            var telefonesFuncionario = await _context.TelefonesFuncionarios.FindAsync(id);
            if (telefonesFuncionario == null)
            {
                return NotFound();
            }

            _context.TelefonesFuncionarios.Remove(telefonesFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonesFuncionarioExists(int id)
        {
            return (_context.TelefonesFuncionarios?.Any(e => e.IdTelefone == id)).GetValueOrDefault();
        }
    }
}
