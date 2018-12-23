using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.MainApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PUCIT.AIMRL.SFP.MainApp.APIControllers
{
    public class UserWallController : BaseDataController
    {
        private readonly userWallRepository _repository;

        public UserWallController()
        {
            _repository = new userWallRepository();
        }
        private userWallRepository Repository
        {
            get
            {
                return _repository;
            }
        }

        // GET: UserWall
        
        public ResponseResult getUserInfo(int UserId)
        {
            

            return Repository.getUserInfo(UserId);
        }
        public String getImageName(String RegistrationNumber)
        {
            string[] filePaths = Directory.GetFiles("~/images/gallery");
            return filePaths[0];
        }
        [System.Web.Http.HttpGet]
        public ResponseResult GetProjectsByUserId(int UserId)
        {
            var rv = Repository.GetProjectsByUserId(UserId);
            return rv;
        }
        [System.Web.Http.HttpPost]
        public ResponseResult updateUserProfile(EditUser u)
        {
            return Repository.updateUserProfile(u);
        }

        [System.Web.Http.HttpPost]
        public ResponseResult updateUserProfilePic()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                //get other form data
                var username = HttpContext.Current.Request.Form["Username"];

                string uniqueName="";
                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)
                    var ext = System.IO.Path.GetExtension(httpPostedFile.FileName);
                    uniqueName = Guid.NewGuid().ToString()+ext;
                    //You could modify the following code and get the postedfile inputstream, then insert them into database.
                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/images/gallery"), uniqueName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
                return Repository.updateUserProfilePic(uniqueName);
            }



            return ResponseResult.GetErrorObject();
        }

        public ResponseResult getUserRequests()
        {
            return Repository.getUserRequests();

        }



    }
}