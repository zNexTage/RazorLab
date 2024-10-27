using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Communication.Request.User
{
    public class User
    {
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe um nome de usuário")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]

        public string Password { get; set; }

        public List<AcademicFormation> AcademicFormations { get; set; } = new();
    }
}
