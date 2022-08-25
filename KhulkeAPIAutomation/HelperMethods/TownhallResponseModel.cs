using System;
using System.Collections.Generic;
using System.Text;

namespace KhulkeAPIAutomation.HelperMethods
{
   public class TownhallPostResponse
        {
            public Data data { get; set; }
            public int code { get; set; }
            public string message { get; set; }
        }

        public class Data
        {
            public Post[] post { get; set; }
        }

        public class Post
        {
            public string _id { get; set; }
            public string user_id { get; set; }
            public Polling_Data polling_data { get; set; }
            public Glass_Chamber_Data glass_chamber_data { get; set; }
            public Round_Table_Data round_table_data { get; set; }
            public Blog_Data blog_data { get; set; }
            public string parent_type { get; set; }
            public object[] media { get; set; }
            public string media_type { get; set; }
            public int is_deleted { get; set; }
            public DateTime last_updated { get; set; }
            public DateTime created_at { get; set; }
            public object[] tagged_users { get; set; }
            public object[] mentioned_users { get; set; }
            public object[] hash_tags { get; set; }
            public string text { get; set; }
            public bool is_draft { get; set; }
            public string type { get; set; }
            public int __v { get; set; }
            public DateTime sort_cond { get; set; }
            public Parent[] parent { get; set; }
            public int circulate_count { get; set; }
            public int circulate_self { get; set; }
            public string raw_text { get; set; }
            public string post_id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public int like { get; set; }
            public int dislike { get; set; }
            public int favorite { get; set; }
            public int dm_share_count { get; set; }
            public int comment { get; set; }
            public int post_quote { get; set; }
            public int like_self { get; set; }
            public int dislike_self { get; set; }
            public int favorite_self { get; set; }
            public int dm_share_self { get; set; }
            public int self { get; set; }
            public int muted { get; set; }
            public int comment_self { get; set; }
            public int post_quote_self { get; set; }
            public Verified verified { get; set; }
            public int action_count { get; set; }
            public string formatted_created_at { get; set; }
            public string formatted_created_at_short { get; set; }
            public object[] mentioned_usernames { get; set; }
            public string html_modified_text { get; set; }
        }

        public class Polling_Data
        {
            public bool is_expired { get; set; }
            public Result result { get; set; }
            public object[] options { get; set; }
        }

        public class Result
        {
            public object[] allUserPolled { get; set; }
            public object[] userids { get; set; }
            public object[] percent { get; set; }
            public object[] options { get; set; }
        }

        public class Glass_Chamber_Data
        {
            public Is_Deleted is_deleted { get; set; }
            public string message_sender_type { get; set; }
        }

        public class Is_Deleted
        {
            public int status { get; set; }
        }

        public class Round_Table_Data
        {
            public object[] pins { get; set; }
            public Is_Deleted1 is_deleted { get; set; }
        }

        public class Is_Deleted1
        {
            public int status { get; set; }
        }

        public class Blog_Data
        {
            public Is_Deleted2 is_deleted { get; set; }
            public object[] tags { get; set; }
            public object[] category { get; set; }
        }

        public class Is_Deleted2
        {
            public int status { get; set; }
        }

        public class Verified
        {
            public Verification verification { get; set; }
            public int verification_count { get; set; }
        }

        public class Verification
        {
            public Identity identity { get; set; }
            public Addressdocument addressdocument { get; set; }
            public Profession profession { get; set; }
            public Industry industry { get; set; }
            public Interest2 interest { get; set; }
        }

        public class Identity
        {
            public bool flag { get; set; }
        }

        public class Addressdocument
        {
            public bool flag { get; set; }
        }

        public class Profession
        {
            public bool flag { get; set; }
        }

        public class Industry
        {
            public bool flag { get; set; }
        }

        public class Interest2
        {
            public bool flag { get; set; }
        }

        public class Parent
        {
            public string _id { get; set; }
            public string post_id { get; set; }
            public string user_id { get; set; }
            public int is_deleted { get; set; }
            public object[] media { get; set; }
            public string media_type { get; set; }
            public string created_at { get; set; }
            public string text { get; set; }
            public string raw_text { get; set; }
            public string type { get; set; }
            public string parent_type { get; set; }
            public object[] mentioned_users { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public Urls urls { get; set; }
            public Verified1 verified { get; set; }
            public string formatted_created_at { get; set; }
            public string formatted_created_at_short { get; set; }
            public object[] mentioned_usernames { get; set; }
            public string html_modified_text { get; set; }
        }

        public class Urls
        {
        }

        public class Verified1
        {
            public Verification1 verification { get; set; }
            public int verification_count { get; set; }
        }

        public class Verification1
        {
            public Identity1 identity { get; set; }
            public Addressdocument1 addressdocument { get; set; }
            public Profession1 profession { get; set; }
            public Industry1 industry { get; set; }
            public Interest1 interest { get; set; }
        }

        public class Identity1
        {
            public bool flag { get; set; }
        }

        public class Addressdocument1
        {
            public bool flag { get; set; }
        }

        public class Profession1
        {
            public bool flag { get; set; }
        }

        public class Industry1
        {
            public bool flag { get; set; }
        }

        public class Interest1
        {
            public bool flag { get; set; }
        }

    }
