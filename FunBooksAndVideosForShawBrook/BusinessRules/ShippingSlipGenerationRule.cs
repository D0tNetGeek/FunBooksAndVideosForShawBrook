using FunBooksAndVideosForShawBrook.Entities;

namespace FunBooksAndVideosForShawBrook.BusinessRules
{
    public class ShippingSlipGenerationRule : IBusinessRule
    {
        public bool IsApplicable(PurchaseOrder purchaseOrder)
        {
            return purchaseOrder.ItemLines.Any(x => x.ProductType == ProductType.Physical);
        }

        public RuleResult Execute(PurchaseOrder purchaseOrder)
        {
            var result = new RuleResult();

             var physicalItemLine = purchaseOrder.ItemLines.Where(x => x.ProductType == ProductType.Physical);

            if (physicalItemLine.Count() > 0)
            {
                result.Success = true;
                result.Message = $"Shipping slip for the customer {purchaseOrder.CustomerId} with products {string.Join(',', physicalItemLine.Select(x => x.Name))} has been generated.";
            }
            else
            {
                result.Success = false;
                result.Message = $"Shipping slip generation rule does not apply to this order.";
            }

            return result;
        }
    }
}