using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6YH.Models
{
    public class TrackBaseViewModel
    {
        public TrackBaseViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Track name")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Composer names(comma-separated)")]
        public string Composers { get; set; }

        [StringLength(200)]
        [Display(Name = "Track Genre")]
        public string Genre { get; set; }

        [Display(Name = "Albums")]
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }


        //public int AlbumArtistId { get; set; }
    }

    public class TrackDetailViewModel: TrackBaseViewModel
    {
        [Display(Name = "Sample clip")]
        public string ClipUrl
        {
            get
            {
                return $"/clip/{Id}";
            }
        }

    }

    public class TrackClipViewModel
    {
        public int Id { get; set; }

        [StringLength(2000)]
        public string ClipContentType { get; set; }
        public byte[] Clip { get; set; }
    }


    public class TrackAddFormViewModel
    {
        [Required]
        [Display(Name = "Track name")]
        [StringLength(200)]
        public string Name { get; set; }


        [StringLength(200)]
        [Display(Name = "Composer names(comma-separated)")]
        public string Composers { get; set; }

        [Required]
        [Display(Name = "Track genre")]
        public SelectList GenreList { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }

        [StringLength(200)]
        public string AlbumName { get; set; }

        [Range(0, 10000)]
        public int AlbumId { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }
    }

    public class TrackAddViewModel
    {
        [Required, StringLength(200)]
        public string Name { get; set; }


        [Required, StringLength(200)]
        public string Composers { get; set; }

        [StringLength(500)]
        public string GenreName { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }

        [StringLength(200)]
        public string AlbumName { get; set; }

        [Range(0, 10000)]
        public int AlbumId { get; set; }

        public HttpPostedFileBase ClipUpload { get; set; }
    }



    public class TrackEditFormViewModel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Clip")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }
    }

    public class TrackEditViewModel
    {

        [Key]
        public int Id { get; set; }

        public HttpPostedFileBase ClipUpload { get; set; }
    }


}