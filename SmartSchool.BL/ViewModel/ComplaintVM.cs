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
    public class ComplaintVM
    {
        

        public string Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        [Required]
        [StringLength(250)]

        public string Description { get; set; }

        [Required]
        [StringLength(50)]

        public string ParentID { get; set; }

        //[ForeignKey("ParentID")]
        //[InverseProperty("Complaints")]
        //public virtual Parent Parent { get; set; }
    }
}
