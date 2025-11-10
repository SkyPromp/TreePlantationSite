namespace AP.BTP.Contracts.DTOs
{
    public record Paged<T>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public required IEnumerable<T> Data { get; set; }
    }
}

