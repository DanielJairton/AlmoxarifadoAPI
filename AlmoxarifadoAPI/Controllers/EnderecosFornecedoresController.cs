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
    public class EnderecosFornecedoresController : ControllerBase
    {
        private readonly db_almoxarifadoContext _context;

        public EnderecosFornecedoresController(db_almoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/EnderecosFornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecosFornecedor>>> GetEnderecosFornecedors()
        {
          if (_context.EnderecosFornecedors == null)
          {
              return NotFound();
          }
            return await _context.EnderecosFornecedors.ToListAsync();
        }

        // GET: api/EnderecosFornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecosFornecedor>> GetEnderecosFornecedor(int id)
        {
          if (_context.EnderecosFornecedors == null)
          {
              return NotFound();
          }
            var enderecosFornecedor = await _context.EnderecosFornecedors.FindAsync(id);

            if (enderecosFornecedor == null)
            {
                return NotFound();
            }

            return enderecosFornecedor;
        }

        // PUT: api/EnderecosFornecedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecosFornecedor(int id, EnderecosFornecedor enderecosFornecedor)
        {
            if (id != enderecosFornecedor.IdEndereco)
            {
                return BadRequest();
            }

            _context.Entry(enderecosFornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecosFornecedorExists(id))
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

        // POST: api/EnderecosFornecedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnderecosFornecedor>> PostEnderecosFornecedor(EnderecosFornecedor enderecosFornecedor)
        {
          if (_context.EnderecosFornecedors == null)
          {
              return Problem("Entity set 'db_almoxarifadoContext.EnderecosFornecedors'  is null.");
          }
            _context.EnderecosFornecedors.Add(enderecosFornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecosFornecedor", new { id = enderecosFornecedor.IdEndereco }, enderecosFornecedor);
        }

        // DELETE: api/EnderecosFornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecosFornecedor(int id)
        {
            if (_context.EnderecosFornecedors == null)
            {
                return NotFound();
            }
            var enderecosFornecedor = await _context.EnderecosFornecedors.FindAsync(id);
            if (enderecosFornecedor == null)
            {
                return NotFound();
            }

            _context.EnderecosFornecedors.Remove(enderecosFornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecosFornecedorExists(int id)
        {
            return (_context.EnderecosFornecedors?.Any(e => e.IdEndereco == id)).GetValueOrDefault();
        }
    }
}
