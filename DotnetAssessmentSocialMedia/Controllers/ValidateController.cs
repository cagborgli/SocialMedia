using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetAssessmentSocialMedia.Controllers
{
    [Route("api/validate")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService _validateService;

        //GET validate/tag/exists/{label}
        [HttpGet("{label}")]
        public ActionResult <bool> TagExist(string label)
        {
            return _validateService.ExistTag(label);
        }

        //GET validate/username/exists/@{username}
        [HttpGet("@{username}")]
        public ActionResult<bool> UsernameExist(string username)
        {
            return _validateService.ExistUsername(username);
        }

        //GET validate/username/available/@{username}
        [HttpGet("@{username}")]
        public ActionResult<bool> UsernameAvailable(string username)
        {
            return _validateService.AvailableUsername(username);
        }
    }
}