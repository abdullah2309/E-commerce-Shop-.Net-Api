using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Suject { get; set; } = null!;

    public string Massage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
