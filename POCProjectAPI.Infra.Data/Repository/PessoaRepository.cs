using Dapper;
using Microsoft.EntityFrameworkCore;
using POCProjectAPI.Domain.Interfaces;
using POCProjectAPI.Domain.Models;
using POCProjectAPI.Infra.Data.Context;
using System.Data.Common;

namespace POCProjectAPI.Infra.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        protected readonly AppDBContext _context;

        public PessoaRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task<Pessoa> GetPessoa(int pessoaId)
        {
            var query = @"SELECT * FROM POCAPI_Pessoas p
                          LEFT JOIN POCAPI_Contatos c on p.PessoaId = c.PessoaId
                          WHERE p.PessoaId = @pessoaId";
            var result = await ObterConexao().QueryAsync<Pessoa, Contato, Pessoa>(query,
                (pessoa, contato) =>
                {
                    if (contato != null)
                        pessoa.Contatos.Add(contato);
                    return pessoa;
                }, new { pessoaId },
                splitOn: "PessoaId, ContatoId");

            return result.FirstOrDefault();
            //var pessoa = await _context.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            var query = "SELECT * FROM POCAPI_Pessoas";
            var result = await ObterConexao().QueryAsync<Pessoa>(query);

            return result;
            //return await _context.Pessoas.ToListAsync();
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasContatos()
        {
            var query = @"SELECT * FROM POCAPI_Pessoas p 
                          LEFT JOIN POCAPI_Contatos c on p.PessoaId = c.PessoaId";

            var result = await ObterConexao().QueryAsync<Pessoa, Contato, Pessoa>(query,
                (pessoa, contato) =>
                {
                    if (contato != null)
                        pessoa.Contatos.Add(contato);
                    return pessoa;
                }, splitOn: "PessoaId, ContatoId");

            return result;
            //return await _context.Pessoas.Include(p => p.Contatos).ToListAsync();
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}