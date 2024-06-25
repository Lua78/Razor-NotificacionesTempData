using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Razor_localDB.Data;
using CRUD_Razor_localDB.Model;

namespace CRUD_Razor_localDB.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly CRUD_Razor_localDB.Data.ApplicationDBContext _context;

        public EditModel(CRUD_Razor_localDB.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [TempData]
        public string Mensaje { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Mensaje = "Product edited successfully";
            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.id == id);
        }
    }
}
