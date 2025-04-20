using System;
using System.Collections.Generic;

namespace E_commerce_Shop_Api.Models;

public partial class AddCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<AddProduct> AddProducts { get; set; } = new List<AddProduct>();

    public virtual ICollection<AddProductsale> AddProductsales { get; set; } = new List<AddProductsale>();
}
