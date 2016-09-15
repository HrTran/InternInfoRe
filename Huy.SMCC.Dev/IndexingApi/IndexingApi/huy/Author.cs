using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overoll.Library.huy
{
    public class Author
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _create_date;
        public DateTime create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }

        private string _author;
        public string author_name
        {
            get { return _author; }
            set { _author = value; }
        }

        private string _url;
        public string author_avatar_url
        {
            get { return _url; }
            set { _url = value; }
        }

        private long _follower_count;
        public long follower_count
        {
            get { return _follower_count; }
            set { _follower_count = value; }
        }
        
        private long _friend_count;
        public long friend_count
        {
            get { return _friend_count; }
            set { _friend_count = value; }
        }

        private long _alexa_rank;
        public long alexa_rank
        {
            get { return _alexa_rank; }
            set { _alexa_rank = value; }
        }

        private int _author_is_a_fanpage;
        public int author_is_a_fanpage
        {
            get { return _author_is_a_fanpage; }
            set { _author_is_a_fanpage = value; }
        }

        private string _host;
        public string host
        {
            get { return _host; }
            set { _host = value; }
        }

        private int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _author_url;
        public string author_url
        {
            get { return _author_url; }
            set { _author_url = value; }
        }

       

        private string _service;
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }

        private int _influence_score;
        public int influence_score
        {
            get { return _influence_score; }
            set { _influence_score = value; }
        }
    }
}
