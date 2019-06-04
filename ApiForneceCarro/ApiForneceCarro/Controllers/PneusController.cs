using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiForneceCarro.Models;

namespace ApiForneceCarro.Controllers
{
    public class PneusController : Controller
    {
        private ApiForneceCarroContext db = new ApiForneceCarroContext();

        // GET: Pneus
        public ActionResult Index()
        {
            var pneus = db.Pneus.Include(p => p.Carro);
            return View(pneus.ToList());
        }

        // GET: Pneus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            return View(pneu);
        }

        // GET: Pneus/Create
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(db.Carroes, "CarroId", "Marca");
            return View();
        }

        // POST: Pneus/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PneuId,Marca,Aro,CarroId")] Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                db.Pneus.Add(pneu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarroId = new SelectList(db.Carroes, "CarroId", "Marca", pneu.CarroId);
            return View(pneu);
        }

        // GET: Pneus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(db.Carroes, "CarroId", "Marca", pneu.CarroId);
            return View(pneu);
        }

        // POST: Pneus/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PneuId,Marca,Aro,CarroId")] Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pneu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroId = new SelectList(db.Carroes, "CarroId", "Marca", pneu.CarroId);
            return View(pneu);
        }

        // GET: Pneus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            return View(pneu);
        }

        // POST: Pneus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pneu pneu = db.Pneus.Find(id);
            db.Pneus.Remove(pneu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
