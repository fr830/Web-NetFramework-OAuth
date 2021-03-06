﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Helpers;

namespace Web_NetFramework.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取AccesstokenToken示例
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<ActionResult> GetAccessToken()
        {
            MsalAuthProvider authProvider = MsalAuthProvider.Instance;
            try
            {
                var accesstoken = await authProvider.GetUserAccesstokenAsync();
                ViewBag.AccessToken = accesstoken;
                return View("Index");
            }
            catch (ServiceException ex)
            {
                if (ex.Error.Message == App_Resources.Resource.Error_AuthChallengeNeeded)
                {
                    return new EmptyResult();
                }
                return RedirectToAction("Index","Error",new { message = App_Resources.Resource.Error_Message + Request.RawUrl + ": " + ex.Error.Message });
            }
        }
    }
}