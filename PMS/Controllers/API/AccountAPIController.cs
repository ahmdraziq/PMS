﻿using PMS.Models;
using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PMS.Controllers.API
{
    public class AccountAPIController : ApiController
    {
        [HttpPost]
        public IHttpActionResult UploadProfilePic()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                string fl = file.FileName;
                AzureBlob BlobManagerObj = new AzureBlob(1);
                string FileName = BlobManagerObj.UploadFileAPI(file, UserAuthentication.Identity().id.ToString());
                FileName = FileName.Substring(FileName.IndexOf('/') + 1);

                photogEntities db = new photogEntities();
                var id = UserAuthentication.Identity().id;
                var user = db.Users.FirstOrDefault(x => x.id == id);
                user.imgprofile = FileName;
                db.SaveChanges();

                UserAuthentication.UpdateClaim();

                return Ok(FileName);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProfilePic()
        {

            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                string fl = file.FileName;
                if (file.FileName == UserAuthentication.Identity().imgprofile) return Ok();               
            }

            else
            {
                AzureBlob BlobManagerObj = new AzureBlob(1);
                photogEntities db = new photogEntities();
                var id = UserAuthentication.Identity().id;
                var user = db.Users.FirstOrDefault(x => x.id == id);

                if (user.imgprofile == null) return Ok();

                else if (!string.IsNullOrWhiteSpace(BlobManagerObj.DeleteBlob(user.id.ToString(), User.Identity.GetProfilePhotoLink())))
                {                   
                    user.imgprofile = null;
                    db.SaveChanges();

                    UserAuthentication.UpdateClaim();

                    return Ok();
                }
            }
            return BadRequest();

        }


    }
}
