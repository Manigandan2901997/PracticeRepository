using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KhulkeAPIAutomation.Tests.RoundTable
{
    [TestFixture]
    public class RoundTableTest : BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void GetPastRoundTablesStatusCodeTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL + "round-table/get-past-roundtables");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Successfully retrieved past roundtables with status code: "+response.StatusCode+"");

        }

        [Test]
        public void GetPastRoundTablesDataValidationTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL + "round-table/get-past-roundtables");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(responseData.Contains("username"));
            _test.Info("Successfully validated response for roundtable api");

        }

        [Test]
        public void GetUserDetailsByUsername()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL + "round-table/users");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("username", username);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(responseData.Contains("username"));
        }

        [Test]
        public void GetAllUpcomingRoundtables()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"type\":\"upcoming\",\"limit\":10,\"skip\":1}";

            RestClient client = new RestClient(env.useronboardingURL + "round-table/paginate/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Successfully retrieved upcoming roundtables with status code: " + response.StatusCode + "");

        }

        [Test]
        public void GetAllMyRoundtablesTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"type\":\"my\",\"limit\":10,\"skip\":1}";

            RestClient client = new RestClient(env.useronboardingURL + "round-table/paginate/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Successfully retrieved my roundtables with status code: " + response.StatusCode + "");

        }

        [Test]
        public void GetAllActiveRoundtablesTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"type\":\"active\",\"limit\":10,\"skip\":1}";

            RestClient client = new RestClient(env.useronboardingURL + "round-table/paginate/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Successfully retrieved active roundtables with status code: " + response.StatusCode + "");

        }

        [Test]
        public void GetAllFinishedRoundtablesTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"type\":\"finished\",\"limit\":10,\"skip\":1}";

            RestClient client = new RestClient(env.useronboardingURL + "round-table/paginate/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Successfully retrieved finished roundtables with status code: " + response.StatusCode + "");
         }

    }
}
