using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6YH.Models;

namespace W2022A6YH.Controllers
{
    public class TrackController : Controller
    {
        private Manager m = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        [Route("clip/{id}")]
        public ActionResult ClipDetails(int? id)
        {
            var o = m.TrackClipGetById(id.GetValueOrDefault());

            if (o.ClipContentType == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Clip, o.ClipContentType);
            }
        }


        // GET: Track/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                var formModel = m.mapper.Map<TrackEditFormViewModel>(track);

                return View(formModel);
            }
        }

        // POST: Track/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditViewModel editItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = editItem.Id });
            }

            if (id.GetValueOrDefault() != editItem.Id)
            {
                return RedirectToAction("index");
            }

            var editedItem = m.TrackEditClip(editItem);

            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = editItem.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = editItem.Id });
            }
        }

        // GET: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            
                var result = m.TrackDelete(id.GetValueOrDefault());
                return RedirectToAction("index");

        }
    }
}
