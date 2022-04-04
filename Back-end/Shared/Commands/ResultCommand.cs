namespace Shared.Commands
{
    public class ResultCommand<T>
    {
        public ResultCommand()
        {

        }

        public ResultCommand(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
