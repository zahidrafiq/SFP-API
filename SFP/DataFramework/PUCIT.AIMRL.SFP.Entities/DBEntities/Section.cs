using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUCIT.AIMRL.SFP.Entities.DBEntities
{
    [Table("sec.Section")]
    public class Section
    {
        [Key]
        public String SectionId { get; set; }
        public String SectionName { get; set; }
        
    }
    
}
