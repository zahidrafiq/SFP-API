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
    public class ProjectRepository
    {
        private PRMDataService _dataService;
        public ProjectRepository()
        {
        }

        private PRMDataService DataService
        {
            get
            {
                if (_dataService == null)
                    _dataService = new PRMDataService ();

                return _dataService;
            }
        }
        public ResponseResult saveProject(projectIdea proj)
        {
            try
            {
                
                List<int> ids = new List<int>();
               
                proj.IsActive = true;
               // proj.PictureName = "mounatin.jpg";
                proj.CreatedOn = DateTime.UtcNow;
                proj.ModifiedOn = DateTime.UtcNow;
                proj.ProjectState = 2;
                //proj.PictureName = "ABC";
                String msg;
                var ProjectID = DataService.SaveProjectIdea(proj, SessionManager.CurrentUser.UserId);
                ids.Add(ProjectID);
                
                if (ProjectID > 0)
                {
                    if (proj.MemberList.Count > 0 )
                     {
                        Request res = new Request();
                        res.ProjectId = ProjectID;
                        res.RequestBody = "I want to do my final year project with you.";
                        res.Status = 0;
                        res.Type = "AddStudent";
                        res.SendBy = SessionManager.CurrentUser.UserId;
                        res.CreatedOn = DateTime.UtcNow;
                        var RequestID = DataService.RequestHandling(res,proj.MemberList);
                        ids.Add(RequestID);
                        if (proj.SectionList.Count > 0)
                        {
                            Notification not = new Notification();
                            not.NotificationBody = "you can bid on this idea";
                            not.Title = "bid";
                            not.CreatedOn = DateTime.UtcNow;
                            not.ProjectId = ProjectID;
                            not.SendBy= SessionManager.CurrentUser.UserId;
                            var NotificationID = DataService.NotificationHandling(not,proj.SectionList);
                            ids.Add(NotificationID);
                        }
                          
                    }
                    if (proj.ProjectId > 0)
                    {
                        msg = "Idea is updated Successfully";
                    }
                    else
                    {
                        msg = "Idea is Initiated Successfully";
                    }
                    return ResponseResult.GetSuccessObject(new
                    {
                        result = ids,
                    }, 
                    msg);
                }
                else
                {
                    return ResponseResult.GetErrorObject();
                }
            } 
            // end of try block
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }
        } 
        //end of function


        public ResponseResult Bid(int ProjectId)
        {
            int UserId = SessionManager.CurrentUser.UserId;
            int result = DataService.SaveBid(UserId, ProjectId);
            return ResponseResult.GetSuccessObject(new
            {
                ResultCode = result,
            });
        }
        public ResponseResult GetCommentsByProjectById(int id,int count)
        {
            try
            {
                List<ProjectComments> list = DataService.GetCommentByProjectId(id,count);
                return ResponseResult.GetSuccessObject(new
                {
                    Comments = list
                });
            }
            catch(Exception exp)
            {
                CustomUtility.HandleException(exp);
                return ResponseResult.GetErrorObject("Some error has occured in ProjectRepository");
            }
        }
        
        public ResponseResult GetProjects()
        {
            try
            {
                List<ProjectDTO> list = DataService.GetAllProjects ();
                return ResponseResult.GetSuccessObject ( new
                {
                    ProjectList = list
                });
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException ( ex );
                return ResponseResult.GetErrorObject ( "Some error has occured in ProjectRepository" );
            }
        }
    //============================================================//
        public ResponseResult GetProjectDetailsById(int pid)
        {
            return DataService.GetProjectDetailsById(pid);
        }

    //============================================================//
        public ResponseResult Vote(int ProjectId, bool UpVote, bool DownVote)
        {
            //String msg;
            try
            {
                var result = DataService.Vote(ProjectId, UpVote, DownVote, SessionManager.CurrentUser.UserId);
                // return result;
                return ResponseResult.GetSuccessObject(new
                {
                    ResultCode = result,
                });

            }
            catch(Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }          
        }
       

        public ResponseResult SaveComment(Comments cmt)
        {
            cmt.UserId=SessionManager.CurrentUser.UserId;
            return DataService.SaveComment(cmt);
        }
        public ResponseResult IdeaExist(Project proj)
        {

            String msg;
            try
            {
                var result = DataService.CheckIdeaExist(proj.UserId);
                if (result > 0)
                {
                    msg = "you have already initiated a idea!";

                    return ResponseResult.GetSuccessObject(new
                       {
                           ProjectId = result,
                       },
                       msg);
                }
                else
                {
                    return ResponseResult.GetErrorObject();
                }

            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            } 
        }


     }//end of class
}//end of namespace