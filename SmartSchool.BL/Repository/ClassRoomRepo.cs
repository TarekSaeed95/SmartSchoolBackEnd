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
    //test /test2

    //hne7tag edit wla la2 ?
    public class ClassRoomRepo :IClassRoomRepo
    {
       
            public SmartSchoolContext Db { get; }
            public ClassRoomRepo(SmartSchoolContext db)
            {
                Db = db;
            }
            public IEnumerable<ClassRoomVM> GetAll()
            {
                var allClassRooms = Db.ClassRooms.Include("gradeYear").Select(obj => new ClassRoomVM()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    gradeYearId = obj.gradeYearId,
                    GradeYearName  = obj.gradeYear.Name,

                });

                return allClassRooms;
            }

            public ClassRoomVM GetById(int id)
            {
                var myClassRoom = Db.ClassRooms.Include("gradeYear").Where(r => r.Id == id).Select(obj => new ClassRoomVM()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    //momken mnrg3sh l id we nrga3 l name bta3 l grade bas :)
                    gradeYearId = obj.gradeYearId,
                    GradeYearName = obj.gradeYear.Name,

                }).FirstOrDefault();

                return myClassRoom;
            }

        //hena l gradeyearName bterga3 bnull bas lma ne3mel getall btozbot 3ady :)
            public ClassRoom Create(ClassRoomVM obj)
            {
                ClassRoom classRoom = new ClassRoom()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    gradeYearId = obj.gradeYearId,
                    

                };

                Db.ClassRooms.Add(classRoom);
                Db.SaveChanges();
                //law 3awzen nrga3 l object bel id b3d l creation hne3mel map bel 3aks
                //var data  = Db.GradeYears.LastOrDefault();

                //we return same object to check if request works
                //will be deleted and fn will be void.
                return classRoom;
            }


            public void Delete(int id)
            {
                var myClassRoom = Db.ClassRooms.Find(id);
                Db.ClassRooms.Remove(myClassRoom);
                Db.SaveChanges();
            }

       
    }
}
