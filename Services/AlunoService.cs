using gestao_escolar_api.Data;
using gestao_escolar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gestao_escolar_api.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly GestaoEscolarDbContext _context;

        // Injeção do DbContext no construtor
        public AlunoService(GestaoEscolarDbContext context)
        {
            _context = context;
        }

        // --- MÉTODOS DE IMPLEMENTAÇÃO ---

        public async Task<List<Aluno>> BuscarAlunos()
        {
            // Retorna todos os alunos da tabela
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno?> BuscarAlunoPorId(int id)
        {
            // Retorna o aluno pelo Id ou null se não encontrar
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno> CadastrarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno; // Retorna o aluno com o ID gerado pelo banco
        }

        public async Task<bool> EditarAluno(Aluno aluno)
        {
            // Indica que o objeto já existe e precisa ser atualizado
            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Se o aluno não existir no banco, a atualização falhará.
                if (await BuscarAlunoPorId(aluno.AlunoId) == null)
                {
                    return false;
                }
                throw; // Lançar outras exceções de concorrência
            }
        }

        public async Task<bool> DeletarAluno(int id)
        {
            var aluno = await BuscarAlunoPorId(id);
            if (aluno == null)
            {
                return false; // Não encontrado
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
