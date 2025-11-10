// TODO: Should have a namespace

/// <summary>
/// Represents a generic paginated response that contains a subset of items and pagination metadata.
/// </summary>
/// <typeparam name="T">The type of items contained in the paged response.</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    /// The collection of items for the current page.
    /// </summary>
    public IEnumerable<T> Items { get; set; } = new List<T>();

    /// <summary>
    /// The current page number (1-based index).
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The number of items included per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The total number of items available across all pages.
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// The total number of pages calculated based on <see cref="TotalItems"/> and <see cref="PageSize"/>.
    /// </summary>
    public int TotalPages => (int) Math.Ceiling((double) TotalItems / PageSize);
}
