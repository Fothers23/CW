using System;
using System.ComponentModel.DataAnnotations;

// This model contains the properties relating to statuses.
namespace CW.Models
{
    public class Status
    {
        [Key]
        [ScaffoldColumn(false)]
        public int StatusID { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Post { get; set; }

        [Display(Name = "Date Posted")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy} at {0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        // This constructor sets the current time when the status is created.
        public Status()
        {
            DatePosted = DateTime.Now;
        }
    }
}
