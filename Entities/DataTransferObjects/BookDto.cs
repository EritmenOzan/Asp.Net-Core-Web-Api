using System.ComponentModel.Design.Serialization;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects
{
    public record BookDto
    {
        public int Id { get; init; }
        public String Title { get; init; }
        public decimal Price { get; init; }
    }
}