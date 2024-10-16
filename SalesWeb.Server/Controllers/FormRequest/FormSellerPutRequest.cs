using System.ComponentModel.DataAnnotations;

namespace SalesWeb.Server.Controllers.FormRequest
{
    public class FormSellerPutRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [Range(18, 99, ErrorMessage = "A idade deve estar entre 18 e 99")]
        public int Idade { get; set; }
    }
}
