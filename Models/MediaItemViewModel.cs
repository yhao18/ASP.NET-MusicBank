using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6YH.Models
{
    public class MediaItemBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Added on date/time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Timestamp { get; set; }

        [Required, StringLength(100)]
        public string StringId { get; set; }

        //public byte[] Content { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        // Brief descriptive caption
        [Required, StringLength(100)]
        public string Caption { get; set; }
    }

    public class MediaItemContentViewModel
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

    public class MediaItemAddFormViewModel
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist information")]
        public string ArtistInfo { get; set; }

        [Display(Name = "Description")]
        [Required, StringLength(100)]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media Item")]
        [DataType(DataType.Upload)]
        public string MediaItemUpload { get; set; }
    }

    public class MediaItemAddViewModel
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist information")]
        public string ArtistInfo { get; set; }

        [Display(Name = "Description")]
        [Required, StringLength(100)]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaItemUpload { get; set; }
    }
}