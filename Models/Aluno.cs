namespace gestao_escolar_api.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateOnly DataNascimento { get; set; }

        // Endereço
        public string? Rua { get; set; }
        public int Numero { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
    }
}
