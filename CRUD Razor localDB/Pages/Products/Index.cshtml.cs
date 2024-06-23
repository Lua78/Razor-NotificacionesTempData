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
    public class IndexModel : PageModel
    {
        private readonly CRUD_Razor_localDB.Data.ApplicationDBContext _context;

        public IndexModel(CRUD_Razor_localDB.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
