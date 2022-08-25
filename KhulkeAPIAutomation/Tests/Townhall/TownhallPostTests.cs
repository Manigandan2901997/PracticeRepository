using NUnit.Framework;
using RestSharp;
using KhulkeAPIAutomation.HelperMethods.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using KhulkeAPIAutomation.HelperMethods;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhulkeAPIAutomation.Tests.Townhall
{
    [TestFixture]
    public class TownhallPostTests : BaseTest
    {
        //[Test]
        //public void PostTextTestAsync()
        //{
        //    var AuthResponse = UtilityMethods.LoginTest("perftest200");


        //    var client = new RestClient("https://node.khulke.com/post-media");

        //    var request = new RestRequest();
        //    request.Method = Method.Post;
        //    request.AddHeader("Content-Type", "gzip, deflate,br");
        //    request.AddHeader("Accept-Encoding", "multipart/form-data");

        //    request.AddParameter("message", "{\"type\":\"TEXT\", \"text\":\"hello\"}", ParameterType.RequestBody);
        //    //request.RequestFormat = DataFormat.Json;

        //    try
        //    {
        //        client.ExecuteAsync(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Exception occured
        //    }






        //    // arrange
        //    //RestClient client = new RestClient("https://node.khulke.com/");
        //    //RestRequest request = new RestRequest("post-media");
        //    //request.Method = Method.Post;
        //    //var body = "{\"text\":\"JmeterTest\",\"type\":\"POST\"}";
        //    //// request.AddHeader("Content-Type", "application/json");
        //    //request.AddHeader("user-id", AuthResponse.user_id);
        //    //request.AddHeader("device-type", "android");
        //    //request.AddParameter("text/plain", body, ParameterType.GetOrPost);

        //    //// act
        //    //RestResponse response = client.Execute(request);

        //    //// assert
        //    //Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //}

        //[Test]
        //public void PostAudioTest()
        //{
        //    var AuthResponse = UtilityMethods.LoginTest("perftest200");
        //    // arrange
        //    RestClient client = new RestClient("https://node.khulke.com/");
        //    RestRequest request = new RestRequest("post-media");
        //    request.Method = Method.Post;
        //    var body = "{\"text\":\"JmeterTest\",\"type\":\"POST\"}";
        //    // request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("user-id", AuthResponse.user_id);
        //    request.AddHeader("device-type", "android");
        //    request.AddParameter("text/plain", body, ParameterType.GetOrPost);

        //    // act
        //    RestResponse response = client.Execute(request);

        //    // assert
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //}

        //[Test]
        //public void PostVideoTest()
        //{
        //    var AuthResponse = UtilityMethods.LoginTest("perftest200");
        //    // arrange
        //    RestClient client = new RestClient("https://node.khulke.com/");
        //    RestRequest request = new RestRequest("post-media");
        //    request.Method = Method.Post;
        //    var body = "{\"text\":\"JmeterTest\",\"type\":\"POST\"}";
        //    // request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("user-id", AuthResponse.user_id);
        //    request.AddHeader("device-type", "android");
        //    request.AddParameter("text/plain", body, ParameterType.GetOrPost);

        //    // act
        //    RestResponse response = client.Execute(request);

        //    // assert
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //}

        //[Test]
        //public void PostDocumentTest()
        //{
        //    var AuthResponse = UtilityMethods.LoginTest("perftest200");
        //    // arrange
        //    RestClient client = new RestClient("https://node.khulke.com/");
        //    RestRequest request = new RestRequest("post-media");
        //    request.Method = Method.Post;
        //    var body = "{\"text\":\"JmeterTest\",\"type\":\"POST\"}";
        //    // request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("user-id", AuthResponse.user_id);
        //    request.AddHeader("device-type", "android");
        //    request.AddParameter("text/plain", body, ParameterType.GetOrPost);

        //    // act
        //    RestResponse response = client.Execute(request);

        //    // assert
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //}

        [Test]
        public void CreatePollTest()
        {
            var AuthResponse = UtilityMethods.LoginTest("perftest200");
            // arrange
            RestClient client = new RestClient("https://node.khulke.com/");
            RestRequest request = new RestRequest("post-media");
            request.Method = Method.Post;
            var body = "{\"text\":\"JmeterTest\",\"type\":\"POST\"}";
            // request.AddHeader("Content-Type", "application/json");
            request.AddHeader("user-id", AuthResponse.user_id);
            request.AddHeader("device-type", "android");
            request.AddParameter("text/plain", body, ParameterType.GetOrPost);

            // act
            RestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}