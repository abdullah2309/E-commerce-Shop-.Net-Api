using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class Register
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;
}
