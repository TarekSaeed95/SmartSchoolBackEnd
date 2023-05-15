using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface ISessionRepo
    {
        public Session Create(SessionVM obj);

        public IEnumerable<SessionVM> GetAll();

        public SessionVM GetById(int id);

        public void Delete(int id);

        public Session Edit(SessionVM obj);
    }
}
