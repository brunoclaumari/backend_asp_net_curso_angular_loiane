using APICourse.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APICourse.Models
{
    [Table("tbCourse")]
    public class Course
    {
        [Key]
        //[DefaultValue(0)]        
        [JsonPropertyName("_id")]
        [Column("_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo \"nome\" é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 100 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo \"categoria\" é obrigatório!")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression("back-end|front-end")]
        public string Category { get; set; }

        [DefaultValue("Ativo")]
        [Required(ErrorMessage = "Campo \"status\" é obrigatório!")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression("Ativo|Inativo")]
        public string Status { get; set; } = UtilConstants.Ativo;

        //Não esquecer de fazer o DTO, que não vai ter o status
        public Course()
        {
            //Status = UtilConstants.Ativo;
        }


    }
}
