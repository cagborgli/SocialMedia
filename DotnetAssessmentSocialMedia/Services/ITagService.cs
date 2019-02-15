using DotnetAssessmentSocialMedia.Data.Entities;
using System.Collections.Generic;

namespace DotnetAssessmentSocialMedia.Controllers
{
    public interface ITagService
    {
        IEnumerable<HashTag> HashTags();
        IEnumerable<Tweet> TweetWithTag(string hashtag_label);
    }
}