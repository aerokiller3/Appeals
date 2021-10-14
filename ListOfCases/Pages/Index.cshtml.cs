using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListOfCases.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Departments> Department { get; set; }
        public void OnGet()
        {
            Countries = _ctx.Countries.OrderBy(x => x.Name);
            Department = Enum.GetValues(typeof(Departments)).Cast<Departments>();
        }
    }
}
