using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.ViewModel
{
    public class GradeYearVM
    {
       

        public int Id { get; set; }

       
        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        [Required]
        public decimal Fees { get; set; }

       
        //[InverseProperty("gradeYear")]
        //public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

        //[InverseProperty("GradeYear")]
        //public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
