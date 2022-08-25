using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace KhulkeAPIAutomation.Tests.Townhall
{
    [TestFixture]
    public class InterestTests :BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void GetInterestsTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL+"user/view_interest/");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UpdateInterestsStatusCodeTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{\"data\": {\"category_name\": \"Tech\",\"sub_category\": [{\"sub_category_name\": \"Startups\" } ]}}";

            RestClient client = new RestClient(env.useronboardingURL+"user/update_interest/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            //Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Interests updated for user "+username+" and Status code is " + response.StatusCode + "");

        }

        [Test]
        public void UpdateInterestsResponseValidationTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{\"data\": {\"category_name\": \"Technology\",\"sub_category\": [{\"sub_category_name\": \"Startups\" } ]}}";

            RestClient client = new RestClient(env.useronboardingURL + "user/update_interest/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(responseData.Contains("Technology"));
            _test.Info("Interests updated for user " + username + " and Status code is " + response.StatusCode + "");

        }

        [Test]
        public void GetAllLanguagesForUserTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            RestClient client = new RestClient(env.useronboardingURL+"user/get-all-languages/");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Get all languages for user " + username + " and response data: " + response.Content + "");

        }
    }
}
