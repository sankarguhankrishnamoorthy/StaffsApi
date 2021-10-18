using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffsApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StaffController));
        public ELearnApplicationContext db = new ELearnApplicationContext();
        [HttpPost]
        [Route("AddCourses")]
        public async Task<IActionResult> AddsCourse(Course c)
        {
            db.Courses.Add(c);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        [Route("AddTopic")]
        public async Task<IActionResult> AddModule(Topic m)
        {
            _log4net.Info("Topic"+m.TopicName + "is added in " + m.CourseId);
            db.Topics.Add(m);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpPost]
        [Route("ScheduleClass")]
        public async Task<IActionResult>ScheduleClass(Class c)
        {
           // _log4net.Info("Topic" + m.TopicName + "is added in " + m.CourseId);
            db.Classes.Add(c);
            await db.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            _log4net.Info("Your courses are viewed");
            return Ok(db.Courses.ToList());
     
        }
        [HttpGet]
        [Route("Topics")]
        public async Task<IActionResult> Topics(int cid)
        {
            List<Topic> modDetail = new List<Topic>();

            modDetail = (from i in db.Topics
                         where i.CourseId == cid
                         select i).ToList();

            return Ok(modDetail);
        }
        [HttpGet]
        [Route("GetAllClasses")]
        public async Task<IActionResult>GetAllClasses()
        {
            return Ok(db.Classes.ToList());
               
        }
        

    }
}
