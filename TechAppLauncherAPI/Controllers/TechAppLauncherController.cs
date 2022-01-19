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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public LauncherVersion GetLauncherVersion()
        {
            return _sqlDataAccess.GetLauncherVersion();
        }

        /// <summary>
        /// Retrieve the entire list of user download session.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAllUserDownloadSessions")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of records when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public IEnumerable<UserDownloadSession> GetAllUserDownloadSessions()
        {
            return _sqlDataAccess.GetUserDownloadSessions();
        }

        /// <summary>
        /// Retrive a download session by the user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSessionsByUsername/{userName}")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of records when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public IEnumerable<UserDownloadSession> GetUserDownloadSessionsByUserame(string userName)
        {
            return _sqlDataAccess.GetUserDownloadSessionsByUser(userName.Replace("_", "."));
        }

        /// <summary>
        /// Retrive a download session by the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSession/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public UserDownloadSession GetUserDownloadSession(long id)
        {
            return _sqlDataAccess.GetUserDownloadSessionById(id);
        }

        /// <summary>
        /// Retrive a download session by the session.
        /// </summary>
        /// <param name="userDownloadSession"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetUserDownloadSessionBySession")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public UserDownloadSession GetUserDownloadSessionBySession([FromUri] UserDownloadSession userDownloadSession)
        {
            return _sqlDataAccess.GetUserDownloadSession(userDownloadSession);
        }

        /// <summary>
        /// Insert a new record of user download session.
        /// </summary>
        /// <param name="userDownloadSession"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/TechAppLauncher/AddUserDownloadSession")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public UserDownloadSession AddUserDownloadSession([FromBody] UserDownloadSession userDownloadSession)
        {
            return _sqlDataAccess.AddUserDownloadSession(userDownloadSession);
        }

        /// <summary>
        /// Retrieve the hardcoded definition used by the launcher.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetlauncherAppConfig")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Error Occur!")]
        public AppConfig GetlauncherAppConfig()
        {
            return _sqlDataAccess.GetAppConfig();
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public LauncherVersion UpdateAppVerMajorNumber([FromBody] int majorVersionNumber)
        {
            if (majorVersionNumber < 0)
            {
                throw new Exception("Bad Request - Invalid Version number!");
            }

            return _sqlDataAccess.UpdateLauncherMajorNumber(majorVersionNumber);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public LauncherVersion UpdateAppVerMajorRevisionNumber([FromBody] int majorRevisionVersionNumber)
        {
            if (majorRevisionVersionNumber < 0)
            {
                throw new Exception("Bad Request - Invalid Version number!");
            }

            return _sqlDataAccess.UpdateLauncherMajorRevNumber(majorRevisionVersionNumber);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public LauncherVersion UpdateAppVerMinorNumber([FromBody] int minorVersionNumber)
        {
            if (minorVersionNumber < 0)
            {
                throw new Exception("Bad Request - Invalid Version number!");
            }

            return _sqlDataAccess.UpdateLauncherMinorNumber(minorVersionNumber);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public LauncherVersion UpdateAppVerMinorRevisionNumber([FromBody] int minorRevisionVersionNumber)
        {
            if (minorRevisionVersionNumber < 0)
            {
                throw new Exception("Bad Request - Invalid Version number!");
            }

            return _sqlDataAccess.UpdateLauncherMinorRevNumber(minorRevisionVersionNumber);
        }

        /// <summary>
        /// Update the connected server's domain name. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerDomainName")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public AppConfig UpdateAppStoreServerDomainName([FromBody] string domainName)
        {
            if (string.IsNullOrEmpty(domainName))
            {
                throw new Exception("Bad Request - Invalid Domain name!");
            }

            return _sqlDataAccess.UpdateServerDomainName(domainName);
        }

        /// <summary>
        /// Update the connected server's user name. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerUserName")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public AppConfig UpdateAppStoreServerUserName([FromBody] string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("Bad Request - Invalid Username!");
            }

            return _sqlDataAccess.UpdateServerUserName(userName);
        }

        /// <summary>
        /// Update the connected server's password. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch]
        [Route("api/TechAppLauncher/UpdateAppStoreServerPassword")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Bad Request - Invalid Data!")]
        public AppConfig UpdateAppStoreServerPassword([FromBody] string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Bad Request - Invalid Password!");
            }

            return _sqlDataAccess.UpdateServerPwd(password);
        }

        /// <summary>
        /// Retrieve the entire list of software which used others agent to install. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAllAppDistributionReferenceDetails")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the entire list of AppDistRefDet when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Error Occur!")]
        public IEnumerable<AppDistRefDet> GetAllAppDistributionReferenceDetails()
        {
            return _sqlDataAccess.GetAllAppDistRefDet();
        }

        /// <summary>
        /// Retrieve the software which used others agent to install by the AppUID. 
        /// </summary>
        /// <param name="appUID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TechAppLauncher/GetAppDistributionReferenceDetailByAppUID")]
        [SwaggerResponse(HttpStatusCode.OK, "Returns the specific record by the Id when success. Otherwise returns null.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Error Occur!")]
        public AppDistRefDet GetAppDistributionReferenceDetailByAppUID(string appUID)
        {
            return _sqlDataAccess.GetAppDistRefDetByAppUID(appUID);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Invalid Data!")]
        public AppDistRefDet UpdateAppDistributionReferenceDetailByAppUID([FromBody] AppDistRefDet appDistRefDet)
        {
            if (string.IsNullOrEmpty(appDistRefDet.AppUID) || string.IsNullOrWhiteSpace(appDistRefDet.AppUID))
            {
                throw new Exception("Bad Request - Invalid Data!");
            }

            return _sqlDataAccess.UpdateAppDistRefDetByAppUID(appDistRefDet);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Invalid Data!")]
        public AppDistRefDet UpdateAppDistributionReferenceDetailById([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || appDistRefDet.Id == 0)
            {
                throw new Exception("Bad Request - Invalid Data!");
            }

            return _sqlDataAccess.UpdateAppDistRefDetById(appDistRefDet);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Invalid Data!")]
        public AppDistRefDet AddAppDistributionReferenceDetail([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || 
                string.IsNullOrEmpty(appDistRefDet.AppUID.Trim()) || 
                string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()) ||
                string.IsNullOrEmpty(appDistRefDet.AgentName.Trim()))
            {
                throw new Exception("Bad Request - Invalid Data!");
            }

            return _sqlDataAccess.AddAppDistRefDet(appDistRefDet);
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
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Invalid Data!")]
        public IEnumerable<AppDistRefDet> DeleteAppDistributionReferenceDetail([FromBody] AppDistRefDet appDistRefDet)
        {
            if (appDistRefDet == null || 
                string.IsNullOrEmpty(appDistRefDet.AppUID.Trim()) ||
                string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()))
            {
                throw new Exception("Bad Request - Invalid Data!");
            }

            return _sqlDataAccess.DeleteAppDistRefDet(appDistRefDet);
        }
    }
}
