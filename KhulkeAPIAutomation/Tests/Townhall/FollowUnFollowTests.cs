using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KhulkeAPIAutomation.Tests.Townhall
{
    [TestFixture]
    public class FollowUnFollowTests :BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void FollowUserTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);

            var body = "{ \"handle\":\"perftest300\", \"type\":\"follow\"}";

            RestClient client = new RestClient(env.useronboardingURL+"user/follow-friends/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer "+AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("User: perftest300 is followed");
        }
        [Test]
        public void UnFollowUserTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);

            var body = "{ \"handle\":\"perftest300\", \"type\":\"unfollow\"}";

            RestClient client = new RestClient(env.useronboardingURL+"user/follow-friends/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("User: perftest300 is unfollowed and response data is: "+responseData+"");
        }

        [Test]
        public void GetAllFollowersTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL+"user/get-all-followers/");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetFollowersTimeline()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"limit\": 10, \"skip\": 0}";
            RestClient client = new RestClient(env.useronboardingURL+"user/get-all-followers/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(responseData, Is.Not.Null);
            _test.Info("Test passed with status code: "+response.StatusCode+"");

        }

        [Test]
        public void FollowAllTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);
            //string body = "{ \"limit\": 10, \"skip\": 0}";
            string body = "{\"data\" : [{\"phone_number\":\"\",\"username\":\"perftest400\",\"email\":\"\"},{\"phone_number\":\"\",\"username\":\"perftest430\",\"email\":\"\"},{\"email\":\"\",\"username\":\"perftest454\",\"phone_number\":\"\"}]}";
            RestClient client = new RestClient(env.useronboardingURL + "user/follow-all/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
         }
    }
}
