using FunBooksAndVideosForShawBrook.Entities;

namespace FunBooksAndVideosForShawBrook.BusinessRules
{
    public class RuleEvaluator
    {
        private readonly IEnumerable<IBusinessRule> rules;

        public RuleEvaluator(IEnumerable<IBusinessRule> ruleCollection)
        {
            rules = ruleCollection;
        }

        public IEnumerable<RuleResult> Execute(PurchaseOrder purchaseOrder)
        {
            // pick up all registered rules and execute applicable rules for the selected product.
            return (IEnumerable<RuleResult>)rules
                        .Where(rule => rule.IsApplicable(purchaseOrder))
                        .Select(rule => rule.Execute(purchaseOrder));
        }
    }
}