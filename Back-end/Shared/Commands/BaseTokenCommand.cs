using Shared.Enums;
using System.Text.Json.Serialization;

namespace Shared.Commands
{
    public class BaseTokenCommand
    {
        [JsonIgnore]
        public EnumUserType? TokenUserType { get; set; }

    }
}
