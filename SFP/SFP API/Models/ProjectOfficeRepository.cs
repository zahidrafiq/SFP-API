using PUCIT.AIMRL.SFP.DAL;
using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.MainApp.Util;
using PUCIT.AIMRL.SFP.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PUCIT.AIMRL.SFP.MainApp.Models
{
    public class ProjectOfficeRepository
    {
        private PRMDataService _dataService;
        public ProjectOfficeRepository()
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
        public ResponseResult GetFinalProjects()
        {

            try
            {
                List<Project> list = DataService.GetAllFinalProjects();
                return ResponseResult.GetSuccessObject(new
                {
                    ProjectList = list
                });
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject("Some error has occured in ProjectRepository");
            }
        }


    }
}