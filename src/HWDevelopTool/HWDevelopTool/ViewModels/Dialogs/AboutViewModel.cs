using HWDevelopTool.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWDevelopTool.ViewModels.Dialogs
{
    internal class AboutViewModel : ViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string SoftwareVersion { get; private set; } = string.Empty;
        public string CopyrightDate { get; private set; } = string.Empty;
        public string Website { get; private set; } = string.Empty;
        public string LicenseInfo { get; private set; } = string.Empty;
        public string DeveloperName { get; private set; } = string.Empty;

        public AboutViewModel()
        {
            PopulateData();
        }

        private void PopulateData()
        {
            //Title = App.ResMan.GetString("About");
            //SoftwareVersion = $"VnManager {App.VersionString}";
            //CopyrightDate = $"{App.ResMan.GetString("Copyright")} 2020-{DateTime.UtcNow.Year}";
            //Website = @"https://github.com/micah686/VnManager";
            //LicenseInfo = App.ResMan.GetString("LicensedUnderMIT");
            //DeveloperName = $"{App.ResMan.GetString("DevelopedBy")} Micah686";
        }

        /// <summary>
        /// Load main Github page
        /// </summary>
        public void WebsiteClick()
        {
            var link = Website;
            var ps = new ProcessStartInfo(link)
            {
                UseShellExecute = true
            };
            Process.Start(ps);
        }

        /// <summary>
        /// Close Window
        /// </summary>
        public void CloseClick()
        {
        }
    }

}
