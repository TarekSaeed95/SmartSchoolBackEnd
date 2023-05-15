using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.ViewModel
{
    public class ScheduleVM
    {
        
        public int Id { get; set; }

        //to print day not all date.
        //DateTime d = actucal date;
        //Console.WriteLine(d.ToString("dddd"));  
        [Required]
        public DateTime Day { get; set; }

        [Required]
        public int ClassId { get; set; }


        //nzwedo hena wla neb2a ne3mel view model ll getall wel get 
        public string? ClassRoomName { set; get; }

        //nzwedo hena wla neb2a ne3mel view model ll getall wel get 
        //public string? GradeYearName { set; get; }
    }
}
