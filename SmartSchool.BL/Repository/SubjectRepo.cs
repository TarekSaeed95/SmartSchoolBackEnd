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
    public class SubjectRepo : ISubjectRepo
    {
        public SmartSchoolContext Db { get; }
        public SubjectRepo(SmartSchoolContext db)
        {
            Db = db;
        }
        public IEnumerable<SubjectVM> GetAll()
        {
            var allSubjects = Db.Subjects.Include("GradeYear").Select(obj => new SubjectVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                GradeYearId = obj.GradeYearId,
                GradeYearName = obj.GradeYear.Name,

            });

            return allSubjects;
        }

        public SubjectVM GetById(int id)
        {
            var mySubject= Db.Subjects.Include("GradeYear").Where(r => r.Id == id).Select(obj => new SubjectVM()
            {
                Id = obj.Id,
                Name = obj.Name,
                GradeYearId = obj.GradeYearId,
                GradeYearName = obj.GradeYear.Name,

            }).FirstOrDefault();

            return mySubject;
        }

        //hena l gradeyearName bterga3 bnull bas lma ne3mel getall btozbot 3ady :)
        public Subject Create(SubjectVM obj)
        {
            Subject subject = new Subject()
            {
                Id = obj.Id,
                Name = obj.Name,
                GradeYearId = obj.GradeYearId,
                
            };

            Db.Subjects.Add(subject);
            Db.SaveChanges();
            //law 3awzen nrga3 l object bel id b3d l creation hne3mel map bel 3aks
            //var data  = Db.GradeYears.LastOrDefault();

            //we return same object to check if request works
            //will be deleted and fn will be void.
            return subject;
        }


        public void Delete(int id)
        {
            var subject = Db.Subjects.Find(id);
            Db.Subjects.Remove(subject);
            Db.SaveChanges();
        }
    }
}

