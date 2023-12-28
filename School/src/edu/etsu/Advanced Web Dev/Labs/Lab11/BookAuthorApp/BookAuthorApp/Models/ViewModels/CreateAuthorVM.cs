﻿using BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace BookAuthorApp.Models.ViewModels
{
    public class CreateAuthorVM
    {
        public Book? Book { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public Author GetAuthorInstance()
        {
            return new Author
            {
                Id = 0,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}