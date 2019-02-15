using DotnetAssessmentSocialMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssessmentSocialMedia.Data
{
    public class SocialMediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<HashTag> HashTags { get; set; }  

        public DbSet<Tweet> Tweets { get; set; } 

        public DbSet<FollowersFollowee> FollowersFollowees { get; set; }

        public DbSet<HashTagTweet> HashTagTweets { get; set; }

        public DbSet<Like> Likes{ get; set; }

        public DbSet<Mention> Mentions { get; set; }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options): base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>()
                .HasAlternateKey(c => c.Username);

            modelBuilder.Entity<HashTag>()
                .HasAlternateKey(t => t.Label)
                .HasName("AlternateKey_Label");

            modelBuilder.Entity<Like>().HasKey(sc => new { sc.TweetId, sc.UserId });
            modelBuilder.Entity<Mention>().HasKey(sc => new { sc.UserId, sc.TweetId });
            modelBuilder.Entity<HashTagTweet>().HasKey(sc => new { sc.HashTagId, sc.TweetId });
            modelBuilder.Entity<FollowersFollowee>().HasKey(sc => new { sc.FollowerId, sc.FolloweeId });

        }
    }
}