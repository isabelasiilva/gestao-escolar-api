using gestao_escolar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gestao_escolar_api.Data
{
    public class GestaoEscolarDbContext : DbContext
    {
        public GestaoEscolarDbContext(DbContextOptions<GestaoEscolarDbContext> options) : base(options) { }

        // Representa a tabela 'Alunos' no banco de dados
        public DbSet<Aluno> Alunos { get; set; }
    }
}
