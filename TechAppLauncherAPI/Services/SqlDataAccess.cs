using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TechAppLauncherAPI.Models;

namespace TechAppLauncherAPI.Services
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private string _connectionString = "";

        public SqlDataAccess()
        {
            _connectionString = "Server=" + @"10.14.162.74" + "; " +
                    "DataBase=" + "TechAppLauncher_2021" + "; " +
                    "user id=" + "techapplauncher" + ";" +
                    "password=" + "SZ@ADout05042021";
        }

        public List<UserDownloadSession> GetUserDownloadSessions()
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM UserDownloadSession ORDER BY InstallTimeStamp DESC";

            List<UserDownloadSession> userDownloadSessions = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    userDownloadSessions = new List<UserDownloadSession>();

                    while (Reader.Read())
                    {
                        userDownloadSessions.Add(new UserDownloadSession
                        {
                            Id = Reader.GetInt64(0),
                            AppId = Reader.IsDBNull(1) ? 0 : Reader.GetInt64(1),
                            AppUID = Reader.GetString(2),
                            Title = Reader.IsDBNull(3) ? "" : Reader.GetString(3),
                            Status = Reader.IsDBNull(4) ? "" : Reader.GetString(4),
                            UserName = Reader.GetString(5),
                            InstallTimeStamp = Reader.GetDateTime(6),
                            Remark = Reader.IsDBNull(7) ? "" : Reader.GetString(7)
                        });
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSessions;
        }

        public List<UserDownloadSession> GetUserDownloadSessionsByUser(string userName)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM UserDownloadSession WHERE UserName=@UserName ORDER BY InstallTimeStamp DESC";

            List<UserDownloadSession> userDownloadSessions = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@UserName", userName);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    userDownloadSessions = new List<UserDownloadSession>();

                    while (Reader.Read())
                    {
                        userDownloadSessions.Add(new UserDownloadSession
                        {
                            Id = Reader.GetInt64(0),
                            AppId = Reader.IsDBNull(1) ? 0 : Reader.GetInt64(1),
                            AppUID = Reader.GetString(2),
                            Title = Reader.IsDBNull(3) ? "" : Reader.GetString(3),
                            Status = Reader.IsDBNull(4) ? "" : Reader.GetString(4),
                            UserName = Reader.GetString(5),
                            InstallTimeStamp = Reader.GetDateTime(6),
                            Remark = Reader.IsDBNull(7) ? "" : Reader.GetString(7)
                        });
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSessions;
        }

        public UserDownloadSession GetUserDownloadSessionById(long id)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM UserDownloadSession WHERE Id=@Id";

            UserDownloadSession userDownloadSession = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@Id", id);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    userDownloadSession = new UserDownloadSession();

                    while (Reader.Read())
                    {
                        userDownloadSession = new UserDownloadSession()
                        {
                            Id = Reader.GetInt64(0),
                            AppId = Reader.IsDBNull(1) ? 0 : Reader.GetInt64(1),
                            AppUID = Reader.GetString(2),
                            Title = Reader.IsDBNull(3) ? "" : Reader.GetString(3),
                            Status = Reader.IsDBNull(4) ? "" : Reader.GetString(4),
                            UserName = Reader.GetString(5),
                            InstallTimeStamp = Reader.GetDateTime(6),
                            Remark = Reader.IsDBNull(7) ? "" : Reader.GetString(7)
                        };
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSession;
        }

        public UserDownloadSession GetUserDownloadSession(UserDownloadSession userDownloadSession)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM UserDownloadSession WHERE AppUID=@AppUID AND UserName=@UserName AND InstallTimeStamp=@InstallTimeStamp";

            UserDownloadSession userDownloadSessionFromDB = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppUID", userDownloadSession.AppUID);
                _qrycmd.Parameters.AddWithValue("@UserName", userDownloadSession.UserName);
                _qrycmd.Parameters.AddWithValue("@InstallTimeStamp", userDownloadSession.InstallTimeStamp);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    userDownloadSessionFromDB = new UserDownloadSession();

                    while (Reader.Read())
                    {
                        userDownloadSessionFromDB = new UserDownloadSession()
                        {
                            Id = Reader.GetInt64(0),
                            AppId = Reader.IsDBNull(1) ? 0 : Reader.GetInt64(1),
                            AppUID = Reader.GetString(2),
                            Title = Reader.IsDBNull(3) ? "" : Reader.GetString(3),
                            Status = Reader.IsDBNull(4) ? "" : Reader.GetString(4),
                            UserName = Reader.GetString(5),
                            InstallTimeStamp = Reader.GetDateTime(6),
                            Remark = Reader.IsDBNull(7) ? "" : Reader.GetString(7)
                        };
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSessionFromDB;
        }

        public UserDownloadSession AddUserDownloadSession(UserDownloadSession userDownloadSession)
        {
            int _ret = 0;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "INSERT INTO UserDownloadSession VALUES (@AppId, @AppUID, @Title, @Status, @UserName, @InstallTimeStamp, @Remark)";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppId", userDownloadSession.AppId);
                _qrycmd.Parameters.AddWithValue("@AppUID", userDownloadSession.AppUID);
                _qrycmd.Parameters.AddWithValue("@Title", userDownloadSession.Title);
                _qrycmd.Parameters.AddWithValue("@Status", userDownloadSession.Status);
                _qrycmd.Parameters.AddWithValue("@UserName", userDownloadSession.UserName);
                _qrycmd.Parameters.AddWithValue("@InstallTimeStamp", userDownloadSession.InstallTimeStamp);
                _qrycmd.Parameters.AddWithValue("@Remark", userDownloadSession.Remark);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    userDownloadSession = GetUserDownloadSession(userDownloadSession);
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return userDownloadSession;
        }

        public LauncherVersion GetLauncherVersion()
        {
            var appConfig = GetAppConfig();
            if (appConfig != null)
            {
                return new LauncherVersion(appConfig.LauncherVerMajor, appConfig.LauncherVerMajorRev, appConfig.LauncherVerMinor, appConfig.LauncherVerMinorRev);
            }
            else
            {
                return new LauncherVersion();
            }
        }

        public AppConfig GetAppConfig()
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM AppConfig WHERE Id=1";

            AppConfig appConfig = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    appConfig = new AppConfig();

                    while (Reader.Read())
                    {
                        appConfig = new AppConfig()
                        {
                            Id = Reader.GetInt64(0),
                            LauncherVerMajor = Reader.IsDBNull(1) ? 0 : Reader.GetInt32(1),
                            LauncherVerMajorRev = Reader.IsDBNull(2) ? 0 : Reader.GetInt32(2),
                            LauncherVerMinor = Reader.IsDBNull(3) ? 0 : Reader.GetInt32(3),
                            LauncherVerMinorRev = Reader.IsDBNull(4) ? 0 : Reader.GetInt32(4),
                            AppStoreServerDomain = Reader.IsDBNull(5) ? "" : Reader.GetString(5),
                            AppStoreServerUser = Reader.IsDBNull(6) ? "" : Reader.GetString(6),
                            AppStoreServerPwd = Reader.IsDBNull(7) ? "" : Reader.GetString(7),
                            LauncherInfo = Reader.IsDBNull(8) ? "" : Reader.GetString(8)
                        };
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return appConfig;
        }

        public LauncherVersion UpdateLauncherMajorNumber(int major)
        {
            int _ret = 0;
            LauncherVersion launcherVersion = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET LauncherVerMajor=@LauncherVerMajor WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@LauncherVerMajor", major);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    launcherVersion = GetLauncherVersion();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return launcherVersion;
        }

        public LauncherVersion UpdateLauncherMajorRevNumber(int majorRev)
        {
            int _ret = 0;
            LauncherVersion launcherVersion = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET LauncherVerMajorRev=@LauncherVerMajorRev WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@LauncherVerMajorRev", majorRev);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    launcherVersion = GetLauncherVersion();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return launcherVersion;
        }

        public LauncherVersion UpdateLauncherMinorNumber(int minor)
        {
            int _ret = 0;
            LauncherVersion launcherVersion = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET LauncherVerMinor=@LauncherVerMinor WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@LauncherVerMinor", minor);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    launcherVersion = GetLauncherVersion();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return launcherVersion;
        }

        public LauncherVersion UpdateLauncherMinorRevNumber(int minorRev)
        {
            int _ret = 0;
            LauncherVersion launcherVersion = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET LauncherVerMinorRev=@LauncherVerMinorRev WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@LauncherVerMinorRev", minorRev);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    launcherVersion = GetLauncherVersion();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return launcherVersion;
        }

        public AppConfig UpdateServerDomainName(string domainName)
        {
            int _ret = 0;
            AppConfig appConfig = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET AppStoreServerDomain=@AppStoreServerDomain WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppStoreServerDomain", domainName);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    appConfig = GetAppConfig();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return appConfig;
        }

        public AppConfig UpdateServerUserName(string userName)
        {
            int _ret = 0;
            AppConfig appConfig = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET AppStoreServerUser=@AppStoreServerUser WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppStoreServerUser", userName);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    appConfig = GetAppConfig();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return appConfig;
        }

        public AppConfig UpdateServerPwd(string password)
        {
            int _ret = 0;
            AppConfig appConfig = null;

            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "UPDATE AppConfig SET AppStoreServerPwd=@AppStoreServerPwd WHERE Id=1";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppStoreServerPwd", password);

                SqlDataReader Reader = _qrycmd.ExecuteReader();
                _ret = Reader.RecordsAffected;

                if (_ret > 0)
                {
                    appConfig = GetAppConfig();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
            finally
            {
                dbConnection.Close();
            }

            return appConfig;
        }

        public List<AppDistRefDet> GetAllAppDistRefDet()
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM AppDistRefDet ORDER BY AppUID";

            List<AppDistRefDet> appDistRefDets = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                //_qrycmd.ExecuteNonQuery();

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    appDistRefDets = new List<AppDistRefDet>();

                    while (Reader.Read())
                    {
                        appDistRefDets.Add(new AppDistRefDet
                        {
                            Id = Reader.GetInt64(0),
                            AppUID = Reader.GetString(1),
                            LinkID = Reader.GetString(2),
                            AgentName = Reader.GetString(3),
                            Description = Reader.IsDBNull(4) ? "" : Reader.GetString(4)
                        });
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDets = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDets;
        }

        public AppDistRefDet GetAppDistRefDetByAppUID(string appUID)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = $"SELECT * FROM AppDistRefDet WHERE AppUID=@AppUID";

            AppDistRefDet appDistRefDet = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppUID", appUID);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    appDistRefDet = new AppDistRefDet();

                    while (Reader.Read())
                    {
                        appDistRefDet = new AppDistRefDet()
                        {
                            Id = Reader.GetInt64(0),
                            AppUID = Reader.GetString(1),
                            LinkID = Reader.GetString(2),
                            AgentName = Reader.GetString(3),
                            Description = Reader.IsDBNull(4) ? "" : Reader.GetString(4)
                        };
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDet = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDet;
        }

        public AppDistRefDet GetAppDistRefDetById(long Id)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            string _qry = "SELECT * FROM AppDistRefDet WHERE Id=@Id";

            AppDistRefDet appDistRefDet = null;

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    appDistRefDet = new AppDistRefDet();

                    while (Reader.Read())
                    {
                        appDistRefDet = new AppDistRefDet()
                        {
                            Id = Reader.GetInt64(0),
                            AppUID = Reader.GetString(1),
                            LinkID = Reader.GetString(2),
                            AgentName = Reader.GetString(3),
                            Description = Reader.IsDBNull(4) ? "" : Reader.GetString(4)
                        };
                    }
                }

            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDet = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDet;
        }

        public AppDistRefDet UpdateAppDistRefDetByAppUID(AppDistRefDet appDistRefDet)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            var appDistRefDetOrg = GetAppDistRefDetByAppUID(appDistRefDet.AppUID);

            if (appDistRefDetOrg == null)
            {
                return null;
            }

            string _qry = $"UPDATE AppDistRefDet ";
            _qry += "SET LinkID=@LinkID, ";
            _qry += "AgentName=@AgentName, ";
            _qry += "Description=@Description ";
            _qry += "WHERE AppUID=@AppUID";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@LinkID", (string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()) ? appDistRefDetOrg.LinkID : appDistRefDet.LinkID.Trim()));
                _qrycmd.Parameters.AddWithValue("@AgentName", (string.IsNullOrEmpty(appDistRefDet.AgentName.Trim()) ? appDistRefDetOrg.AgentName : appDistRefDet.AgentName.Trim().ToLower()));
                _qrycmd.Parameters.AddWithValue("@Description", (string.IsNullOrEmpty(appDistRefDet.Description.Trim()) ? appDistRefDetOrg.Description : appDistRefDet.Description.Trim()));
                _qrycmd.Parameters.AddWithValue("@AppUID", appDistRefDet.AppUID);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.RecordsAffected > 0)
                {
                    appDistRefDet = GetAppDistRefDetByAppUID(appDistRefDetOrg.AppUID);
                }
                else
                {
                    appDistRefDet = null;
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDet = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDet;
        }

        public AppDistRefDet UpdateAppDistRefDetById(AppDistRefDet appDistRefDet)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);
            var appDistRefDetOrg = GetAppDistRefDetById(appDistRefDet.Id);

            if (appDistRefDetOrg == null)
            {
                return null;
            }

            string _qry = $"UPDATE AppDistRefDet ";
            _qry += "SET AppUID=@AppUID, ";
            _qry += "LinkID=@LinkID, ";
            _qry += "AgentName=@AgentName, ";
            _qry += "Description=@Description ";
            _qry += "WHERE Id=@Id";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppUID", (string.IsNullOrEmpty(appDistRefDet.AppUID.Trim()) ? appDistRefDetOrg.AppUID : appDistRefDet.AppUID.Trim()));
                _qrycmd.Parameters.AddWithValue("@LinkID", (string.IsNullOrEmpty(appDistRefDet.LinkID.Trim()) ? appDistRefDetOrg.LinkID : appDistRefDet.LinkID.Trim()));
                _qrycmd.Parameters.AddWithValue("@AgentName", (string.IsNullOrEmpty(appDistRefDet.AgentName.Trim()) ? appDistRefDetOrg.AgentName : appDistRefDet.AgentName.Trim().ToLower()));
                _qrycmd.Parameters.AddWithValue("@Description", (string.IsNullOrEmpty(appDistRefDet.Description.Trim()) ? appDistRefDetOrg.Description : appDistRefDet.Description.Trim()));
                _qrycmd.Parameters.AddWithValue("@Id", appDistRefDet.Id);

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.RecordsAffected > 0)
                {
                    appDistRefDet = GetAppDistRefDetById(appDistRefDetOrg.Id);
                }
                else
                {
                    appDistRefDet = null;
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDet = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDet;
        }

        public AppDistRefDet AddAppDistRefDet(AppDistRefDet appDistRefDet)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);

            string _qry = $"INSERT INTO AppDistRefDet VALUES (";
            _qry += "@AppUID, ";
            _qry += "@LinkID, ";
            _qry += "@AgentName, ";
            _qry += "@Description) ";


            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppUID", appDistRefDet.AppUID.Trim());
                _qrycmd.Parameters.AddWithValue("@LinkID", appDistRefDet.LinkID.Trim());
                _qrycmd.Parameters.AddWithValue("@AgentName", appDistRefDet.AgentName.Trim().ToLower());
                _qrycmd.Parameters.AddWithValue("@Description", appDistRefDet.Description.Trim());

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.RecordsAffected > 0)
                {
                    appDistRefDet = GetAppDistRefDetByAppUID(appDistRefDet.AppUID);
                }
                else
                {
                    appDistRefDet = null;
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDet = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDet;
        }

        public List<AppDistRefDet> DeleteAppDistRefDet(AppDistRefDet appDistRefDet)
        {
            SqlConnection dbConnection = new SqlConnection(_connectionString);

            string _qry = $"DELETE AppDistRefDet ";
            _qry += "WHERE AppUID=@AppUID AND LinkID=@LinkID";

            List<AppDistRefDet> appDistRefDets = null; 

            try
            {
                dbConnection.Open();
                SqlCommand _qrycmd = new SqlCommand(_qry, dbConnection);
                _qrycmd.CommandText = _qry;
                _qrycmd.Parameters.AddWithValue("@AppUID", appDistRefDet.AppUID.Trim());
                _qrycmd.Parameters.AddWithValue("@LinkID", appDistRefDet.LinkID.Trim());

                SqlDataReader Reader = _qrycmd.ExecuteReader();

                if (Reader.RecordsAffected > 0)
                {
                    appDistRefDets = GetAllAppDistRefDet();
                }
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                appDistRefDets = null;
            }
            finally
            {
                dbConnection.Close();
            }

            return appDistRefDets;
        }
    }
}