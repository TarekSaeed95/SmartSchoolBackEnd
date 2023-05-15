using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IScheduleRepo
    {
        public Schedule Create(ScheduleVM obj);

        public IEnumerable<ScheduleVM> GetAll();

        public ScheduleVM GetById(int id);

        public void Delete(int id);

        public Schedule Edit(ScheduleVM obj);
    }
}
