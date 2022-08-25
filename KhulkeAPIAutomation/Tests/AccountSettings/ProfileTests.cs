using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace KhulkeAPIAutomation.Tests.AccountSettings
{
    [TestFixture]
    public class ProfileTests :BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void GetOtherUsersProfileTest()
        {
            string username = "perftest310";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{ \"username\":\"perftest300\"}";
            RestClient client = new RestClient(env.useronboardingURL + "user/profile/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Retireved other users's profile data and Status code is " + response.StatusCode + "");

        }

        [Test]
        public void UpdateFullNameTest()
        {
            string username = "perftest200";
            var AuthResponse = UtilityMethods.LoginTest(username);
            string body = "{\"one_liner\":\" \",\"name\":\"Perftetest\",\"date_of_birth\":null,\"website_info\":[\"\"],\"location\":\"\",\"preferred_language\":[],\"interest\":[],\"sex\":\"\"}";
            RestClient client = new RestClient(env.useronboardingURL + "user/edit_profile/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Retireved other users's profile data and Status code is " + response.StatusCode + "");

        }
    }
}
