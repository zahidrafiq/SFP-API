using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PUCIT.AIMRL.SFP.MainApp.Models;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.Entities;

namespace PUCIT.AIMRL.SFP.MainApp.APIControllers
{
    public class DashboardController : BaseDataController
    {
        private readonly DashboardRepository _repository;
        public DashboardController()
        {
            _repository = new DashboardRepository();
        }

        private DashboardRepository Repository
        {
            get
            {
                return _repository;
            }
        }
        
        [HttpPost]
        public ResponseResult changePassword(PasswordEntity pass)
        {
            return Repository.ChangePassword(pass);
        }
    }
}

