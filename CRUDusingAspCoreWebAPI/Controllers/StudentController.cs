using CRUDusingAspCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks.Dataflow;

namespace CRUDusingAspCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string Url = "https://localhost:7093/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> stud = new List<Student>();
            HttpResponseMessage res = client.GetAsync(Url).Result;
            if (res.IsSuccessStatusCode)
            {
                string result = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    stud = data;
                }
            }
            
            return View(stud);
        }
    }
}
