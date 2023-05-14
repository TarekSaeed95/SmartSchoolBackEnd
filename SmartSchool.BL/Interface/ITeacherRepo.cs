using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface ITeacherRepo
    {
        public void SaveInDb(TeacherVM obj, string TeacherId);

        //void b3d kda for check
        public Teacher Edit(string id, TeacherVMEdit obj);

        public IEnumerable<TeacherVM> GetAll();

        public TeacherVM GetById(string id);

        public void Delete(string id);
    }
}
