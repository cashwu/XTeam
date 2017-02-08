using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FX.Configuration;
using XTeam.Service.Interface;

namespace XTeam.Service
{
    public class ConfigService : JsonConfiguration, IConfigService
    {
        public ConfigService() : base("~/Config/setting.json")
        {
        }

        public List<string> Accounts { get; private set; }
    }

}