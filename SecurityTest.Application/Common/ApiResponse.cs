namespace SecurityTest.Application.Common
{
    public class ApiResponse<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }  
    }
}
