using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCIT.AIMRL.SFP.Entities.DBEntities
{
    public class ProjectAndComments
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int CommentId { get; set; }
        public String ProjectTitle { get; set; }
        public String Description { get; set; }
        public String CommentText { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TotalUpVote { get; set; }
        public int TotalDownVote { get; set; }
        public int BidCount { get; set; }
        public String Type { get; set; }
    }
}
