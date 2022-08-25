using System;
using System.Collections.Generic;
using System.Text;

namespace KhulkeAPIAutomation.HelperMethods.Utils
{
    public class EnvironmentConfig
    {
        public string nodeURL { get; set; }
        public string useronboardingURL { get; set; }
        public string roundtableURL { get; set; }

        public string authorizationToken { get; set; }

        public string environment { set; get; }

        public EnvironmentConfig(string env)
        {
            environment = env;
            switch (environment)
            {
                case "perfNew":
                    nodeURL = "https://node.khulke.com/";
                    useronboardingURL = "https://useronboarding.khulke.com/user/";
                    authorizationToken = "I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=";
                    roundtableURL = "https://round-table.khulke.com/round-table/";
                    break;
                case "perf":
                    nodeURL = "https://node.khulke.com/";
                    useronboardingURL = "https://qaapi.khulke.com/";
                    authorizationToken = "I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=";
                    roundtableURL = "";
                    break;
                case "Staging":
                    nodeURL = "https://node.khulke.com/";
                    useronboardingURL = "https://qaapi.khulke.com/";
                    authorizationToken = "I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=";
                    roundtableURL = "";
                    break;
                default:
                    break;
            }

        }


    }

}