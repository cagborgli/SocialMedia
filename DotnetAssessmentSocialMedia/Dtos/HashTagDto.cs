using DotnetAssessmentSocialMedia.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class HashTagDto
    {
        [Required]
        public string Label { get; set; } // Remember to Make unique

        [Required]
        public List<Tweet> ContainedTweet { get; set; }

    }
}
