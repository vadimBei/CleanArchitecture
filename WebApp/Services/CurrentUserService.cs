﻿using WebApp.Interfaces;

namespace WebApp.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email => "test@gmail.com";
    }
}
