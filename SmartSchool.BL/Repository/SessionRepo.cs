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
    public class SessionRepo : ISessionRepo
    {
        public SmartSchoolContext Db { get; }
        public SessionRepo(SmartSchoolContext db)
        {
            Db = db;
        }
        public IEnumerable<SessionVM> GetAll()
        {
            //var allSessions = Db.Sessions.Include("Class").Select(obj => new SessionVM()

            var allSessions = Db.Sessions.Include(a=>a.Schedule).Include(a=>a.Teacher).ThenInclude(a=>a.Subject).Select(obj => new SessionVM()
            {
                Id = obj.Id,
                SessionNo = obj.SessionNo,
                TeacherID = obj.TeacherID,
                ScheduleID = obj.ScheduleID,
                TeacherName = obj.Teacher.FullName,
                SubjectName = obj.Teacher.Subject.Name,
               ScheduleDay = obj.Schedule.Day.ToString("dddd")
               

            });

            //var allSessions = Db.Sessions.Include(a => a.Class).ThenInclude(a => a.gradeYear).Select(obj => new SessionVM()
            //{
            //    Id = obj.Id,
            //    Day = obj.Day,
            //    ClassId = obj.ClassId,
            //    ClassRoomName = obj.Class.Name,
            //    //momken mne7tgsh l gradeyearname kda kda esm l class room bey3bar 3nha.
            //    GradeYearName = obj.Class.gradeYear.Name
            //});

            return allSessions;
        }

        public SessionVM GetById(int id)
        {
            var mySession = Db.Sessions.Where(r => r.Id == id).Include(a => a.Teacher).ThenInclude(a => a.Subject).Select(obj => new SessionVM()
            {
                Id = obj.Id,
                SessionNo = obj.SessionNo,
                TeacherID = obj.TeacherID,
                ScheduleID = obj.ScheduleID,
                TeacherName = obj.Teacher.FullName,
                SubjectName = obj.Teacher.Subject.Name,
                ScheduleDay = obj.Schedule.Day.ToString("dddd")


            }).FirstOrDefault();

            return mySession;
        }

        //hena l gradeyearName bterga3 bnull bas lma ne3mel getall btozbot 3ady :)
        public Session Create(SessionVM obj)
        {
            Session Session = new Session()
            {
                Id = obj.Id,
                SessionNo = obj.SessionNo,
                TeacherID = obj.TeacherID,
                ScheduleID = obj.ScheduleID,

            };

            Db.Sessions.Add(Session);
            Db.SaveChanges();
            //law 3awzen nrga3 l object bel id b3d l creation hne3mel map bel 3aks
            //var data  = Db.GradeYears.LastOrDefault();

            //we return same object to check if request works
            //will be deleted and fn will be void.
            return Session;
        }


        public void Delete(int id)
        {
            var mySession = Db.Sessions.Find(id);
            Db.Sessions.Remove(mySession);
            Db.SaveChanges();
        }

        public Session Edit(SessionVM obj)
        {

            Session S = Db.Sessions.Find(obj.Id);
            S.Id = obj.Id;
            S.SessionNo = obj.SessionNo;
            S.TeacherID = obj.TeacherID;
            S.ScheduleID = obj.ScheduleID;
            Db.SaveChanges();
            return S;

           
        }
    }
}
