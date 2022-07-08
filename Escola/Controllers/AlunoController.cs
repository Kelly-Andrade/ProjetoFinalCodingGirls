using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola.Contexts;
using Escola.Models;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            List<Aluno> AlunosCadastrados = _context.Aluno.ToList();
            List<Turma> TurmasCadastradas = _context.Turma.ToList();

            if (_context.Aluno == null)
            {
                return NotFound();
            }

            List<Aluno> AlunosAtivos = new List<Aluno>();

            foreach (Aluno AlunoCadastrado in AlunosCadastrados)
            {
                Turma? TurmaAluno = TurmasCadastradas.Find(x => x.Id == AlunoCadastrado.Turma_Id);

                if (TurmaAluno.Ativo == true)
                {
                    AlunosAtivos.Add(AlunoCadastrado);
                }
            }

            return AlunosAtivos;
            /*await_context.Aluno.ToListAsync();*/
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            List<Turma> TurmasCadastradas = _context.Turma.ToList();

            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            Turma? TurmaAluno = TurmasCadastradas.Find(x => x.Id == aluno.Turma_Id);

            if (TurmaAluno.Ativo == true)
            {
                return aluno;
            }

            return NotFound();
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            List<Turma> TurmasCadastradas = _context.Turma.ToList();

            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            Turma? TurmaAluno = TurmasCadastradas.Find(x => x.Id == aluno.Turma_Id);

            if (TurmaAluno.Ativo == false)
            {
                return BadRequest();
            }

            else
            {

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            if (_context.Aluno == null)
            {
                return Problem("Entity set 'EscolaContext.Aluno'  is null.");
            }
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
