using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KhulkeAPIAutomation.Tests.Notification
{
    [TestFixture]
    public class NotificationTest : BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void GetAllNotificationsTest()
        {
            var AuthResponse = UtilityMethods.LoginTest("perftest200");
            RestClient client = new RestClient("https://qaapi.khulke.com/notifications/count");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Authorization", "Bearer "+AuthResponse.access);

            RestResponse response = client.Execute(request);
           // var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void GetRoundtableNotificationsForUserTest()
        {
            var AuthResponse = UtilityMethods.LoginTest("perftest300");

            RestClient client = new RestClient("https://qaapi.khulke.com/notifications/round-table/");
            RestRequest request = new RestRequest();
            string body ="{ \"limit\": 10, \"skip\": 0}";
            request.Method = Method.Post;
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            //var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetNetworkNotificationsTest()
        {
            var AuthResponse = UtilityMethods.LoginTest("perftest300");

            RestClient client = new RestClient("https://qaapi.khulke.com/notifications/get-network-notifications");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
           Assert.That(responseData, Is.Not.Null);
        }

        [Test]
        public void NotificationUpdateTest()
        {
            var AuthResponse = UtilityMethods.LoginTest("perftest300");

            RestClient client = new RestClient("https://qaapi.khulke.com/notifications/update");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            string body = "{ \"type\": \"ROUNDTABLE\"}";
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            //var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
