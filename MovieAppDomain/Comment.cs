using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppDomain
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string? CommentDesc { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movies { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }      
        //public User Users { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
