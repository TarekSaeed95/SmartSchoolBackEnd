using SmartSchool.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IRequestRepo
    {
         public RequestVM Create (RequestVM obj);

        public IEnumerable<RequestVM> GetAll();

        public RequestVM GetById (int id);

        public  void SaveInDb (int id,string ParentId, string StudentId);

        public void Delete (int id);
    }
}
