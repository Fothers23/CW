using System;
using System.Collections.Generic;

// This is view specific model to combine properties from status and comment into one view.
namespace CW.Models
{
    public class StatusDetailsViewModel
    {
        public Status Status { get; set; }
        public List<Comment> Comments { get; set; }
        public int CommentID { get; set; }
        public int StatusID { get; set; }
        public int UserID { get; set; }
        public string Remark { get; set; }
        public DateTime DateCommented { get; set; }
    }
}
