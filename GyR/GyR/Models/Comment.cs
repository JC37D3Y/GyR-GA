using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GyR.Models
{
    public class Comment
    {
        private int id;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        private string userName;

        public string GetUserName()
        {
            return userName;
        }

        public void SetUserName(string value)
        {
            userName = value;
        }

        private string content;

        public string GetContent()
        {
            return content;
        }

        public void SetContent(string value)
        {
            content = value;
        }

        public DateTime DateCreated { get; set; }
    }
}