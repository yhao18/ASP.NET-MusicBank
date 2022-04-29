using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6YH.Models
{
    public class ArtistBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }


        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        [Display(Name = "Artist photo")]
        [Required, StringLength(512)]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }

    }


    public class ArtistDetailWithMediaItemViewModel : ArtistBaseViewModel
    {
        public ArtistDetailWithMediaItemViewModel()
        {
            MediaItems = new List<MediaItemBaseViewModel>();
        }

        [Required, StringLength(10000)]
        [Display(Name = "Artist portrayal")]
        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }

        public IEnumerable<MediaItemBaseViewModel> MediaItems { get; set; }
    }



    public class ArtistAddFormViewModel
    {
        public ArtistAddFormViewModel()
        {
            BirthOrStartDate = DateTime.Now.Date.AddYears(-20);
        }

        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }


        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        [Display(Name = "URL to artist photo")]
        [Required, StringLength(512)]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }

        [Required, StringLength(10000)]
        [Display(Name = "Artist portrayal")]
        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }

    }

    public class ArtistAddViewModel
    {

        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }


        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        [Display(Name = "URL to artist photo")]
        [Required, StringLength(512)]
        public string UrlArtist { get; set; }


        [Display(Name = "Artist's primary genre")]
        public string GenreName { get; set; }

        [Range(0, 10000)]
        public int GenreId { get; set; }

        [Required, StringLength(10000)]
        [Display(Name = "Artist portrayal")]
        public string Portrayal { get; set; }

    }
}