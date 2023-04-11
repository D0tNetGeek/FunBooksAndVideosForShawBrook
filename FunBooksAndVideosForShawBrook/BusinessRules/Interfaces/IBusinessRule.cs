using FunBooksAndVideosForShawBrook.Entities;

namespace FunBooksAndVideosForShawBrook.BusinessRules
{
    public interface IBusinessRule
    {
        bool IsApplicable(PurchaseOrder purchaseOrder);
        RuleResult Execute(PurchaseOrder purchaseOrder);
    }
}