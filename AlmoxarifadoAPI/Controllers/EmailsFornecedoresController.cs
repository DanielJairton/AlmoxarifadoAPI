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
    public class EmailsFornecedoresController : ControllerBase
    {
        private readonly db_almoxarifadoContext _context;

        public EmailsFornecedoresController(db_almoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/EmailsFornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailsFornecedor>>> GetEmailsFornecedors()
        {
          if (_context.EmailsFornecedors == null)
          {
              return NotFound();
          }
            return await _context.EmailsFornecedors.ToListAsync();
        }

        // GET: api/EmailsFornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailsFornecedor>> GetEmailsFornecedor(int id)
        {
          if (_context.EmailsFornecedors == null)
          {
              return NotFound();
          }
            var emailsFornecedor = await _context.EmailsFornecedors.FindAsync(id);

            if (emailsFornecedor == null)
            {
                return NotFound();
            }

            return emailsFornecedor;
        }

        // PUT: api/EmailsFornecedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailsFornecedor(int id, EmailsFornecedor emailsFornecedor)
        {
            if (id != emailsFornecedor.IdEmail)
            {
                return BadRequest();
            }

            _context.Entry(emailsFornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailsFornecedorExists(id))
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

        // POST: api/EmailsFornecedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailsFornecedor>> PostEmailsFornecedor(EmailsFornecedor emailsFornecedor)
        {
          if (_context.EmailsFornecedors == null)
          {
              return Problem("Entity set 'db_almoxarifadoContext.EmailsFornecedors'  is null.");
          }
            _context.EmailsFornecedors.Add(emailsFornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailsFornecedor", new { id = emailsFornecedor.IdEmail }, emailsFornecedor);
        }

        // DELETE: api/EmailsFornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailsFornecedor(int id)
        {
            if (_context.EmailsFornecedors == null)
            {
                return NotFound();
            }
            var emailsFornecedor = await _context.EmailsFornecedors.FindAsync(id);
            if (emailsFornecedor == null)
            {
                return NotFound();
            }

            _context.EmailsFornecedors.Remove(emailsFornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailsFornecedorExists(int id)
        {
            return (_context.EmailsFornecedors?.Any(e => e.IdEmail == id)).GetValueOrDefault();
        }
    }
}
