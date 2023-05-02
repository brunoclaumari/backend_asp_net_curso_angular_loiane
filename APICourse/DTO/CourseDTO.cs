using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APICourse.DTO
{
    public record CourseDTO(
        
        int _id,

        [Required(ErrorMessage = "Campo \"nome\" é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 100 caracteres!")] 
        string Name,

        [Required(ErrorMessage = "Campo \"categoria\" é obrigatório!")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression("back-end|front-end")]
        string Category)
    {
        

    }
}
