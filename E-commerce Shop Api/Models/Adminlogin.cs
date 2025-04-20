using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class Adminlogin
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
