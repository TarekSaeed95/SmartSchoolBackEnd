using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Repository
{
    public class GradeYearRepo :IGradeYearRepo
    {
        public SmartSchoolContext Db { get; }
        public GradeYearRepo(SmartSchoolContext db)
        {
            Db = db; 
        }
        public IEnumerable<GradeYearVM> GetAll()
        {
            var allGradYears = Db.GradeYears.Select(obj => new GradeYearVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                Fees = obj.Fees,
               

            });

            return allGradYears;
        }

        public GradeYearVM GetById(int id)
        {
            var myGradYear = Db.GradeYears.Where(r => r.Id == id).Select(obj => new GradeYearVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                Fees = obj.Fees,

            }).FirstOrDefault();

            return myGradYear;
        }

        public GradeYear Create(GradeYearVM obj)
        {
            GradeYear gradYear = new GradeYear()
            {
                Id = obj.Id,
                Name = obj.Name,
                Fees = obj.Fees,

            };

            Db.GradeYears.Add(gradYear);
            Db.SaveChanges();
            //law 3awzen nrga3 l object bel id b3d l creation hne3mel map bel 3aks
            //var data  = Db.GradeYears.LastOrDefault();

            //we return same object to check if request works
            //will be deleted and fn will be void.
            return gradYear;
        }

      
        public void Delete(int id)
        {
            var gradeYear = Db.GradeYears.Find(id);
            Db.GradeYears.Remove(gradeYear);
            Db.SaveChanges();
        }
    }
}
