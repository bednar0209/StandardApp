using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StandardApp.Model;
using StandardApp.Model.Entities;
using StandardApp.DataAccess;

namespace StandardApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IGenericRepository<Order> _repo;
        private IGenericRepository<Person> _repoPeople;

        public OrderController(IGenericRepository<Order> repo, IGenericRepository<Person> repoPeople)
        {
            _repo = repo;
            _repoPeople = repoPeople;
        }

        // GET: Order
        public ActionResult Index()
        {
            //var orders = db.Orders.Include(o => o.Person);
            return View(_repo.GetAll().ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _repo.FindBy(x => x.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(_repoPeople.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,PersonID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _repo.Persist(order);
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(_repoPeople.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _repo.FindBy(x => x.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(_repoPeople.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,PersonID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _repo.Persist(order);
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(_repoPeople.GetAll(), "Id", "FirstName", order.PersonID);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _repo.FindBy(x => x.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
