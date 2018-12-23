using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PUCIT.AIMRL.SFP.Entities.Security
{
    public class SecUserDTO
    {
        
        public String UserFullName { get; set; }
        public int UserId { get; set; }
        public String Login { get; set; }
        public String Email { get; set; }
        public Boolean IsActive { get; set; }
        public List<String> Permissions { get; set; }
        public List<String> Roles { get; set; }
        public Boolean IsDisabledForLogin { get; set; }
        public String ProfilePicName { get; set; }
    }
}
