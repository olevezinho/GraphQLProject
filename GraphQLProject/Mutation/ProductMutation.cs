﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Model;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            // Create product
            Field<ProductType>("createProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.AddProduct(context.GetArgument<Product>("product"));
                });

            // Update product
            Field<ProductType>("updateProduct", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    var productObj = context.GetArgument<Product>("product");

                    return productService.UpdateProduct(productId, productObj);
                });

            // Delete product
            Field<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    productService.DeleteProduct(productId);
                    return "The product with the product id " + productId + " was removed!";
                });
        }
    }
}
