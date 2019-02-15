using System.Collections.Generic;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;

namespace DotnetAssessmentSocialMedia.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByUsername(string username);
        User CreateUser(User user);
        User DeleteUser(string username, CredentialsDto credentials);
        //All I Added
        User UpdateProfile(User user, string username);
        void Follow(string username, CredentialsDto credentials);
        void Unfollow(string useername, CredentialsDto credentials);
        IEnumerable<Tweet> GetTweets(string username);
        IEnumerable<Tweet> Feed(string username);
        IEnumerable<Tweet> Mentions(string username);
        IEnumerable<User> Followers(string username);
        IEnumerable<User> Following(string username);      
    }
}