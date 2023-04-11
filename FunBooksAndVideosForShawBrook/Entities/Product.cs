namespace FunBooksAndVideosForShawBrook.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public MembershipType MembershipType {get; set;}
        public decimal Price { get; set; }
    }
}