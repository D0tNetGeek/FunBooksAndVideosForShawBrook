using FunBooksAndVideosForShawBrook.BusinessRules;
using FunBooksAndVideosForShawBrook.Entities;
using Xunit;

namespace FunBooksAndVideosForShawBrook.Tests
{
    public class RuleEvaluatorTests
    {
        [Theory]
        [InlineData(888, 3, "Book", 100, ProductType.Membership)]
        public void Execute_WithNoRules_ReturnsEmptyResult(int customerId, int productId, string productName, decimal price, ProductType productType)
        {
            // Arrange
            var membershipProduct = new Product { Id = productId, Name = productName, Price = price, ProductType = productType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { membershipProduct } };

            var ruleCollection = new List<IBusinessRule>();

           // Act
            var resultcollection = new RuleEvaluator(ruleCollection).Execute(purchaseOrder);

            //Assert
            Assert.True(ruleCollection.Count() == 0);
        }

        [Theory]
        [InlineData(3, "Book", 100, ProductType.Membership)]
        public void Execute_WithOneRule_Result_Contains_Response_For_Same_Rule(int customerId, string productName, decimal price, ProductType productType)
        {
            // Arrange
            var membershipProduct = new Product { Name = productName, Price = price, ProductType = productType};
            var purchaseOrder = new PurchaseOrder { CustomerId = customerId, ItemLines = new List<Product> { membershipProduct } };

            var ruleCollection = new List<IBusinessRule>();
            ruleCollection.Add(new MembershipActivationRule());

            // Act
            var resultcollection = new RuleEvaluator(ruleCollection).Execute(purchaseOrder);

            // Assert
            Assert.True(resultcollection.Count() == 1);
            Assert.True(resultcollection.First().Message.Contains("membership activation for the customer"));
            Assert.False(resultcollection.First().Message.StartsWith("Shipping slip for the customer"));
        }

    }
}
