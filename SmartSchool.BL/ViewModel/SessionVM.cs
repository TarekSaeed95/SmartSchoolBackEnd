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
    public class SessionVM
    {

        
        public int Id { get; set; }

        [Range(1, 6)]
        public int SessionNo { get; set; }

        //public DateTime StartTime { get; set; }

        //public DateTime EndTime { get; set; }

        [Required]
        public int ScheduleID { get; set; }


        //public virtual Schedule Schedule { get; set; }

        //l teacher mrbot bel subject fmsh me7tagen nzwed l subject hena tany.
        [Required]
        public string TeacherID { get; set; }


        public string SubjectName { get; set; }

        public string TeacherName { get; set; }


        //could be deleted 
        public string ScheduleDay { get; set; }

        //public virtual Teacher? Teacher { get; set; }

    }
}
