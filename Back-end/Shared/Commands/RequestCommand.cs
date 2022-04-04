using System.Text.Json.Serialization;

namespace Shared.Commands
{
    public class RequestCommand<T>
    {
        public RequestCommand()
        {

        }

        [JsonIgnore]
        public Guid TokenAccountId { get; set; }

        public T Request { get; set; }

    }
}
