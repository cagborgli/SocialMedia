using DotnetAssessmentSocialMedia.Controllers;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Services
{
    public class TagService : ITagService
    {

        private readonly SocialMediaContext _context;

        private readonly ILogger _logger;

        public TagService(SocialMediaContext context, ILogger<TagService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<HashTag> HashTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> TweetWithTag(string hashtag_label)
        {
            throw new NotImplementedException();
        }
    }
}
