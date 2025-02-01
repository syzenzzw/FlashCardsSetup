namespace Flash.Domain.Helpers
{
    public class QueryHelpers<T>
    {
        public List<T> Cards { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public QueryHelpers(List<T> cards, int pageIndex, int totalPages)
        {
            Cards = cards;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
    }
}
