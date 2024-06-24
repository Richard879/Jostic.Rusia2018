namespace Jostic.Rusia2018.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<BaseError> Errors { get; set; } = new List<BaseError>();
    }
}