using System.Collections.Generic;
using TechAppLauncherAPI.Models;

namespace TechAppLauncherAPI.Services
{
    public interface ISqlDataAccess
    {
        UserDownloadSession AddUserDownloadSession(UserDownloadSession userDownloadSession);
        AppConfig GetAppConfig();
        LauncherVersion GetLauncherVersion();
        UserDownloadSession GetUserDownloadSession(UserDownloadSession userDownloadSession);
        UserDownloadSession GetUserDownloadSessionById(long id);
        List<UserDownloadSession> GetUserDownloadSessions();
        List<UserDownloadSession> GetUserDownloadSessionsByUser(string userName);
        LauncherVersion UpdateLauncherMajorNumber(int major);
        LauncherVersion UpdateLauncherMajorRevNumber(int majorRev);
        LauncherVersion UpdateLauncherMinorNumber(int minor);
        LauncherVersion UpdateLauncherMinorRevNumber(int minorRev);
        AppConfig UpdateServerDomainName(string domainName);
        AppConfig UpdateServerPwd(string password);
        AppConfig UpdateServerUserName(string userName);
        List<AppDistRefDet> GetAllAppDistRefDet();
        AppDistRefDet GetAppDistRefDetByAppUID(string appUID);
        AppDistRefDet GetAppDistRefDetById(long Id);
        AppDistRefDet UpdateAppDistRefDetByAppUID(AppDistRefDet appDistRefDet);
        AppDistRefDet UpdateAppDistRefDetById(AppDistRefDet appDistRefDet);
        AppDistRefDet AddAppDistRefDet(AppDistRefDet appDistRefDet);
        List<AppDistRefDet> DeleteAppDistRefDet(AppDistRefDet appDistRefDet);
    }
}