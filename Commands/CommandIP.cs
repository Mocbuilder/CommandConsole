﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandIP : ICommand
    {
        public string Name => "ip";

        public string HelpText => "ip [-v4] [-v6] -> Get either the IPv4 or IPv6 addresses.";

        public CommandIP()
        {

        }

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            if (Parameter != "v4" && Parameter != "v6")
                throw new Exception("Invalid format for 'ip' command. Use like this: 'ip- [-v4] [-v6]'");

            if (Parameter == "v4")
            {
                try
                {
                    string hostName = Dns.GetHostName();
                    IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                    foreach (var ipAddress in hostEntry.AddressList)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"IPv4 Address: {ipAddress}");
                        }
                    }
                }
                catch
                {
                    throw new Exception("Couldn't get IPv4 address");
                }
                return;
            }

            try
            {
                string hostName = Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                foreach (var ipAddress in hostEntry.AddressList)
                {
                    if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        Console.WriteLine($"IPv6 Address: {ipAddress}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get IPv6 address");
            }
        }
    }
}
