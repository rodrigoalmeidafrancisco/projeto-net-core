using ExtensionCore;
using HttpCore;
using Shared.Resources;
using System.Net;

namespace Data.External.Base
{
    public class BaseHttp
    {
        public string ReturnMessageHttp(ResultHttp resultHttp, string systemName, string phrase)
        {
            return resultHttp.HttpStatusCode switch
            {
                HttpStatusCode.NoContent => ResourceHttp.NoContent204.Replace("{phrase}", phrase).Replace("{nomeSistema}", systemName),
                HttpStatusCode.NotFound => ResourceHttp.NotFound404.Replace("{phrase}", phrase).Replace("{nomeSistema}", systemName),
                HttpStatusCode.Unauthorized => ResourceHttp.Unauthorized401.Replace("{phrase}", phrase).Replace("{nomeSistema}", systemName),
                HttpStatusCode.InternalServerError => ResourceHttp.InternalServerError500.Replace("{phrase}", phrase).Replace("{nomeSistema}", systemName),
                _ => ResourceHttp.Default.Replace("{phrase}", phrase).Replace("{nomeSistema}", systemName).Replace("{code}", resultHttp.HttpStatusCode.ToInt().ToString())
            };
        }
    }
}
