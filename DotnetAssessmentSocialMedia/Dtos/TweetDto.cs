using DotnetAssessmentSocialMedia.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class TweetDto
    {
        public Tweet InReplyTo { get; set; }

        public Tweet RepostOf { get; set; }

        [Required]

        public User Author { get; set; }

        public DateTime PostedOn { get; set; } //Remember to make sure it can never be changed  

        public string Content { get; set; }
    }
}
