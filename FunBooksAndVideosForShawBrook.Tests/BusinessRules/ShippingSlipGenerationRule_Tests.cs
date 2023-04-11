using FunBooksAndVideosForShawBrook.BusinessRules;
using FunBooksAndVideosForShawBrook.Entities;
using Xunit;

namespace FunBooksAndVideosForShawBrook.Tests
{
    public class ShippingSlipGenerationRule_Tests
    {
        [Theory]
        [InlineData(888, 3, "Book", 100, ProductType.Physical)]
        public void IsApplicable_ShouldReturnTrue_IfOrderContainsPhysicalProduct(int customerId, int productid, string productName, decimal price, ProductType productType)
        {
            // Arrange
            var shippingProduct = new Product { Id = productid, Name = productName, Price = price, ProductType = productType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { shippingProduct } };

            var rule = new ShippingSlipGenerationRule();

            // Act
            var isApplicable = rule.IsApplicable(purchaseOrder);

            // Assert
            Assert.True(isApplicable);
        }

        [Theory]
        [InlineData(999, 3, "Book", 100, ProductType.Membership)]
        public void IsApplicable_ShouldReturnFalse_IfOrderDoesNotContainPhysicalProduct(int customerId, int productid, string productName, decimal price, ProductType productType)
        {
            // Arrange
            var shippingProduct = new Product { Id = productid, Name = productName, Price = price, ProductType = productType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { shippingProduct } };

            var rule = new ShippingSlipGenerationRule();

            // Act
            var isApplicable = rule.IsApplicable(purchaseOrder);

            // Assert
            Assert.False(isApplicable);
        }
    }
}
