using KhulkeAPIAutomation.HelperMethods;
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
    public class SignupTests:BaseTest
    {
        [Test]
        public void SignupSendOTPTest()
        {
            string email = "stagetest2@yopmail.com";
            var body = "{ \"user_type\":\"REGISTER\",\"email\":\""+email+"\"}";
            RestClient client = new RestClient("https://stagingapi.khulke.com/user/auth/send-otp");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("signup OTP api sent for email " + email + "");
        }

        [Test]
        public void SignupSendOTPForExistingUserTest()
        {
            string email = "stagetest@yopmail.com";
            var body = "{ \"user_type\":\"REGISTER\",\"email\":\"" + email + "\"}";
            RestClient client = new RestClient("https://stagingapi.khulke.com/user/auth/send-otp");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            Assert.That(response.Content.Contains("User already exists."));
            _test.Info("Signup API does not generate OTP for existing email id: " + email + " status code: "+response.StatusCode+"");
        }

        [Test]
        public void DummyTest()
        {
            string email = "stagetest@yopmail.com";
            var body = "{ \"user_type\":\"REGISTER\",\"email\":\"" + email + "\"}";
            RestClient client = new RestClient("https://stagingapi.khulke.com/user/auth/send-otp");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bozFgNUj8srvFQutEyd5jzPEe7QLYaA5qwvSGHJz1ppNl/IECiC/Dv6OEUfXcSBrAeHpjsGxOOtR/SE2jmPDZKh8yLPj3xIOnD0+oTigjTEhbfhw6BTTX+vKZ5Pe0BdYJy5Egjr8eafE+BgEWuOBTkWtAmjVBX1/Do6dRTWVzEo=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            Assert.That(response.Content.Contains("User already exists."));
            _test.Info("Signup API does not generate OTP for existing email id: " + email + " status code: " + response.StatusCode + "");
        }
    }
}
