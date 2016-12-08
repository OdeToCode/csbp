using System;
using System.Collections.Generic;
using System.Linq;
using BeyondQueries.Domain;
using BeyondQueries.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeyondQueries.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EvaluateMovie(Movie movie)
        {
            var flowchart = MovieFlowchart.Create();

            var result = flowchart.Evaluate(movie);

            return Json(new
            {
                result = result.Result,
                required = result.RequiredFields.Select(f => f.PropertyName)
            });
        }
    }
}
