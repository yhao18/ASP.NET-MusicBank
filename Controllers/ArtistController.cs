using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6YH.Models;

namespace W2022A6YH.Controllers
{
    public class ArtistController : Controller
    {

        private Manager m = new Manager();
        // GET: Artist
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            var Artist = m.ArtistGetById(id.GetValueOrDefault());
            if (Artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Artist);
            }
        }

        // GET: Artist/Create
        //TODO 01: enable authorize
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();
            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
            return View(form);
        }

        // POST: Artist/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
             //var errors = ModelState
             //   .Where(x => x.Value.Errors.Count > 0)
             //   .Select(x => new { x.Key, x.Value.Errors })
             //   .ToArray();

            if (!ModelState.IsValid)
            {
                var form = new ArtistAddFormViewModel();
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
                return View(form);
            }

            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }

        }


        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var a = m.ArtistGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddFormViewModel();
                form.ArtistName = a.Name;
                form.ArtistId = a.Id;
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");


                return View(form);
            }
        }


        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                var form = new AlbumAddFormViewModel();
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

                return View(form);
            }

            // Process the input
            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "Album", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var o = m.ArtistGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new MediaItemAddFormViewModel();
    
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}";

                return View(form);
            }
        }

        [HttpPost]
        [Route("artist/{id}/addmediaitem")]
        [Authorize(Roles = "Coordinator")]
        public ActionResult AddMediaItem(int? id, MediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

    }
}
