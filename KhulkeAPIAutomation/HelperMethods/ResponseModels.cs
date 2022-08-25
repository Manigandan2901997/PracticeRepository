using System;
using System.Collections.Generic;
using System.Text;

namespace KhulkeAPIAutomation.HelperMethods
{
    public class AuthResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string phone { get; set; }
        public string username_lower { get; set; }
        public bool first_login { get; set; }
        public string password { get; set; }
        public int is_invited { get; set; }
        public Added_By added_by { get; set; }
        //public Interest[] interest { get; set; }
        public string user_id { get; set; }
        public DateTime last_login { get; set; }
        public int invitation_count { get; set; }
        public string added_by_username { get; set; }
        public string added_by_name { get; set; }
        public int is_active { get; set; }
        public string refresh { get; set; }
        public string access { get; set; }
    }

    public class Added_By
    {
        public string method { get; set; }
        public string added_by_user_id { get; set; }
        public DateTime user_added_date { get; set; }
    }

    public class Interest
    {
        public string category_name { get; set; }
        public Sub_Category[] sub_category { get; set; }
    }

    public class Sub_Category
    {
        public string sub_category_name { get; set; }
    }

}




