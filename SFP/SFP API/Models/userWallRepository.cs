using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Collections;
using PUCIT.AIMRL.SFP.DAL;
using PUCIT.AIMRL.SFP.MainApp.Util;
using PUCIT.AIMRL.SFP.UI.Common;
using PUCIT.AIMRL.SFP.Entities.Security;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.MainApp.Security;
using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.Common;

namespace PUCIT.AIMRL.SFP.MainApp.Models
{
    public class userWallRepository
    {
        private PRMDataService _dataService;
        
        private PRMDataService DataService
        {
            get
            {
                if (_dataService == null)
                    _dataService = new PRMDataService();

                return _dataService;
            }
        }

        public ResponseResult getUserInfo(int UserId)
        {
            try
            {
                User StudentObject = DataService.getUserInfo(UserId);
                //Section UserSection = DataService.getUserSection(StudentObject.UserId);

                return ResponseResult.GetSuccessObject(new
                {
                    StudentInfo = StudentObject
                });

                //return (new
                //{
                //    data = new
                //    {
                //        StudentInfo = StudentObject
                //    },
                //    success = true,
                //    error = ""
                //});
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }

        }

        public ResponseResult updateUserProfilePic(string fileName)
        {
            try
            {
                return DataService.updateUserProfilePic(fileName);

            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
                //return ResponseResult.GetErrorObject("Some error has occured in While showing User Projects Wall.");
            }
        }

        public ResponseResult GetProjectsByUserId(int UserId)
        {
            try
            {
                List<ProjectDTO> listOfUserProjects = DataService.GetProjectsByUserId(UserId);
                return ResponseResult.GetSuccessObject(new
                {
                    ProjectList = listOfUserProjects
                });

            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject("Some error has occured in While showing User Projects Wall.");
            }
        }
        public ResponseResult updateUserProfile(EditUser u)
        {
            String msg;
            try
            {

                int isUpdated = DataService.updateUserProfile(u);
                if (isUpdated == 1)
                {
                    msg = "User Updated Successfully";
                    return ResponseResult.GetSuccessObject(new
                    {
                        IsUpdated = isUpdated
                    }, msg);

                }
                else
                {
                    msg = "User didn't updated successfully";
                    return ResponseResult.GetErrorObject(msg);
                }
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject("User didn't updated successfully");
            }

        }

        public ResponseResult getUserRequests()
        {
            
            return  ResponseResult.GetSuccessObject(new
            {
                Requests = DataService.getUserRequests()
            });
        }
    }
}