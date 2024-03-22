using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_f.Models;
using mvc_f.NovaPasta1;

namespace mvc_f.Controllers
{
    public class ClassUsersController : Controller
    {
        private readonly Contexto _context;

        public ClassUsersController(Contexto context)
        {
            _context = context;
        }

        // GET: ClassUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassUser.ToListAsync());
        }
        public async Task<IActionResult> pagina()
        {
            return View(await _context.ClassUser.ToListAsync());
        }

        // GET: ClassUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classUser = await _context.ClassUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classUser == null)
            {
                return NotFound();
            }

            return View(classUser);
        }

        // GET: ClassUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Loginusuario,Telefone,Endereco,SenhaConfirm")] ClassUser classUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(classUser);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var user = await _context.ClassUser.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (user != null)
            {
                // Login bem-sucedido, você pode armazenar as informações do usuário na sessão, cookie, etc.
                // Por simplicidade, vamos apenas redirecionar para a página inicial
                return RedirectToAction(nameof(pagina));
            }
            else
            {
                // Se o usuário não for encontrado ou as credenciais estiverem incorretas,
                // você pode retornar para a página de login com uma mensagem de erro
                ModelState.AddModelError(string.Empty, "Email ou senha incorretos");
                return View();
            }
        }


        // GET: ClassUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classUser = await _context.ClassUser.FindAsync(id);
            if (classUser == null)
            {
                return NotFound();
            }
            return View(classUser);
        }

        // POST: ClassUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Loginusuario,Telefone,Endereco,SenhaConfirm")] ClassUser classUser)
        {
            if (id != classUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassUserExists(classUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(pagina));
            }
            return View(classUser);
        }

        // GET: ClassUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classUser = await _context.ClassUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classUser == null)
            {
                return NotFound();
            }

            return View(classUser);
        }

        // POST: ClassUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classUser = await _context.ClassUser.FindAsync(id);
            if (classUser != null)
            {
                _context.ClassUser.Remove(classUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(pagina));
        }

        private bool ClassUserExists(int id)
        {
            return _context.ClassUser.Any(e => e.Id == id);
        }
    }
}
