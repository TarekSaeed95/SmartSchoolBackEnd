using SmartSchool.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IStudentRepo
    {
        public StudentVM Edit(string id);


        //for admins or teachers
        public IEnumerable<StudentVM> GetAll();

        
    }
}
