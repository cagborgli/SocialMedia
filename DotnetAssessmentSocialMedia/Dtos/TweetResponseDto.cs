using DotnetAssessmentSocialMedia.Data.Entities;
using System;


namespace DotnetAssessmentSocialMedia.Dtos
{
    public class TweetResponseDto
    {
        public Tweet InReplyTo { get; set; }

        public Tweet RepostOf { get; set; }

        public User Author { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; } //Remember to make sure it can never be changed  

    }
}
