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
    public class ScheduleRepo : IScheduleRepo
    {
        public SmartSchoolContext Db { get; }
        public ScheduleRepo(SmartSchoolContext db)
        {
            Db = db;
        }
        public IEnumerable<ScheduleVM> GetAll()
        {
            //var allSchedules = Db.Schedules.Include("Class").Select(obj => new ScheduleVM()

           var allSchedules = Db.Schedules.Include(a=>a.Class).Select(obj => new ScheduleVM()
           {
               Id = obj.Id,
               Day = obj.Day,
               ClassId = obj.ClassId,
               ClassRoomName = obj.Class.Name,
            
           });

            //var allSchedules = Db.Schedules.Include(a => a.Class).ThenInclude(a => a.gradeYear).Select(obj => new ScheduleVM()
            //{
            //    Id = obj.Id,
            //    Day = obj.Day,
            //    ClassId = obj.ClassId,
            //    ClassRoomName = obj.Class.Name,
            //    //momken mne7tgsh l gradeyearname kda kda esm l class room bey3bar 3nha.
            //    GradeYearName = obj.Class.gradeYear.Name
            //});

            return allSchedules;
        }

        public ScheduleVM GetById(int id)
        {
            var mySchedule = Db.Schedules.Where(r => r.Id == id).Select(obj => new ScheduleVM()
            {
                Id = obj.Id,
                Day = obj.Day,
                ClassId = obj.ClassId,
                ClassRoomName = obj.Class.Name

            }).FirstOrDefault();

            return mySchedule;
        }

        //hena l gradeyearName bterga3 bnull bas lma ne3mel getall btozbot 3ady :)
        public Schedule Create(ScheduleVM obj)
        {
            Schedule Schedule = new Schedule()
            {
                Id = obj.Id,
                Day = obj.Day,
                ClassId = obj.ClassId,
 
            };

            Db.Schedules.Add(Schedule);
            Db.SaveChanges();
            //law 3awzen nrga3 l object bel id b3d l creation hne3mel map bel 3aks
            //var data  = Db.GradeYears.LastOrDefault();

            //we return same object to check if request works
            //will be deleted and fn will be void.
            return Schedule;
        }


        public void Delete(int id)
        {
            var mySchedule = Db.Schedules.Find(id);
            Db.Schedules.Remove(mySchedule);
            Db.SaveChanges();
        }

        public Schedule Edit(ScheduleVM obj)
        {
            
            Schedule S = Db.Schedules.Find(obj.Id);
            S.Id = obj.Id;
            S.Day = obj.Day;
            S.ClassId = obj.ClassId;
            Db.SaveChanges();
            return S;

            //another way to edit
            //Schedule S = new Schedule()
            //{
            //    Id = obj.Id,
            //    Day = obj.Day,
            //    ClassId = obj.ClassId
            //};
            //Db.Update(S);


            //Db.SaveChanges();
            //return S;


        }
    }
}
