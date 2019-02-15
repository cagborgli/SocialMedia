using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssessmentSocialMedia.Data
{
    public class FollowersFollowee
    {
        [ForeignKey("User")]
        public int FollowerId { get; set; }

        [ForeignKey("User")]
        public int FolloweeId { get; set; }
    }
}