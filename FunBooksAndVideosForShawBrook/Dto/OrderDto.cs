namespace FunBooksAndVideosForShawBrook.Dto
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public List<ProductDto> products { get; set; }
    }
}