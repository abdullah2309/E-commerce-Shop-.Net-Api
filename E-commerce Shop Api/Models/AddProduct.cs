using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class AddProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public string ProductDetails { get; set; } = null!;

    public string ProductImages { get; set; } = null!;

    public int CategoryList { get; set; }

    public virtual AddCategory CategoryListNavigation { get; set; } = null!;
}
