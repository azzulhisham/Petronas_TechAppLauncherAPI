using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechAppLauncherAPI.Models
{
    public class AppConfig
    {
        public long Id { get; set; }
        public int LauncherVerMajor { get; set; }
        public int LauncherVerMajorRev { get; set; }
        public int LauncherVerMinor { get; set; }
        public int LauncherVerMinorRev { get; set; }
        public string AppStoreServerDomain { get; set; }
        public string AppStoreServerUser { get; set; }
        public string AppStoreServerPwd { get; set; }
        public string LauncherInfo { get; set; }
    }
}