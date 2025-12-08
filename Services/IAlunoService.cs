using gestao_escolar_api.Models;

namespace gestao_escolar_api.Services
{
    public interface IAlunoService
    {
        // CRUD: Read
        Task<List<Aluno>> BuscarAlunos();
        Task<Aluno?> BuscarAlunoPorId(int id);

        // CRUD: Create
        Task<Aluno> CadastrarAluno(Aluno aluno);

        // CRUD: Update
        Task<bool> EditarAluno  (Aluno aluno);

        // CRUD: Delete
        Task<bool> DeletarAluno(int id);
    }
}
