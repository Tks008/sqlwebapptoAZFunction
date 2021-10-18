using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sqlwebapp.Models;
using sqlwebapp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sqlwebapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _CourseService;
        private readonly IConfiguration _Configuration;
        public CourseController(CourseService courseService, IConfiguration configuration)
        {
            _CourseService = courseService;
            _Configuration = configuration;
        }
        public IActionResult Index()
        {
            var data = _CourseService.GetCourses(_Configuration.GetConnectionString("SQLconnection"));
            return View(data);
        }
    }
}
