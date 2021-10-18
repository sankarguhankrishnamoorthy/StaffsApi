using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcclient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace mvcclient.Controllers
{
    public class StaffController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public StaffController(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            List<Course> CourseDetail = new List<Course>(); 

            using (var client = new HttpClient())
            {
                //Passing service base url  
                // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44303/api/Staff/GetCourses");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CourseDetail = JsonConvert.DeserializeObject<List<Course>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(CourseDetail);
            }
        }
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse(Course c,IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File not selected");
            }
            else
            {
                var path = Path.Combine(this.webHostEnvironment.WebRootPath, "Courseimages", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);
                c.Picture = "~/CourseImages/" + photo.FileName;
            }
            
            Course NewCourse = new Course();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44303/api/Staff/AddCourses", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // NewCourse = JsonConvert.DeserializeObject<Course1>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddTopics(Course c)
        {
            HttpContext.Session.SetInt32("cid", c.CourseId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTopics(Topic m,IFormFile Videopic,IFormFile Material)
        {
           
                if (Videopic == null || Videopic.Length == 0)
                {
                    return Content("File not selected");
                }
                else
                {
                    var path = Path.Combine(this.webHostEnvironment.WebRootPath, "Videos", Videopic.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    await Videopic.CopyToAsync(stream);
                    m.VideoPath = "~/Videos/" + Videopic.FileName;
                }

            if (Material == null || Material.Length == 0)
            {
                return Content("File not selected");
            }
            else
            {
                var path = Path.Combine(this.webHostEnvironment.WebRootPath, "Material", Material.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await Material.CopyToAsync(stream);
                m.MaterialPath = "~/Material/" + Material.FileName;
            }

            Topic NewModule = new Topic();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(m), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44303/api/Staff/AddTopic", content)) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //NewCourse = JsonConvert.DeserializeObject<Course1>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Topic(Course c)
        {
            List<Topic> Detail = new List<Topic>();
            int id = c.CourseId;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44303/api/Staff/Topics?cid=" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Detail = JsonConvert.DeserializeObject<List<Topic>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(Detail);
            }


        }
        public IActionResult AddClass(Course c)
        {
            HttpContext.Session.SetInt32("ccid", c.CourseId);
            return View();

        }
        [HttpPost]
        public async Task<ActionResult> AddClass(Class c)
        {
            Class NewCourse = new Class();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44303/api/Staff/ScheduleClass", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // NewCourse = JsonConvert.DeserializeObject<Course1>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>GetAllClass()
        {
            List<Class> ClassDetail = new List<Class>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44303/api/Staff/GetAllClasses");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ClassDetail = JsonConvert.DeserializeObject<List<Class>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(ClassDetail);
            }
        }
        //public async Task<IActionResult> GetDetails(int id)
        //{
        //    Course course = new Course();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44302/api/employeenews/" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            course = JsonConvert.DeserializeObject<Course>(apiResponse);
        //        }
        //    }
        //    return View(course);
        //}
        public IActionResult GetDetails(Course item)
        {
            return View(item);
        }





    }
}

