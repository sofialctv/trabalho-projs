using colab.Business.Models.Entities;

namespace colab.Business.DTOs.Response
{
    public class PessoaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public List<BolsaResponseDTO>? Bolsas { get; set; }
    } 
}