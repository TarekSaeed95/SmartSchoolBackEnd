using SmartSchool.BL.Repository;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IClassRoomRepo
    {
        public ClassRoom Create(ClassRoomVM obj);

        public IEnumerable<ClassRoomVM> GetAll();

        public ClassRoomVM GetById(int id);

        public void Delete(int id);
    }
}
