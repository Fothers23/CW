using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW.Models
{
    public class StatusDetailsViewModel
    {
        public Status Status { get; set; }
        public List<Comment> Comments { get; set; }
        public int CommentID { get; set; }
        public int StatusID { get; set; }
        public string Remark { get; set; }
        public DateTime DateCommented { get; set; }
    }
}
