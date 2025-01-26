﻿using System.ComponentModel.DataAnnotations;

namespace ArPet.Models.Identity;


public class Identity
{
    [Key] public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}