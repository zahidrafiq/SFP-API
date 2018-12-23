using PUCIT.AIMRL.SFP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PUCIT.AIMRL.SFP.MainApp.APIControllers
{
    public class ProjectsController : ApiController
    {
        public class Project
        {
            public String Title { get; set; }
            public String Description { get; set; }
            public String Type { get; set; }
        }
        public ResponseResult ChangeDesig(int aid)
        {
            return null;
            //return Repository.UpdateDesign(aid);
        }

        [HttpPost]
        public ResponseResult ShareIdea(Project proj)
        {
            //var uniqueName = "";
            //var file = Request.Files["upLoadedFile"];
            //if (Request.Files["upLoadedFile"]!= null)
            //{
            //    if(file.FileName != "")
            //    {
            //        var ext = System.IO.Path.GetExtension(file.FileName);
            //        uniqueName = Guid.NewGuid().ToString() + ext;
            //        var rootPath = Microsoft.SqlServer.Server.MapPath("~/UploadedFiles");
            //        var FileSavePath = System.IO.Path.Combine(rootPath, uniqueName);
            //        file.SaveAs(FileSavePath);
            //    }

            
            //}
            return null;
        }
    }

}
