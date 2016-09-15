using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overoll.Library.huy
{
    public class PagesRankInfo
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _fbId;
        public string FbId
        {
            get { return _fbId; }
            set { _fbId = value; }
        }

        private DateTime _createDate;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        private int _totalPost;
        public int TotalPost
        {
            get { return _totalPost; }
            set { _totalPost = value; }
        }

        private double _lastDailyPost;
        public double LastDailyPost
        {
            get { return _lastDailyPost; }
            set { _lastDailyPost = value; }
        }

        private double _averageDailyPost;
        public double AverageDailyPost
        {
            get { return _averageDailyPost; }
            set { _averageDailyPost = value; }
        }

        private bool _isUsing;
        public bool IsUsing
        {
            get { return _isUsing; }
            set { _isUsing = value; }
        }

        private int _rank;
        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private int _likeNum;
        public int LikeNum
        {
            get { return _likeNum; }
            set { _likeNum = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _recentPostId;
        public string RecentPostId
        {
            get { return _recentPostId; }
            set { _recentPostId = value; }
        }

        private int _updateRankCount;
        public int UpdateRankCount
        {
            get { return _updateRankCount; }
            set { _updateRankCount = value; }
        }

        private DateTime _lastTimeInQueue;
        public DateTime LastTimeInQueue
        {
            get { return _lastTimeInQueue; }
            set { _lastTimeInQueue = value; }
        }


    }

}
