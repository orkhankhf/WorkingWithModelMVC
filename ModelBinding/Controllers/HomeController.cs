using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinding.Models;
using System.Dynamic;

namespace ModelBinding.Controllers
{
	public class HomeController : Controller
	{
		AnimalEntities db = new AnimalEntities();
		public ActionResult Index()
		{
			return View(new ModelData() { Teachers = db.Teachers.ToList(), Students = db.Students.ToList() });
		}



		[HttpPost]
		public ActionResult Index([Bind(Include = "id,name,surname,age")] Student std)
		{
			std.age = Convert.ToInt32(std.age);
			db.Students.Add(std);
			db.SaveChanges();

			return RedirectToAction("Index");
		}



		[HttpGet]
		public ActionResult Edit(int? id)
		{
			var row = db.Students.Find(id);
			return View(row);
		}
		[HttpPost]
		public ActionResult Edit(int? id, Student std)
		{
			var row = db.Students.Find(id);
			row.name = std.name;
			row.surname = std.surname;
			row.age = std.age;
			db.SaveChanges();
			return View(row);
		}



		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
	
}