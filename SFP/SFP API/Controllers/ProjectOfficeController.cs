using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PUCIT.AIMRL.SFP.MainApp.APIControllers
{
    public class ProjectOfficeController : ApiController
    {
        private readonly ProjectOfficeRepository _repository;

        public ProjectOfficeController()
        {
            _repository = new ProjectOfficeRepository();
        }
        private ProjectOfficeRepository Repository
        {
            get
            {
                return _repository;
            }
        }
        [HttpGet]
        public ResponseResult GetFinalProjects()
        {
            var rv = Repository.GetFinalProjects();
            return rv;
        }


    }
}