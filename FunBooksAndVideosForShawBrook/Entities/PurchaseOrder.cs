namespace FunBooksAndVideosForShawBrook.Entities
{
    public class PurchaseOrder
    {
        public int CustomerId { get; set; }
        public List<Product> ItemLines { get; set; }
    }
}