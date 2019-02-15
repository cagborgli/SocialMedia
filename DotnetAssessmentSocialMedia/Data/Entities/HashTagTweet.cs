using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssessmentSocialMedia.Data
{
    public class HashTagTweet
    {
        [ForeignKey("HashTag")]
        public int HashTagId { get; set; }

        [ForeignKey("Tweet")]
        public int TweetId { get; set; }
    }
}