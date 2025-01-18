using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Collections.Generic;
using UnitTestAPI.Models;
using UnitTestAPI.Controllers;

namespace Test_ProductAPI
{
    public class ProductsControllerTests
    {
        [Fact]
        public void GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            var result = controller.GetProducts() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var products = result.Value as List<Products>;
            Assert.NotNull(products);
            Assert.True(products.Count > 0);
        }

        [Fact]
        public void AddProduct_ReturnsCreatedResult_WithValidProduct()
        {
            // Arrange
            var controller = new ProductsController();
            var newProduct = new Products
            {
                Name = "Keyboard",
                Price = 45.99M
            };

            // Act
            var result = controller.AddProduct(newProduct) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);

            var createdProduct = result.Value as Products;
            Assert.NotNull(createdProduct);
            Assert.Equal("Keyboard", createdProduct.Name);
            Assert.Equal(45.99M, createdProduct.Price);
        }

        [Fact]
        public void AddProduct_ReturnsBadRequest_WhenProductIsNull()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            var result = controller.AddProduct(null) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Product is null.", result.Value);
        }
    }
}