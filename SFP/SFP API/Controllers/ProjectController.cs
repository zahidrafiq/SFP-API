using PUCIT.AIMRL.SFP.Entities;
using PUCIT.AIMRL.SFP.Entities.DBEntities;
using PUCIT.AIMRL.SFP.MainApp.Models;

using PUCIT.AIMRL.SFP.MainApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace PUCIT.AIMRL.SFP.MainApp.APIControllers
{
    public class ProjectController : BaseDataController
    {

        private readonly ProjectRepository _repository;

        public ProjectController()
        {
            _repository = new ProjectRepository();
        }
        private ProjectRepository Repository
        {
            get
            {
                return _repository;
            }
        }

       
        public class Vote
        {
            public int ProjectId { get; set; }
            public bool UpVote { get; set; }
            public bool DownVote { get; set; }
        }

        //====================================================================//
        [HttpPost]
        public ResponseResult ShareIdea(projectIdea proj)
        {
            try
            {
                Util.CustomUtility.LogData("Going to add new project idea:" + proj.ProjectTitle);
                return Repository.saveProject(proj);
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }
        }

          public  ResponseResult IdeaExist(Project proj)
        {
            try
            {
                Util.CustomUtility.LogData("Going to check weather user have already added project idea or not"+ proj.UserId);
                return Repository.IdeaExist(proj);
            }
            catch (Exception ex)
            {
                CustomUtility.HandleException(ex);
                return ResponseResult.GetErrorObject();
            }
        }

        //====================================================================//
        //[HttpPost]
        //public ResponseResult SaveRequest(projectIdea proj)
        //{
        //    try
        //    {
        //        Util.CustomUtility.LogData("Going to add new request of his project:" + proj.ProjectId);
        //        return Repository.SaveRequest(proj);
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomUtility.HandleException(ex);
        //        return ResponseResult.GetErrorObject();
        //    }

        //}

        //====================================================================//
        [HttpGet]
        public ResponseResult GetAllProjects()
        {
            var rv=Repository.GetProjects();
            return rv;
        }

        //====================================================================//
        [HttpPost]
        public ResponseResult SaveComment(Comments cmt)
        {
            return Repository.SaveComment(cmt);
        }

        //====================================================================//
        [HttpGet]
        public ResponseResult VoteProject(int ProjectId, bool UpVote, bool DownVote)
        {
            var result = Repository.Vote(ProjectId, UpVote, DownVote);
            return result;
        }

        //====================================================================//
        [HttpGet]
		public ResponseResult GetCommentByProjectId(int id,int count)
        {
            var rv = Repository.GetCommentsByProjectById(id,count);
            return ResponseResult.GetSuccessObject(rv.data);
            
        }
        //====================================================================//
        [HttpGet]
        public ResponseResult BidOnProject(int ProjectId)
        {
            var result = Repository.Bid(ProjectId);
            return result;
        }

        //====================================================================//
        [HttpGet]
        public ResponseResult GetProjectDetailsById(int ProjectId)
        {
            var rv = Repository.GetProjectDetailsById(ProjectId);
            return rv;
        }

        //====================================================================//



    }//End of controller
}//End of namespace
