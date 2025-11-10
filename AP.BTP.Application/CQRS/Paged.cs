namespace AP.BTP.Application.CQRS
{
    public class Paged<T>  // TODO delete this
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public required IEnumerable<T> Data { get; set; }
    }
}

