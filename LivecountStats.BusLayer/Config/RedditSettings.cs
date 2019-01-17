using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Config
{
    public class RedditSettings : ConfigurationSection
    {
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return base["username"].ToString(); }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return base["password"].ToString(); }
        }

        [ConfigurationProperty("clientId", IsRequired = true)]
        public string ClientId
        {
            get { return base["clientId"].ToString(); }
        }

        [ConfigurationProperty("clientSecret", IsRequired = true)]
        public string ClientSecret
        {
            get { return base["clientSecret"].ToString(); }
        }

        [ConfigurationProperty("redirectUri", IsRequired = true)]
        public string RedirectUri
        {
            get { return base["redirectUri"].ToString(); }
        }

        [ConfigurationProperty("minimizeOnStart", IsRequired = false)]
        public bool MinimizeOnStart
        {
            get
            {
                var obj = base["minimizeOnStart"];
                if (obj == null)
                    return false;

                return Convert.ToBoolean(obj);
            }
        }

        public static RedditSettings Instance
        {
             get
            {
                var ccRoot =
                    ConfigurationManager.GetSection("redditsettings.config") as RedditSettings;

                return ccRoot;
            }
        }
    }
}
