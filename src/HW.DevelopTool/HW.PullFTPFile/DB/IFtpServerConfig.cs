using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    public interface IFtpServerConfig
    {
        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
    }
}
