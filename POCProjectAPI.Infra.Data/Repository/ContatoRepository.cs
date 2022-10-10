using Dapper;
using Microsoft.EntityFrameworkCore;
using POCProjectAPI.Domain.Interfaces;
using POCProjectAPI.Domain.Models;
using POCProjectAPI.Infra.Data.Context;
using System.Data.Common;

namespace POCProjectAPI.Infra.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        protected readonly AppDBContext _context;

        public ContatoRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task<Contato> GetContato(int contatoId)
        {
            var query = "SELECT * FROM POCAPI_Contatos WHERE ContatoId = @contatoId";
            var result = await ObterConexao().QueryFirstOrDefaultAsync<Contato>(query, new { contatoId });

            return result;
            //var pessoa = await _context.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Contato>> GetContatos(int pessoaId)
        {
            var query = "SELECT * FROM POCAPI_Contatos WHERE PessoaId = @pessoaId";
            var result = await ObterConexao().QueryAsync<Contato>(query, new { pessoaId });

            return result;
            //return await _context.Pessoas.ToListAsync();
        }

        public async Task CreateContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContato(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContato(Contato contato)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}