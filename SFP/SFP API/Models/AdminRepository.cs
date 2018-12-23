using System.Web;
using PUCIT.AIMRL.SFP.DAL;
using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using System.Web.Security;
using System.Configuration;
using System;
using System.Linq;
using PUCIT.AIMRL.SFP.UI.Common;
using System.Collections.Generic;
using System.IO;
using PUCIT.AIMRL.SFP.MainApp.Util;
using PUCIT.AIMRL.SFP.Entities.Security;
using PUCIT.AIMRL.SFP.MainApp.Security;
using PUCIT.AIMRL.Common;
using System.Collections;


namespace PUCIT.AIMRL.SFP.MainApp.Models
{
    public class AdminRepository
    {
        private PRMDataService _dataService;
        public AdminRepository()
        {

        }
        private PRMDataService DataService
        {
            get
            {
                if (_dataService == null)
                    _dataService = new PRMDataService();

                return _dataService;
            }
        }

        public ResponseResult SearchUser(string key)
        {
            try
            {
                var list = DataService.SearchUser(key);

                var result = (from p in list
                              select new
                              {
                                  ID = p.UserId,
                                  Login = p.Login,
                                  Name = p.Name,
                                  RegistrationNumber=p.RegistrationNumber
                              }).ToList();

                return ResponseResult.GetSuccessObject(result);
                //return result;
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }
        }
    }
}