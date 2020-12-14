﻿namespace Desafio.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}