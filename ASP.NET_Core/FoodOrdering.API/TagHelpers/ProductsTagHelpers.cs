﻿using FoodOrdering.DAL.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace FoodOrdering.API.TagHelpers
{
    public class ProductsTagHelper : TagHelper
    {
        public IEnumerable<Product> Products { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var setHtmlContent = string.Empty;

            foreach (var product in Products)
            {
                setHtmlContent +=
                    $@"<ul><li><strong>{nameof(product.Name)}:</strong> {product.Name}</li>
                            <li><strong>{nameof(product.Description)}:</strong> {product.Description}</li>
                            <li><strong>{nameof(product.Price)}:</strong> {product.Price}</li>
                            <li><strong>{nameof(product.Quantity)}:</strong> {product.Quantity}</li>
                            <li><strong>{nameof(product.SupplierId)}:</strong> {product.SupplierId}</li>
                            <li><strong>{nameof(product.ProductCategoryId)}:</strong> {product.ProductCategoryId}</li></ul>";
            }

            output.Content.SetHtmlContent(setHtmlContent);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
