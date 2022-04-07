using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class PersonModel
    {
        public PersonModel()
        {

        }

        public PersonModel(int id, string? name, string? email)
        {
            Id = id;
            Name = name;
            Email = email;
        }


        public int Id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Documento Obrigatório")]
        public string? Document { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [Range(1, 5, ErrorMessage = "Número deve ser entre 1 e 5")]
        public int YearsCompany { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
