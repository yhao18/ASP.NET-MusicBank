using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6YH.Models
{
    public class AlbumBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Album cover art")]
        [Required, StringLength(512)]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }

    }

    public class AlbumDetailViewModel : AlbumBaseViewModel
    {
        [Required, StringLength(10000)]
        [Display(Name = "Album background")]
        [DataType(DataType.MultilineText)]
        public string Background { get; set; }
    }

    public class AlbumAddFormViewModel
    {
        public AlbumAddFormViewModel()
        {
            ReleaseDate = DateTime.Now.Date.AddYears(-2);
        }

        [Required]
        [StringLength(200)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(500)]
        [Display(Name = "URL to album image(cover art)")]
        public string UrlAlbum { get; set; }

        [StringLength(200)]
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }


        public string ArtistName { get; set; }

        public int ArtistId { get; set; }

        [Required, StringLength(10000)]
        [Display(Name = "Album background")]
        [DataType(DataType.MultilineText)]
        public string Background { get; set; }
    }

    public class AlbumAddViewModel
    {


        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(500)]
        public string UrlAlbum { get; set; }

        [StringLength(500)]
        public string GenreName { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }


        [Required, StringLength(10000)]
        [Display(Name = "Album background")]
        [DataType(DataType.MultilineText)]
        public string Background { get; set; }

    }

}