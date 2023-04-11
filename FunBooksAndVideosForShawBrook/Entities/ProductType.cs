using System.Text.Json.Serialization;

namespace FunBooksAndVideosForShawBrook.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductType
    {
        Physical = 0,
        Membership = 1,
        Digital = 2
    }
}