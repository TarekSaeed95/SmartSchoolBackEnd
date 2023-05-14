using SmartSchool.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IComplaintRepo
    {
        public ComplaintVM Create(ComplaintVM obj);

        public IEnumerable<ComplaintVM> GetAll();

       

       
    }
}
