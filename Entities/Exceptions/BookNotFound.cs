namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundExecption
    {
        public BookNotFoundException(int id) : base($"Thee book with id: {id} could not found")
        {
        }
    }
}