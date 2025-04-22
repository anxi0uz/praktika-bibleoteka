namespace ApiBookStore.Contracts
{
    public record BookReponse(int id,
    string title,
    string author,
    string publishDate,
    string genre,
    decimal? price);
}
