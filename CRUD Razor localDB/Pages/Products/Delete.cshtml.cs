using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Razor_localDB.Data;
using CRUD_Razor_localDB.Model;

namespace CRUD_Razor_localDB.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public DeleteModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.id == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                Product = product;
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
            Mensaje = "Product deleted successfully";
            return RedirectToPage("./Index");
        }
    }
}
