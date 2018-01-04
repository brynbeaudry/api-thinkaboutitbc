
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_thinkaboutitbc.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

        private string _Text = "";
        
        public string Text { get { return _Text; } set { _Text = value;} }

        public Image Image { get; set; }

        private uint _Weight = 0;

        private uint Weight { get { return _Weight; } set { _Weight = value;} }
        
        private DateTime _CreatedAt = DateTime.Now;
        
        [DataType(DataType.Date)]
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreatedAt { get { return _CreatedAt; } set { _CreatedAt = value; } }
        
        private DateTime _UpdatedAt = DateTime.Now;

        [DataType(DataType.Date)]
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get { return _UpdatedAt; } set { _UpdatedAt = value; } }

        public ApplicationUser CreatedBy { get; set; }

        public List<Comment> Comments { get; set; }
        
    

        
        


        
        
    }
}