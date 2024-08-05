namespace WarehouseManagement.API.Responses
{
    public record Response<T>
    {
        public T? Content { get; set; }
        public string Error { get; set; } = string.Empty;
    }
}
