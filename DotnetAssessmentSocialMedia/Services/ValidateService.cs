using DotnetAssessmentSocialMedia.Controllers;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Services
{
    public class ValidateService : IValidateService
    {
        private readonly SocialMediaContext _context;

        public ValidateService(SocialMediaContext context)
        {
            _context = context;
        }

        public bool AvailableUsername(string username)
        {
            return !ExistUsername(username);
        }

        public bool ExistTag(string label)
        {
            return _context.HashTags.Where(h => h.Label == label).Any();
        }

        public bool ExistUsername(string username)
        {
            return _context.Users.Where(a => a.Credentials.Username == username).Any();
        }

        public bool UsernameMatchCredentials(string username, CredentialsDto credentials)
        {
            return (credentials.Username == username);
        }
    }
}
