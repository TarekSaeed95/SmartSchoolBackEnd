using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.ViewModel
{
    public class ClassRoomVM
    {
        //for all VM will we keep ID or not ?

        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        [Required]

        public int gradeYearId { get; set; }

        public string? GradeYearName { set; get; }

        //[InverseProperty("Class")]
        //public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

        //[InverseProperty("ClassRoom")]
        //public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        //[ForeignKey("gradeYearId")]
        //[InverseProperty("ClassRooms")]
        //public virtual GradeYear gradeYear { get; set; }



        //should we add manytomany relation between classroom and teacher or not?
        //[ForeignKey("ClassroomId")]
        //[InverseProperty("Classrooms")]
        //public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
