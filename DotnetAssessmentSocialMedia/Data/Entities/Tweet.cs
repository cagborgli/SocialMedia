using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//I created this 
namespace DotnetAssessmentSocialMedia.Data.Entities
{ 
    public class Tweet
    {
        public Tweet InReplyTo { get; set; }

        public Tweet RepostOf { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public User Author { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get;set; } //Remember to make sure it can never be changed  

        public bool Deleted { get; set; }
    }
}
