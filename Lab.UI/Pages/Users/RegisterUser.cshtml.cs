using Lab.Communication.Request.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab.UI.Pages.Users
{
    public class RegisterUserModel : PageModel
    {

        [BindProperty]
        public User UserData { get; set; }

        private const string PAGE_TITLE = "Criar conta";

        public List<SelectListItem> AcademicFormationOptions { get; set; }
        
        public List<SelectListItem> AcademicStatusOptions { get; set; }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            ViewData["Title"] = PAGE_TITLE;

            // TODO: Criar enum
            AcademicFormationOptions = new List<SelectListItem> {
                new ("", "0"),
                new ("T�cnico", "1"),
                new ("Bacharel", "2"),
                new ("Tecn�logo", "3"),
                new ("Licenciatura", "4"),
                new ("Especializa��o", "5"),
                new ("MBA", "6"),
                new ("Mestrado", "7"),
                new ("Doutorado", "8"),
                new ("P�s-Doutorado", "9"),
            };

            AcademicStatusOptions = new List<SelectListItem> {
                new ("", "0"),
                new ("Em progresso", "1"),
                new ("Trancado", "2"),
                new ("Conclu�do", "3"),
            };
        }

        public IActionResult OnPost()
        {   
            return Page();
        }
    }
}
