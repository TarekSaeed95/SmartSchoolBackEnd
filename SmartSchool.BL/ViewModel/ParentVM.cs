using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SmartSchool.DAL.Entities;
using SmartSchool.DAL.OurEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartSchool.BL.ViewModel
{
    public class ParentVM
    {
       
        [StringLength(50)]

        public string Id { get; set; }

        [Required]
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        public string ParentFullName { get; set; }


        [Required]
        public string ParentPhone { get; set; }


        public string IdentityParentPhotoUrl { set; get; }

        [NotMapped]
        public IFormFile? IdentityParentPhoto { set; get; }

        //[StringLength(50)]

        //public string? Profession { get; set; }

        //[InverseProperty("Parent")]
        //public virtual ICollection<Compilation> Compilations { get; set; } = new List<Compilation>();

        [InverseProperty("Parent")]
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();


        

    }
}
