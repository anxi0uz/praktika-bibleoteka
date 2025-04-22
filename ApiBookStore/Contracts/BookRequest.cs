namespace ApiBookStore.Contracts
{
    public record BookRequest(string Title,int authorId,string publishDate,int genreId,decimal price
   );
}
