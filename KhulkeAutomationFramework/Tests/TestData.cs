using System;
using System.Collections.Generic;

namespace AutomationFramework.Tests
{
    public static class TestData
    {
        public static List<string> namesOfStudents = new List<string> { "Rupal", "Abhi", "Kalgi", "Priyanka" };

        public static List<string> userNames = new List<string> { "Ram", "testkhulke", "perftest312", "perftest313","radhikayewale", "KrishPukale15"};
        public static List<string> userMobile = new List<string> { "8805071357","8890989898"};
        public static List<string> userEmail = new List<string> { "rashika_09g@yahoo.co.in","abcder@gnm.com"};

        public static string password = "#TestDemo1234";
        public static string password1 = "#TestDemo12345";
        public static string invalidPassword = "#Demo1234";

        //!test data for register with mobile
        public static List<string> mobileNo = new List<string> { "8975049977", "8805071357"};
        public static List<string> invalidMobileNo = new List<string> { "11111", "11111111111","abc","#weerr","1234567898",""};
        public static List<string> invalidEmail = new List<string> { "abc", "abc@","@abc","abc123","1234567898"};
        public static List<string> emailIds = new List<string> { "thisismymail94@yopmail.com" };
        public static List<string> invalidEmailIds = new List<string> { "abc@gmail.com","1234","@yahoo.com","aaa@aaa.com"};
        public static List<string> updateEmailIds = new List<string> { "hithisis", "UpdateMyEmail123", "UpdateMyEmail321" };
        public static List<int> invalidAge = new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12};
        public static string textPost = "This is test of text post...";
        public static string textPostMore = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,";
        public static string audioPostTitle = "Testing audio post";
        public static string videoPostTitle = "Testing video post";
        public static void ReadDataFromExcel(string dataFile)
        {
            throw new NotImplementedException();
        }
    }
}
