using Shared.Settings;
using System.Text;

namespace Shared.Util
{
    public static class UtilExtensions
    {
        /// <summary>
        /// Obtém uma imagem em wwwroot
        /// </summary>
        /// <param name="nomeImagem"></param>
        /// <returns></returns>
        public static byte[] GetRootImage(string nomeImagem = "DefaultUser.png")
        {
            string pathFile = string.Empty;

            if (SettingsWebAPI.BaseWebAPI?.WebRootPath != null)
            {
                pathFile = Path.Combine(SettingsWebAPI.BaseWebAPI.WebRootPath, "images", nomeImagem);
            }

            return File.ReadAllBytes(pathFile);
        }

        /// <summary>
        /// Obtém uma imagem em wwwroot e convert em Base64String
        /// </summary>
        /// <param name="nomeImagem"></param>
        /// <returns></returns>
        public static string GetRootImageBase64(string nomeImagem = "DefaultUser.png")
        {
            return Convert.ToBase64String(GetRootImage(nomeImagem));
        }

        /// <summary>
        /// Formata a mensagem para retornar ao Front-End
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="parametrosInvalidos"></param>
        /// <returns></returns>
        public static string FormatHtmlMessage(this string mensagem, IEnumerable<string> parametrosInvalidos)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"{mensagem} <br />");
            stringBuilder.AppendLine(SetHtmlMessage(parametrosInvalidos));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Monta a mensagem em HTML para retornar ao Front-End
        /// </summary>
        /// <param name="parametrosInvalidos"></param>
        /// <returns></returns>
        private static string SetHtmlMessage(IEnumerable<string> parametrosInvalidos)
        {
            StringBuilder stringBuilder = new();

            if (parametrosInvalidos != null && parametrosInvalidos.Any())
            {
                foreach (string parametro in parametrosInvalidos)
                {
                    stringBuilder.AppendLine($"• {parametro} <br />");
                }
            }

            return stringBuilder.ToString();
        }

    }
}
