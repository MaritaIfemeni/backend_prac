namespace Webapi.Business.src.Shared
{
    public class ServiceExeption : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public static ServiceExeption NotFoundExeption(string message = "Entity was not found")
        {
            return new ServiceExeption { StatusCode = 404, Message = message };
        }

        public static ServiceExeption UnAuthAexeption(string message = "Crendentials are not valid")
        {
            return new ServiceExeption { StatusCode = 401, Message = message };
        }
    }
}