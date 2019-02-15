using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using System.Collections.Generic;

namespace DotnetAssessmentSocialMedia.Controllers
{
    public interface ITweetService
    {
        void LikeTweet(CredentialsDto credentials);
        Tweet GetTweet(int id);
        Tweet PostTweet(string content, CredentialsDto credentials);
        Tweet DeleteTweet(CredentialsDto credentials, int tweet_id);
        Tweet TweetReply(string content, CredentialsDto credentials, int tweet_id);
        Tweet TweetRepost(CredentialsDto credentials, int tweet_id);
        IEnumerable<Tweet> AllTweet();
        IEnumerable<HashTag> TagsInTweet(int tweet_id);
        IEnumerable<User> UserLikes(int tweet_id);
        IEnumerable<Tweet> TweetReply(int tweet_id);
        IEnumerable<Tweet> TweetRepost(int tweet_id);
        IEnumerable<User> TweetMentions(int tweet_id);

        //Context TweetContext (int tweet_id);
    }
}