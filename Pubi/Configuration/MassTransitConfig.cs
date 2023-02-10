using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubi.Configuration
{
    public class MassTransitConfig
    {
        public string Host { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
    }
}
