using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class Addtocart
{
    public int Id { get; set; }

    public string UserEmail { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public string Quantity { get; set; } = null!;

    public string ProductDetails { get; set; } = null!;

    public string ProductImages { get; set; } = null!;
}
