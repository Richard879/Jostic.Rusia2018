namespace Jostic.Rusia2018.Transversal.Common
{
    public class ResponsePagination<T> : ResponseGeneric<T>
    {
        public int PageNumer { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => PageNumer > 1;
        public bool HasNextPage => PageNumer < TotalPages;
    }
}
