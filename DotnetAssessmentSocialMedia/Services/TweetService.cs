using DotnetAssessmentSocialMedia.Controllers;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using DotnetAssessmentSocialMedia.Exception.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAssessmentSocialMedia.Services
{
    public class TweetService : ITweetService
    {
        private readonly SocialMediaContext _context;

        private readonly ILogger _logger;

        public TweetService(SocialMediaContext context, ILogger<TweetService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Tweet> AllTweet()
        {
            var tweets = _context.Tweets.Where(u => !u.Deleted).ToList();
            if (tweets.Count <= 0)
            {
                throw new NotFoundCustomException("No users found", "No users found");
            }
            return tweets;
        }

        public Tweet DeleteTweet(CredentialsDto credentials, int tweet_id)
        {
            var tweet = _context.Tweets.Where(t => t.Id == tweet_id && !t.Deleted).SingleOrDefault();

            if (tweet == null || tweet.Author.Credentials.Username != credentials.Username)
            {
                throw new NotFoundCustomException("No tweet found", "No tweet found");
            }

            tweet.Deleted = true;
            _context.Tweets.Update(tweet);
            _context.SaveChanges();

            return tweet;
        }
      
        public Tweet GetTweet(int id)
        {
            var tweet = _context.Tweets.Where(t => t.Id == id && !t.Deleted).SingleOrDefault();

            if (tweet == null)
            {
                throw new NotFoundCustomException("No users found", "No users found");

            }

            return tweet;
        }

        public void LikeTweet(CredentialsDto credentials)
        {
            throw new NotImplementedException();
        }

        public Tweet PostTweet(string content, CredentialsDto credentials)
        {
            var author = _context.Users.Where(u => u.Credentials.Username == credentials.Username && !u.Deleted);

            if(author == null )
            {
                throw new NotFoundCustomException("No users found", "No users found");
            }

            var tweet = _context.Tweets.SingleOrDefault();
            tweet.Author= (User)author;
            tweet.PostedOn = DateTime.Now;
            tweet.Content = content;
            //Implement content Parsing here
            _context.Tweets.Update(tweet);
            _context.SaveChanges();

            return tweet;

        }

        public IEnumerable<HashTag> TagsInTweet(int tweet_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> TweetMentions(int tweet_id)
        {
            throw new NotImplementedException();
        }

        public Tweet TweetReply(string content, CredentialsDto credentials, int tweet_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> TweetReply(int tweet_id)
        {
            throw new NotImplementedException();
        }

        public Tweet TweetRepost(CredentialsDto credentials, int tweet_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> TweetRepost(int tweet_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> UserLikes(int tweet_id)
        {
            throw new NotImplementedException();
        }


        //public Context TweetContext(int tweet_id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
