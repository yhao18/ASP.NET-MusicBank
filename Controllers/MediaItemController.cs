using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6YH.Controllers
{
    public class MediaItemController : Controller
    {
        Manager m = new Manager();
        // GET: MediaItem
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: MediaItem/Details/5
        [Route("mediaItem/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(o.Content, o.ContentType);
            }
        }

       

        [Route("mediaitem/{stringId}/download")]
        public ActionResult MediaItemDownload(string stringId = "")
        {
            // Attempt to get the matching object
            var o = m.ArtistMediaItemGetById(stringId);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                string extension;
                RegistryKey key;
                object value;

                key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + o.ContentType, false);
               
                value = (key == null) ? null : key.GetValue("Extension", null);
                
                extension = (value == null) ? string.Empty : value.ToString();

                // Create a new Content-Disposition header
                var cd = new System.Net.Mime.ContentDisposition
                {
                    
                    FileName = $"doc-{stringId}{extension}",
                    // Force the media item to be saved (not viewed)
                    Inline = false
                };
                // Add the header to the response
                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(o.Content, o.ContentType);
            }
        }
    }
}
