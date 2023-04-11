using FunBooksAndVideosForShawBrook.Entities;

namespace FunBooksAndVideosForShawBrook.BusinessRules
{
    public class MembershipActivationRule : IBusinessRule
    {
        public bool IsApplicable(PurchaseOrder purchaseOrder)
        {
            return purchaseOrder.ItemLines.Any(x => x.ProductType == ProductType.Membership);
        }

        public RuleResult Execute(PurchaseOrder purchaseOrder)
        {
            var result = new RuleResult();

            var membershipItemLine = purchaseOrder.ItemLines.Where(x => x.ProductType == ProductType.Membership);

            if (membershipItemLine.Count() > 0)
            {
                result.Success = true;
                result.Message = $"{membershipItemLine.First().MembershipType} membership activation for the customer {purchaseOrder.CustomerId} is done successfully.";
            }
            else
            {
                result.Success = false;
                result.Message = $"Membership Activation rule does not apply to this order.";
            }
            
            return result;
        }
    }
}