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
    public class TelefonesFornecedoresController : ControllerBase
    {
        private readonly db_almoxarifadoContext _context;

        public TelefonesFornecedoresController(db_almoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/TelefonesFornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonesFornecedor>>> GetTelefonesFornecedors()
        {
          if (_context.TelefonesFornecedors == null)
          {
              return NotFound();
          }
            return await _context.TelefonesFornecedors.ToListAsync();
        }

        // GET: api/TelefonesFornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TelefonesFornecedor>> GetTelefonesFornecedor(int id)
        {
          if (_context.TelefonesFornecedors == null)
          {
              return NotFound();
          }
            var telefonesFornecedor = await _context.TelefonesFornecedors.FindAsync(id);

            if (telefonesFornecedor == null)
            {
                return NotFound();
            }

            return telefonesFornecedor;
        }

        // PUT: api/TelefonesFornecedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefonesFornecedor(int id, TelefonesFornecedor telefonesFornecedor)
        {
            if (id != telefonesFornecedor.IdTelefone)
            {
                return BadRequest();
            }

            _context.Entry(telefonesFornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonesFornecedorExists(id))
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

        // POST: api/TelefonesFornecedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TelefonesFornecedor>> PostTelefonesFornecedor(TelefonesFornecedor telefonesFornecedor)
        {
          if (_context.TelefonesFornecedors == null)
          {
              return Problem("Entity set 'db_almoxarifadoContext.TelefonesFornecedors'  is null.");
          }
            _context.TelefonesFornecedors.Add(telefonesFornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefonesFornecedor", new { id = telefonesFornecedor.IdTelefone }, telefonesFornecedor);
        }

        // DELETE: api/TelefonesFornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefonesFornecedor(int id)
        {
            if (_context.TelefonesFornecedors == null)
            {
                return NotFound();
            }
            var telefonesFornecedor = await _context.TelefonesFornecedors.FindAsync(id);
            if (telefonesFornecedor == null)
            {
                return NotFound();
            }

            _context.TelefonesFornecedors.Remove(telefonesFornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonesFornecedorExists(int id)
        {
            return (_context.TelefonesFornecedors?.Any(e => e.IdTelefone == id)).GetValueOrDefault();
        }
    }
}
