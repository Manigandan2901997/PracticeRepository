using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhulkeAPIAutomation.HelperMethods
{
    public class UtilityMethods
    {
        public static AuthResponse LoginTest(string username)
        {
            var body = "{\"password\": \"I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string  

            var loginResponse = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
            return loginResponse;
        }
    }
}
