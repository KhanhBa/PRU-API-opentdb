﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool Status { get; set; }

    public int Score { get; set; }
}