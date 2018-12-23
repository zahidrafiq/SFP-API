using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCIT.AIMRL.SFP.Entities.DBEntities
{
    [Table("dbo.Comments")]
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public String CommentText { get; set; }
        private DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        private bool IsActive { get; set; }
    }

    public class ProjectComments : Comments
    {
        //public int ProjectId { get; set; }
        //public int CommentId { get; set; }
        //public String CommentText { get; set; }
        //public int UserId { get; set; }
        public String UserName { get; set; }
        public String ProfilePicName { get; set; }
        //public DateTime CreatedOn { get; set; }
    }
}
