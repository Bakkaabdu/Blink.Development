﻿namespace Blink.Development.Entities.Dtos
{
    public class UserLoginRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
