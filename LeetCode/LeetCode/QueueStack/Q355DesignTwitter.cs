using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    public class Q355DesignTwitter
    {
        //設計一個簡化版的推特(Twitter)，可以讓用戶實現發送推文，關注/取消關注其他用戶，能夠看見關注人（包括自己）的最近十條推文。你的設計需要支持以下的幾個功能：
        //postTweet(userId, tweetId) :創建一條新的推文
        //getNewsFeed(userId) :檢索最近的十條推文。每個推文都必須是由此用戶關注的人或者是用戶自己發出的。推文必須按照時間順序由最近的開始排序。
        //follow(followerId, followeeId) :關註一個用戶
        //unfollow(followerId, followeeId) :取消關註一個用戶
        //示例:
        //Twitter twitter = new Twitter();

        // 用戶1發送了一條新推文(用戶id = 1, 推文id = 5).
        //twitter.postTweet(1, 5);

        // 用戶1的獲取推文應當返回一個列表，其中包含一個id為5的推文.
        //twitter.getNewsFeed(1);

        // 用戶1關注了用戶2.
        //twitter.follow(1, 2);

        // 用戶2發送了一個新推文(推文id = 6).
        //twitter.postTweet(2, 6);

        // 用戶1的獲取推文應當返回一個列表，其中包含兩個推文，id分別為-> [6, 5].
        // 推文id6應當​​在推文id5之前，因為它是在5之後發送的.
        //twitter.getNewsFeed(1);

        // 用戶1取消關注了用戶2.
        //twitter.unfollow(1, 2);

        // 用戶1的獲取推文應當返回一個列表，其中包含一個id為5的推文.
        // 因為用戶1已經不再關注用戶2.
        //twitter.getNewsFeed(1);
        public Q355DesignTwitter()
        {
            //Twitter tw = new Twitter();
            //tw.PostTweet(1, "test");
            //tw.Follow(1, 2);
            //tw.PostTweet(2, "XYE");
            //var te = tw.GetNewsFeed(1);
        }

        #region 自己用Stack寫的

       
        public class Twitter1
        {

            /** Initialize your data structure here. */
            public Twitter1()
            {

            }

            public class Tweet
            {
                public int userId { get; set; }
                public int tweetId { get; set; }
            }

            Stack<Tweet> tweetStack = new Stack<Tweet>();

            Dictionary<int, List<int>> friends = new Dictionary<int, List<int>>();

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                if (!friends.ContainsKey(userId))
                    friends.Add(userId, new List<int>() { });

                tweetStack.Push(new Tweet() { userId = userId, tweetId = tweetId });
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                List<int> result = new List<int>();
                if (friends.ContainsKey(userId))
                {
                    var tmp = new Stack<Tweet>(new Stack<Tweet>(tweetStack));

                    for (int i = 0; i < tweetStack.Count; i++)
                    {
                        if (result.Count == 10)
                            return result;
                        var data = tmp.Pop();
                        if (data.userId == userId || friends[userId].Contains(data.userId))
                            result.Add(data.tweetId);
                    }
                }
                return result;
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                if (friends.ContainsKey(followerId))
                {
                    if (friends[followerId].Contains(followeeId))
                        return;
                    else
                        friends[followerId].Add(followeeId);
                }
                else
                    friends.Add(followerId, new List<int>() { followeeId });
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (friends.ContainsKey(followerId))
                {
                    if (friends[followerId].Contains(followeeId))
                        friends[followerId].Remove(followeeId);
                }
            }
        }

        #endregion

        #region 參考九章的寫法，但是九章傳的是訊息不是int

        public class Twitter2
        {
            public class Tweet
            {
                public int id;
                public int user_id;
                public string text;
                public static Tweet create(int user_id, string tweet_text)
                {
                    // This will create a new tweet object,
                    // and auto fill id
                    var result = new Tweet();
                    result.user_id = user_id;
                    result.text = tweet_text;
                    return result;
                }
            }

            public class Node
            {
                public int order;
                public Tweet tweet;

                public Node(int o, Tweet t)
                {
                    this.order = o;
                    this.tweet = t;
                }
            }

            public class SortByOrder : IComparer<Node>
            {
                public int Compare(Node obj1, Node obj2)
                {
                    Node node1 = (Node)obj1;
                    Node node2 = (Node)obj2;
                    if (node1.order < node2.order)
                        return 1;
                    else
                        return -1;
                }
            }

            private Dictionary<int, HashSet<int>> friends;
            private Dictionary<int, List<Node>> users_tweets;
            private int order;

            public List<Node> getLastTen(List<Node> tmp)
            {
                int last = 10;
                if (tmp.Count < 10)
                    last = tmp.Count;
                //java subList(fromIndex , toIndex) 
                return tmp.GetRange(tmp.Count - last, last);
            }

            public List<Node> getFirstTen(List<Node> tmp)
            {
                int last = 10;
                if (tmp.Count < 10)
                    last = tmp.Count;
                return tmp.GetRange(0, last);
            }

            /** Initialize your data structure here. */
            public Twitter2()
            {
                this.friends = new Dictionary<int, HashSet<int>>();
                this.users_tweets = new Dictionary<int, List<Node>>();
                this.order = 0;
            }

            /** Compose a new tweet. */
            public Tweet PostTweet(int user_id, string tweet_text)
            {
                Tweet tweet = Tweet.create(user_id, tweet_text);
                if (!users_tweets.ContainsKey(user_id))
                    users_tweets.Add(user_id, new List<Node>());
                order += 1;
                users_tweets[user_id].Add(new Node(order, tweet));
                return tweet;
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public List<Tweet> GetNewsFeed(int user_id)
            {
                List<Node> tmp = new List<Node>();
                if (users_tweets.ContainsKey(user_id))
                    tmp.AddRange(getLastTen(users_tweets[user_id]));

                if (friends.ContainsKey(user_id))
                {
                    foreach (var user in friends[user_id])
                    {
                        if (users_tweets.ContainsKey(user))
                            tmp.AddRange(getLastTen(users_tweets[user]));
                    }
                }

                //= tmp = tmp.OrderByDescending(o=>o.order).ToList();
                tmp.Sort(new SortByOrder());

                List<Tweet> rt = new List<Tweet>();
                tmp = getFirstTen(tmp);
                foreach (Node node in tmp)
                    rt.Add(node.tweet);

                return rt;
            }

            public List<Tweet> getTimeline(int user_id)
            {
                // Write your code here
                List<Node> tmp = new List<Node>();
                if (users_tweets.ContainsKey(user_id))
                    tmp.AddRange(getLastTen(users_tweets[user_id]));

                //==tmp = tmp.OrderByDescending(o => o.order).ToList();
                tmp.Sort(new SortByOrder());

                List<Tweet> rt = new List<Tweet>();
                tmp = getFirstTen(tmp);

                foreach (Node node in tmp)
                    rt.Add(node.tweet);

                return rt;
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int from_user_id, int to_user_id)
            {
                if (!friends.ContainsKey(from_user_id))
                    friends.Add(from_user_id, new HashSet<int>());

                friends[from_user_id].Add(to_user_id);
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int from_user_id, int to_user_id)
            {
                if (friends.ContainsKey(from_user_id))
                    friends[from_user_id].Remove(to_user_id);
            }
        }

        #endregion

        #region 參考網路上 用LinkedList做Stack

        public class Twitter
        {
            /** Initialize your data structure here. */
            public Twitter()
            {

            }

            public class Tweet
            {
                public int id;
                public int userId;
                public Tweet(int id, int userId)
                {
                    this.id = id;
                    this.userId = userId;
                }
            }

            LinkedList<Tweet> tweetStack = new LinkedList<Tweet>();
            Dictionary<int, HashSet<int>> users = new Dictionary<int, HashSet<int>>();

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                if (!users.ContainsKey(userId))
                    users.Add(userId, new HashSet<int>());
                tweetStack.AddFirst(new Tweet(tweetId, userId));
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                if (!users.ContainsKey(userId))
                    users.Add(userId, new HashSet<int>());
                List<int> result = new List<int>();
                foreach (var tweet in tweetStack)
                {
                    if (users[userId].Contains(tweet.userId) || tweet.userId == userId)
                        result.Add(tweet.id);
                    if (result.Count == 10)
                        break;
                }
                return result;
            }

            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                if (!users.ContainsKey(followerId))
                    users.Add(followerId, new HashSet<int>());
                users[followerId].Add(followeeId);
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (!users.ContainsKey(followerId))
                    users.Add(followerId, new HashSet<int>());
                users[followerId].Remove(followeeId);
            }
        }

        #endregion

    }
}
