using System.Diagnostics.CodeAnalysis;
using FunBooksAndVideos.Entities;

namespace FunBooksAndVideosForShawBrook.Entities
{
    [ExcludeFromCodeCoverage]
    public record Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public MembershipType MembershipType { get; set; }

        public string Address { get; set; }
    }
}