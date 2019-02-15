using AutoMapper;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAssessmentSocialMedia.Controllers
{
    [Route("api/tweets")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        // GET api/tweets
        [HttpGet]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<TweetResponseDto>> Get()
        {
            var result = _tweetService.AllTweet();
            var tweets = result.ToList();
            var mappedTweets = _mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetResponseDto>>(tweets);

            return mappedTweets.ToList();
        }

        // Post api/tweets
        [HttpPost]
        [ProducesResponseType(404)]
        public ActionResult<TweetResponseDto>Post(string content,CredentialsDto credentials)
        {
            var result = _tweetService.PostTweet(content ,credentials);
            var mappedTweets = _mapper.Map<Tweet,TweetResponseDto>(result);

            return mappedTweets;
        }

        // Get api/tweets/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<TweetResponseDto> GetTweet(int id)
        {
            var result = _tweetService.GetTweet(id);
            var mappedTweets = _mapper.Map<Tweet, TweetResponseDto>(result);

            return mappedTweets;
        }

        // DELETE tweets/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<TweetResponseDto> DeleteTweet(CredentialsDto credentials, int id)
        {
            var result = _tweetService.DeleteTweet(credentials,id);
            var mappedTweets = _mapper.Map<Tweet, TweetResponseDto>(result);

            return mappedTweets;
        }
    }
}