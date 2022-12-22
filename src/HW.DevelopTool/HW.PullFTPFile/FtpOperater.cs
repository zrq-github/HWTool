using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    internal abstract class FtpOperater
    {
        public IFtpServerConfig? FtpServer { get; set; }
    }
}
