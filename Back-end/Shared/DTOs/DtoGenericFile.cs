namespace Shared.DTOs
{
    public class DtoGenericFile
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public string Type { get; set; }

        public byte[] Bytes { get; set; }

        public string Bytes64 { get; set; }

        public Stream ImageStream { get; set; }

        /// <summary>
        /// Altera o nome do arquivo enviado
        /// </summary>
        /// <param name="currentDate"></param>
        public void ChangeFileName(DateTime? currentDate)
        {
            DateTime date = currentDate.HasValue ? currentDate.Value : DateTime.Now;
            string nameFile = $"{date.Year}{date.Month}{date.Day}_{date.Hour}{date.Minute}{date.Second}{date.Millisecond}";
            string extensionFile = Name.Split('.').LastOrDefault();
            Name = $"{nameFile}.{extensionFile}";
        }

    }
}
