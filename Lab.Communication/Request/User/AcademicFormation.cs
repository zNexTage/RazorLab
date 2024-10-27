using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Communication.Request.User
{
    public class AcademicFormation
    {
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Informe o curso")]
        [StringLength(100, ErrorMessage = "O curso deve ter no máximo 100 caracteres")]
        public string Course { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe qual o status do curso. (em progresso, concluído, etc...)")]
        public int Status { get; set; }

        [Display(Name = "Nível de formação")]
        [Range(1, int.MaxValue, ErrorMessage = "Informe seu nível de formação.")]
        public int Formation { get; set; }

        [Display(Name = "Instituição")]
        [Required(ErrorMessage = "Informe a instituição")]
        [StringLength(100, ErrorMessage = "A instituição deve ter no máximo 100 caracteres")]
        public string Institution { get; set; }
    }
}
