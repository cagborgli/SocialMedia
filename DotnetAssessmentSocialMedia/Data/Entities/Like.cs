using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssessmentSocialMedia.Data
{
    public  class Like
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Tweet")]
        public int TweetId { get; set; }
    }
}