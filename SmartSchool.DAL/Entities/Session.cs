using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Range(1,6)]
        public int SessionNo { get; set; }


        //momken nzwedhom aw nkhlehom driven fel front .
        //public DateTime StartTime { get; set; }

        //public DateTime EndTime { get; set; }


        public int ScheduleID { get; set; }

        [ForeignKey("ScheduleID")]
       
        public virtual Schedule Schedule { get; set; }

        //l teacher mrbot bel subject fmsh me7tagen nzwed l subject hena tany.
        public string? TeacherID { get; set; }

        [ForeignKey("TeacherID")]
        
        public virtual Teacher? Teacher { get; set; }

    }
}
