using FunBooksAndVideosForShawBrook.BusinessRules;
using FunBooksAndVideosForShawBrook.Entities;
using Xunit;

namespace FunBooksAndVideosForShawBrook.Tests
{
    public class MembershipActivationRule_Tests
    {
        [Theory]
        [InlineData(888, 3, "Book", 100, ProductType.Physical)]
        public void IsApplicable_ShouldReturnFalse_IfOrderDoesNotContainsMembership(int customerId, int productId, string productName, decimal price, ProductType productType)
        {
            // Arrange
            var membershipProduct = new Product { Id = productId, Name = productName, Price = price, ProductType = productType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { membershipProduct } };

            var rule = new MembershipActivationRule();

            // Act
            var isApplicable = rule.IsApplicable(purchaseOrder);

            // Assert
            Assert.False(isApplicable);
        }

        [Theory]
        [InlineData(999, 3, "Book", 100, ProductType.Membership, MembershipType.BookClub)]
        public void Execute_ShouldActivateMembership_IfOrderContainsMembership(int customerId, int productId, string productName, decimal price, ProductType productType, MembershipType membershipType)
        {
            // Arrange
            var membershipProduct = new Product { Id = productId, Name = productName, Price = price, ProductType = productType, MembershipType = membershipType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { membershipProduct } };

            var rule = new MembershipActivationRule();

            // Act
            var result = rule.Execute(purchaseOrder);

            // Assert
            Assert.True(result.Success);
            Assert.Contains($"membership activation for the customer", result.Message);
        }
    }
}