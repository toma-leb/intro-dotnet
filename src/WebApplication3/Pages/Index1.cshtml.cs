using DataProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Person pers;

        public EditModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string? id)
        {
        }
        public void update(Person per, IPersonRepository persRepo)
        {
            persRepo.Update(per.PersonId, per.FirstName, per.LastName, per.Age);
        }
    }
}
