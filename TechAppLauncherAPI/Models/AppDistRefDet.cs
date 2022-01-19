using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechAppLauncherAPI.Models
{
    public class AppDistRefDet
    {
        public long Id { get; set; }
        public string AppUID { get; set; }
        public string LinkID { get; set; }
        public string AgentName { get; set; }
        public string Description { get; set; }
    }
}