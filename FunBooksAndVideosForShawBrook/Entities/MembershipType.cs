using System.Text.Json.Serialization;

namespace FunBooksAndVideosForShawBrook.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MembershipType
    {
        BookClub = 0,
        VideoClub = 1,
        Premium = 2
    }
}