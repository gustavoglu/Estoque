namespace Estoque.Domain.ViewModels
{
    public class PaginationData<T>
    {
        public PaginationData(List<T> data, int page, int limit, long total)
        {
            Page = page;
            Limit = limit;
            Total = total;
            Data = data;
        }

        public int Page { get; set; }
        public int Limit { get; set; }
        public long Total { get; set; }
        public List<T> Data { get; set; }
    }
}
