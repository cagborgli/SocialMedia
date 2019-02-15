using System;
using System.Collections.Generic;
using System.Linq;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using DotnetAssessmentSocialMedia.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DotnetAssessmentSocialMedia.Services
{
    public class UserService : IUserService
    {
        private readonly SocialMediaContext _context;

        private readonly ILogger _logger;

        public UserService(SocialMediaContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<User> GetAll()
        {
            // Find all non-delete users
            var users = _context.Users.Where(u => !u.Deleted).ToList();
            if (users.Count <= 0)
            {
                throw new NotFoundCustomException("No users found", "No users found");
            }

            return users;
        }

        public User GetByUsername(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Credentials.Username == username);
      
            // If user doesn't exists or is deleted, throw UserNotFoundException
            if (user == null || user.Deleted)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public User CreateUser(User user)
        {
            user.Joined = DateTime.Now;
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.Contains("unique constraint")) // hmm
                {
                    var existingUser = _context.Users
                        .FirstOrDefault(u => u.Credentials.Username == user.Credentials.Username);
                    if (existingUser != null)
                    {
                        existingUser.Deleted = false;
                        _context.Update(existingUser);
                        return existingUser;
                    }
                }
            }

            return user;
        }

        public User DeleteUser(string username, CredentialsDto credentials)
        {
            
            var user = GetUser(username);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (user.Credentials.Username != credentials.Username
                || user.Credentials.Password != credentials.Password)
            {
                throw new InvalidCredentialsException();
            }

            user.Deleted = true;
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateProfile(User user, string username)
        {
            var Auser = GetUser(username);
            return user;
        }

        public void Follow(string username, CredentialsDto credentials)
        {
            throw new NotImplementedException();
        }

        public void Unfollow(string useername, CredentialsDto credentials)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> GetTweets(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> Feed(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> Mentions(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Followers(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Following(string username)
        {
            throw new NotImplementedException();
        }

        // Get user if username matches and user is not deleted
        public User GetUser(string username)
        {
           return  _context.Users.SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted);
        }
    }
}