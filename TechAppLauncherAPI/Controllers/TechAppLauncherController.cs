using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechAppLauncherAPI.Models;
using TechAppLauncherAPI.Services;

namespace TechAppLauncherAPI.Controllers
{
    /// <summary>
    /// http://10.14.161.44/TechAppLauncherAPI/swagger/ui/index
    /// </summary>
    public class TechAppLauncherController : ApiController
    {
        private ISqlDataAccess _sqlDataAccess;


        public TechAppLauncherController()
        {
            _sqlDataAccess = new SqlDataAccess();
        }

        /// <summary>
        /// Get the minimum Launcher version number that the client should have.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetLauncherVersion")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetLauncherVersion()
        {
            var result = _sqlDataAccess.GetLauncherVersion();
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Retrieve the entire list of user download session.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAllUserDownloadSessions")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of records when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetAllUserDownloadSessions()
        {
            var result = _sqlDataAccess.GetUserDownloadSessions();
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Retrive a download session by the user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSessionsByUsername/{userName}")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of records when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetUserDownloadSessionsByUserame(string userName)
        {
            var result = _sqlDataAccess.GetUserDownloadSessionsByUser(userName.Replace("_", "."));
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Retrive a download session by the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSession/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetUserDownloadSession(long id)
        {
            var result = _sqlDataAccess.GetUserDownloadSessionById(id);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Retrive a download session by the session.
        /// </summary>
        /// <param name="userDownloadSession"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSessionBySession")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetUserDownloadSessionBySession([FromUri] UserDownloadSession userDownloadSession)
        {
            var result = _sqlDataAccess.GetUserDownloadSession(userDownloadSession);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Insert a new record of user download session.
        /// </summary>
        /// <param name="userDownloadSession"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/TechAppLauncher/AddUserDownloadSession")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage AddUserDownloadSession([FromBody] UserDownloadSession userDownloadSession)
        {
            if (string.IsNullOrEmpty(userDownloadSession.AppUID.Trim()) || 
                string.IsNullOrEmpty(userDownloadSession.Title.Trim()) ||
                string.IsNullOrEmpty(userDownloadSession.UserName.Trim()))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
            }

            var result = _sqlDataAccess.AddUserDownloadSession(userDownloadSession);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Retrieve the hardcoded definition used by the launcher.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetlauncherAppConfig")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetlauncherAppConfig()
        {
            var result = _sqlDataAccess.GetAppConfig();
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Update the launcher version number - major
        /// </summary>
        /// <param name="majorVersionNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppVerMajorNumber")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppVerMajorNumber([FromBody] int majorVersionNumber)
        {
            if (majorVersionNumber < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Version number!");
            }

            var result = _sqlDataAccess.UpdateLauncherMajorNumber(majorVersionNumber);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the launcher version number - major revision
        /// </summary>
        /// <param name="majorRevisionVersionNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppVerMajorRevisionNumber")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppVerMajorRevisionNumber([FromBody] int majorRevisionVersionNumber)
        {
            if (majorRevisionVersionNumber < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Invalid Version number!");
            }

            var result = _sqlDataAccess.UpdateLauncherMajorRevNumber(majorRevisionVersionNumber);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the launcher version number - minor
        /// </summary>
        /// <param name="minorVersionNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppVerMinorNumber")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppVerMinorNumber([FromBody] int minorVersionNumber)
        {
            if (minorVersionNumber < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Version number!");
            }

            var result = _sqlDataAccess.UpdateLauncherMinorNumber(minorVersionNumber);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the launcher version number - minor revision
        /// </summary>
        /// <param name="minorRevisionVersionNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppVerMinorRevisionNumber")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppVerMinorRevisionNumber([FromBody] int minorRevisionVersionNumber)
        {
            if (minorRevisionVersionNumber < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Version number!");
            }

            var result = _sqlDataAccess.UpdateLauncherMinorRevNumber(minorRevisionVersionNumber);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the connected server's domain name. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerDomainName")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppStoreServerDomainName([FromBody] string domainName)
        {
            if (string.IsNullOrEmpty(domainName))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Domain name!");
            }

            var result = _sqlDataAccess.UpdateServerDomainName(domainName);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the connected server's user name. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerUserName")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppStoreServerUserName([FromBody] string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Username!");
            }

            var result = _sqlDataAccess.UpdateServerUserName(userName);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the connected server's password. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerPassword")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppStoreServerPassword([FromBody] string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Password!");
            }

            var result = _sqlDataAccess.UpdateServerPwd(password);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Retrieve the entire list of software which used others agent to install. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAllAppDistributionReferenceDetails")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the entire list of AppDistRefDet when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetAllAppDistributionReferenceDetails()
        {
            var result = _sqlDataAccess.GetAllAppDistRefDet();
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Retrieve the software which used others agent to install by the AppUID. 
        /// </summary>
        /// <param name="appUID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAppDistributionReferenceDetailByAppUID")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record by the Id when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No data available!")]
        public HttpResponseMessage GetAppDistributionReferenceDetailByAppUID(string appUID)
        {
            var result = _sqlDataAccess.GetAppDistRefDetByAppUID(appUID);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.NotFound, "No data available!");
        }

        /// <summary>
        /// Update the software which used others agent to install by the AppUID. 
        /// </summary>
        /// <param name="appDistRefDet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppDistributionReferenceDetailByAppUID")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record by the AppUID when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppDistributionReferenceDetailByAppUID([FromBody] AppDistRefDet appDistRefDet)
        {
            if (string.IsNullOrEmpty(appDistRefDet.AppUID) || string.IsNullOrWhiteSpace(appDistRefDet.AppUID))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid AppUID!");
            }

            var result = _sqlDataAccess.UpdateAppDistRefDetByAppUID(appDistRefDet);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Update the software which used others agent to install by the Id. 
        /// </summary>
        /// <param name="appDistRefDet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppDistributionReferenceDetailById")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record by the Id when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage UpdateAppDistributionReferenceDetailById([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || appDistRefDet.Id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Id!");
            }

            var result = _sqlDataAccess.UpdateAppDistRefDetById(appDistRefDet);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Add a new software which used others agent to install. 
        /// </summary>
        /// <param name="appDistRefDet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("api/TechAppLauncher/AddAppDistributionReferenceDetail")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage AddAppDistributionReferenceDetail([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || 
                string.IsNullOrEmpty(appDistRefDet.AppUID.Trim()) || 
                string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()) ||
                string.IsNullOrEmpty(appDistRefDet.AgentName.Trim()))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Data!");
            }

            var result = _sqlDataAccess.AddAppDistRefDet(appDistRefDet);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }

        /// <summary>
        /// Delete a software that used others agent to install.
        /// </summary>
        /// <param name="appDistRefDet"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete]
        [Route("api/TechAppLauncher/DeleteAppDistributionReferenceDetail")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the entire list of the table when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid Data!")]
        public HttpResponseMessage DeleteAppDistributionReferenceDetail([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || 
                string.IsNullOrEmpty(appDistRefDet.AppUID.Trim()) ||
                string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Data!");
            }

            var result = _sqlDataAccess.DeleteAppDistRefDet(appDistRefDet);
            return result != null ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data!");
        }
    }
}
