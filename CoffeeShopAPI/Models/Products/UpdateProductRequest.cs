﻿using System.ComponentModel.DataAnnotations;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Models.Products;

public class UpdateProductRequest
{
    [Required]
    public string Id { get; init; }
    [Required]
    public decimal Price { get; init; }
    public string Name { get; init; }
}
