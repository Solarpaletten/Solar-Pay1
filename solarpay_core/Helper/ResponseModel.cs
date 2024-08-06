namespace solarpay_core.Helper
{
    public class ResponseModel<T>
    {
        public bool status { get; set; }
        public T? Data { get; set; }
        public string? Message {  get; set; }
    }
}
