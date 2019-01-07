using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// This model contains the properties and entities relating to comments.
namespace CW.Models
{
    public class Comment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CommentId { get; set; }

        [StringLength(200)]
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        [Display(Name = "Date Posted")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy} at {0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateCommented { get; set; }

        public Comment()
        {
            DateCommented = DateTime.Now;
        }

        public virtual Status MyStatus { get; set; }
        public virtual ApplicationUser MyUser { get; set; }
    }
}
