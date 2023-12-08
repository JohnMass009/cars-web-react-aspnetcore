namespace Cars.WebApi
{
    public class ResponseList<T>
    {
        public T Value { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }

        public ResponseList(T value, int page, int pageCount, int totalCount) 
        {
            Value = value;
            Page = page;
            PageCount = pageCount;
            TotalCount = totalCount;
        }
    }
}