using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssessmentSocialMedia.Data
{
    public class Mention
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Tweet")]
        public int TweetId { get; set; }
    }
}