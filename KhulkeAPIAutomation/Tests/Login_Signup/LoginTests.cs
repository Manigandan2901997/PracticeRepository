using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KhulkeAPIAutomation.Tests.Login_Signup
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void AuthStatusCodeTest()
        {
            string username = "perftest300";
            var body = "{\"password\": \"I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Login api returned OK status code for user "+username+"");

        }

        [Test]
        public void AuthResponseDataTest()
        {
            string username = "perftest300";
            var body = "{\"password\": \"I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            //var loginResponse = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
            Assert.That(response.Content.Length > 10);
            _test.Info("Login api response data is validated for user " + username + "");

        }

        [Test]
        public void AuthResponseAccessTokenTest()
        {
            string username = "perftest300";
            var body = "{\"password\": \"I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            var loginResponse = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
            Assert.That(loginResponse.access, Is.Not.Null);
            _test.Info("Login api response data is validated for user " + username + "");

        }


        [Test]
        public void LoginInvalidUserTest()
        {
            string username = "invalidUser";
            var body = "{\"password\": \"I1vItkxDwTKxs9VRrsn0OHRAq4oCsG+0R0bI0Tg8iCLlSPVumYIoHWMHgklaYUnFz6yAZT9dM5L81q6Xz1avkhZb654HiSs+/N9wdmJQy1rjkvLZ7PKbdxzCnF5iSjXTYVV/UlfI0Q1h8KkM4f4GBgiko2Nn0nzaKHVbezzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            // assert
            Assert.AreNotEqual(response.StatusCode, HttpStatusCode.OK);
            _test.Info("Login api throws exception for invalid user name: " + username + " Status code is "+response.StatusCode+"");

        }

        [Test]
        public void LoginInvalidPasswordTest()
        {
            string username = "perftest300";
            var body = "{\"password\": \"fdfdssfsfsdfdfsdfzIl84=\", \"username\":\"" + username + "\",\"deviceinfo\":{\r\n        \"device_name\":\"One-plus-8T\",\r\n        \"platform\": \"android\",\r\n        \"platform_version\":\"v1\",\r\n        \"app_version\":\"1.4.6\",\r\n        \"latitude\":\"\",\r\n        \"longitude\": \"\",\r\n        \"ip_address\":\"49.36.101.70\"\r\n    \r\n}}";
            RestClient client = new RestClient("https://qaapi.khulke.com/user/auth/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            Assert.AreNotEqual(response.StatusCode, HttpStatusCode.OK);
            _test.Info("Login api throws exception for invalid password: " + username + " Status code is " + response.StatusCode + "");

        }


    }
}
