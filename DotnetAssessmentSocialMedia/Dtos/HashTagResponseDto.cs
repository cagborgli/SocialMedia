using DotnetAssessmentSocialMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class HashTagResponseDto
    {
        public string Label { get; set; }

        public List<Tweet> ContainedTweet { get; set; }
    }
}
