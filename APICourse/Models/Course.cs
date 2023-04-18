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

        public string Name { get; set; }

        public string Category { get; set; }

        public Course()
        {
        }

        public Course(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
