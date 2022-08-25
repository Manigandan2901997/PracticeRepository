using KhulkeAPIAutomation.HelperMethods;
using KhulkeAPIAutomation.HelperMethods.Utils;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace KhulkeAPIAutomation.Tests.Townhall
{
    [TestFixture]
    public class BlockUnBlockTest :BaseTest
    {
        EnvironmentConfig env = new EnvironmentConfig("perf");

        [Test]
        public void BlockUserTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);

            var body = "{ \"handle\":\"perftest330\", \"type\":\"block\"}";

            RestClient client = new RestClient(env.useronboardingURL+ "/user/user-action/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Bearer "+AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("User: perftest300 is blocked");

        }

        [Test]
        public void UnBlockUserTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);

            var body = "{ \"handle\":\"perftest330\", \"type\":\"unblock\"}";

            RestClient client = new RestClient(env.useronboardingURL + "/user/user-action/");
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("User: perftest300 is unblocked");

        }


        [Test]
        public void GetBlockedUserListTest()
        {
            string username = "perftest320";
            var AuthResponse = UtilityMethods.LoginTest(username);

            RestClient client = new RestClient(env.useronboardingURL + "/user/setting/get-blocked-accounts/");
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + AuthResponse.access);
            RestResponse response = client.Execute(request);
            var responseData = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            _test.Info("Retrieved blocked user list:" + responseData + "");
            
        }

    }
}
