using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSchool.DAL.Entities;

public class TeacherAttendance
{
    [Key]
    public int id { set; get; }

    [DataType(DataType.Date)]
    public DateTime date { set; get; }
    public bool state { set; get; }

    [ForeignKey("student")]
    public string TeacherId { set; get; }

    public virtual Teacher? student { get; set; }

}


