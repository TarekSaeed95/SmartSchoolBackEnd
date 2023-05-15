using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Entities
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        //to print day not all date.
        //DateTime d = actucal date;
        //Console.WriteLine(d.ToString("dddd")); 
        [Column(TypeName = "Date")]
        public DateTime Day { get; set; }

       

        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        //[InverseProperty("Schedules")]
        public virtual ClassRoom Class { get; set; }

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

       

        //to avoid infinite loop
        //[Required]
        //public int SubjectId { get; set; }

       
        //[ForeignKey("SubjectId")]
        ////[InverseProperty("Schedules")]
        //public virtual Subject Subject { get; set; }

       

       
        
    }
}
