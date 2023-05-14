using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface ISubjectRepo
    {
        public Subject Create(SubjectVM obj);

        public IEnumerable<SubjectVM> GetAll();

        public SubjectVM GetById(int id);

        public void Delete(int id);
    }
}
