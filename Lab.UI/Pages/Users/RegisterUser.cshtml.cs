using Lab.Communication.Request.User;
using Lab.Domain.Entities;
using Lab.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHibernate;
using System.Text.Json;

namespace Lab.UI.Pages.Users
{
    public class RegisterUserModel : PageModel
    {
        private readonly IWriteOnlyRepository<ApplicationUser> _repository;

        public RegisterUserModel([FromKeyedServices("WUser")]IWriteOnlyRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public User UserData { get; set; } = new();

        private const string PAGE_TITLE = "Criar conta";

        public List<SelectListItem> AcademicFormationOptions { get; set; }
        
        public List<SelectListItem> AcademicStatusOptions { get; set; }

        public string AcademicFormationFields { get; set; }


        public IActionResult OnGet()
        {
            // Inicializa com os campos de formação acadêmica em branco
            UserData.AcademicFormations.Add(new AcademicFormation() { Course = "", Formation = 0, Institution = "", Status = 0 });

            return Page();
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            ViewData["Title"] = PAGE_TITLE;            

            // TODO: Criar enum
            AcademicFormationOptions = new List<SelectListItem> {
                new ("", "0"),
                new ("Técnico", "1"),
                new ("Bacharel", "2"),
                new ("Tecnólogo", "3"),
                new ("Licenciatura", "4"),
                new ("Especialização", "5"),
                new ("MBA", "6"),
                new ("Mestrado", "7"),
                new ("Doutorado", "8"),
                new ("Pós-Doutorado", "9"),
            };

            AcademicStatusOptions = new List<SelectListItem> {
                new ("", "0"),
                new ("Em progresso", "1"),
                new ("Trancado", "2"),
                new ("Concluído", "3"),
            };

            AcademicFormationFields = JsonSerializer.Serialize(typeof(AcademicFormation)
                .GetProperties()
                .Select(p => p.Name)
                .ToArray());
        }
    
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new ApplicationUser()
            {
                Name = UserData.Name,
                Email = UserData.Email,
                Password = UserData.Password,
                UserName = UserData.UserName
            };

            var result = await _repository.Create(user);

            return Page();
        }
    }
}
