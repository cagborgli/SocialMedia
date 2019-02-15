using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// I created this 
namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class HashTag
    {
        public DateTime LastUsed { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }

        public string Label { get; set; } // Remember to Make unique

        public DateTime FistUsed { get; set; } // remember to make set once

        public List<Tweet> ContainedTweet { get; set; }
    }
}
