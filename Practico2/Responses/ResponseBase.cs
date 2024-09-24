namespace Practico2.Responses
{
    // Respuesta general para consumo de los endpoints
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
