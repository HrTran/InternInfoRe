using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Overoll.Library.ElasticSearch;
using System.Data;
using Overoll.Library;
using Overoll.Library.huy;
using System.Threading;
using System.IO;


namespace Overoll.Library.huy
{
    public class IndexingPageRank
    {
        static string ElasticServer = AppEnv.ElasticLong;
        ElasticClient client;
        static int NumOfIndex = 60000;
        DataTable page_Data = DataDB.getDataPages();
        DataTable group_Data = DataDB.getDataGroups();
        List<Author> DtList = new List<Author>();

        // Constructor
        public IndexingPageRank()
        {
            ElasticSearchSetup("author_data2");
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; 
                //Path.Combine(Environment.CurrentDirectory, @"\\datasource.js");
            ReadDataFromFile(path, DtList);
            addDataToList(page_Data, DtList, 1, "fanpage");
            addDataToList(group_Data, DtList, 0, "group");
            ElasticSearchIndex(DtList);
        }

        public List<Author> ReadDataFromFile(string filepath, List<Author> dataList)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines(filepath);
            // Create null datetime variable for null field
            Nullable<DateTime> dt = null;
            foreach (string line in lines.Skip(1))
            {
                string[] fields = line.Split('\t');
                var tweet = new Author();
                tweet.id = fields[0];
                tweet.create_date = dt ?? DateTime.MinValue;
                tweet.author_name = fields[1];
                tweet.author_avatar_url = "";
                tweet.follower_count = 0;
                tweet.friend_count = 0;
                tweet.author_is_a_fanpage = 0;
                tweet.host = fields[1];
                if (fields[2] == "1") tweet.type = 6;
                else tweet.type = 8;
                tweet.author_url = "http://" + fields[1];
                if (tweet.type == 6 || tweet.type == 8)
                {
                    tweet.alexa_rank = -1;       // dang cho data
                    if (tweet.alexa_rank > 20000) { tweet.influence_score = 1; }
                    if (tweet.alexa_rank <= 20000 && tweet.alexa_rank > 10000) { tweet.influence_score = 2; }
                    if (tweet.alexa_rank <= 10000 && tweet.alexa_rank > 5000) { tweet.influence_score = 3; }
                    if (tweet.alexa_rank <= 5000 && tweet.alexa_rank > 2000) { tweet.influence_score = 4; }
                    if (tweet.alexa_rank <= 2000 && tweet.alexa_rank > 1000) { tweet.influence_score = 5; }
                    if (tweet.alexa_rank <= 1000 && tweet.alexa_rank > 500) { tweet.influence_score = 6; }
                    if (tweet.alexa_rank <= 500 && tweet.alexa_rank > 200) { tweet.influence_score = 7; }
                    if (tweet.alexa_rank <= 200 && tweet.alexa_rank > 100) { tweet.influence_score = 8; }
                    if (tweet.alexa_rank <= 100 && tweet.alexa_rank > 50) { tweet.influence_score = 9; }
                    if (tweet.alexa_rank < 50) { tweet.influence_score = 10; }
                }
                dataList.Add(tweet);
            }
            return dataList;
        }


        // Create index for filling data
        // @indexName : whatever
        public void ElasticSearchSetup(string indexName)
        {
            Uri node = new Uri(ElasticServer);
            ConnectionSettings settings = new ConnectionSettings(node);
            settings.DefaultIndex(indexName);
            client = new ElasticClient(settings);

            // create the index if it doesn't exist
            if (!client.IndexExists(indexName).Exists)
            {
                client.CreateIndex(indexName);
            }
        }

        // Change data from table to list
        // @dataTable : Data from DB get by Store Procedure
        // @DataList : List created to store datarows of dataTable
        // @fanpage : is the source fanpage? (1/0)
        // @datatype: what kind of the source? (fanpage/group/user/news,...)
        public void addDataToList(DataTable dataTable, List<Author> DataList, int fanpage, string datatype) 
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var tweet = new Author();
                tweet.id = row["FbId"].ToString();
                tweet.create_date = Convert.ToDateTime(row["CreateDate"].ToString());
                if (fanpage == 0)
                {
                    tweet.author_name = row["Name"].ToString();
                }
                else tweet.author_name = row["UserName"].ToString();
                tweet.author_avatar_url = "http://graph.facebook.com/" + tweet.id + "/picture";
                if (fanpage == 0)
                {
                    tweet.follower_count = Convert.ToInt32(row["MemNum"].ToString());
                }
                else tweet.follower_count = Convert.ToInt32(row["LikeNum"].ToString());
                tweet.friend_count = 0;
                tweet.author_is_a_fanpage = fanpage;
                tweet.host = "facebook.com";
                switch (datatype) {
                    case "fanpage": tweet.type = 0; break;
                    case "fanpage_comment": tweet.type = 1; break;
                    case "group": tweet.type = 2; break;
                    case "group_comment": tweet.type = 3; break;
                    case "user": tweet.type = 4; break;
                    case "user_comment": tweet.type = 5; break;
                    case "news": tweet.type = 6; break;
                    case "forum": tweet.type = 8; break;
                }
                tweet.type = 1;
                tweet.author_url = "http://www.facebook.com/profile.php?id=" + tweet.id;

                if (tweet.type == 0 || tweet.type == 2)
                {
                    tweet.alexa_rank = -1;
                    if (tweet.follower_count < 10000) { tweet.influence_score = 1; }
                    if (tweet.follower_count >= 10000 && tweet.follower_count < 20000) { tweet.influence_score = 2; }
                    if (tweet.follower_count >= 20000 && tweet.follower_count < 50000) { tweet.influence_score = 3; }
                    if (tweet.follower_count >= 50000 && tweet.follower_count < 100000) { tweet.influence_score = 4; }
                    if (tweet.follower_count >= 100000 && tweet.follower_count < 200000) { tweet.influence_score = 5; }
                    if (tweet.follower_count >= 200000 && tweet.follower_count < 500000) { tweet.influence_score = 6; }
                    if (tweet.follower_count >= 500000 && tweet.follower_count < 1000000) { tweet.influence_score = 7; }
                    if (tweet.follower_count >= 1000000 && tweet.follower_count < 2000000) { tweet.influence_score = 8; }
                    if (tweet.follower_count >= 2000000 && tweet.follower_count < 5000000) { tweet.influence_score = 9; }
                    if (tweet.follower_count >= 5000000) { tweet.influence_score = 10; }
                }
                
                

                DataList.Add(tweet);
            }
            
        }

        // Fill data into index
        // @DataList: List used for indexing
        public void ElasticSearchIndex( List<Author> DataList) 
        { 
            int MAX_ListElement = DataList.Count;
            for (var i = 0; i < MAX_ListElement; i = i + NumOfIndex) {
                //Check if indexing completes
                bool insertSuccess = true;
                try
                {
                    List<Author> SubList = new List<Author>();
                    if ((MAX_ListElement - i) < NumOfIndex)
                        SubList = DataList.GetRange(i, MAX_ListElement - i);
                    else SubList = DataList.GetRange(i, NumOfIndex);
                    var respond = client.IndexMany(SubList);
                    insertSuccess = !respond.Errors;
                    if (!insertSuccess)
                        Console.WriteLine("Error IndexMany: " + respond.ItemsWithErrors.FirstOrDefault().Error.Reason + " " + DateTime.Now);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error IndexMany Post: " + e.Message + " " + DateTime.Now);
                    insertSuccess = false;
                    Thread.Sleep(1000);
                } 
            }
        }



    }
}
