using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6YH.Models;

namespace W2022A6YH.Controllers
{
    public class AlbumController : Controller
    {
        private Manager m = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Album/Details/5

        public ActionResult Details(int? id)
        {
            var Album = m.AlbumGetById(id.GetValueOrDefault());
            if (Album == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Album);
            }
        }


        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var a = m.AlbumGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddFormViewModel();
                form.AlbumName = a.Name;
                form.AlbumId = a.Id;
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");


                return View(form);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                var form = new TrackAddFormViewModel();
          
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
                return View(form);
            }

            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "Track", new { id = addedItem.Id });
            }
        }

    }
}
