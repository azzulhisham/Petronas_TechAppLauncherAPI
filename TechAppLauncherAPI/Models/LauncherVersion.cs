using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechAppLauncherAPI.Models
{
    public class LauncherVersion
    {
        public int Major { get; set; }
        public int MajorRevision { get; set; }
        public int Minor { get; set; }
        public int MinorRevision { get; set; }

        public new string ToString() => $"{Major}.{MajorRevision}.{Minor}.{MinorRevision}";

        public LauncherVersion()
        {
            Major = 1;
            MajorRevision = 0;
            Minor = 1;
            MinorRevision = 6;
        }

        public LauncherVersion(int major, int majorRevision, int minor, int minorRevision)
        {
            Major = major;
            MajorRevision = majorRevision;
            Minor = minor;
            MinorRevision = minorRevision;
        }
    }
}