﻿using colab.Business.Models.Entities;
using colab.Business.Repository.Interfaces;
using colab.Data;
using Microsoft.EntityFrameworkCore;

namespace colab.Business.Repository.Implementations
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            return await _context.Projetos
                .Include(p => p.Financiador)
                .Include(p => p.Bolsas)
                .Include(p => p.HistoricoStatus)
                .ToListAsync();
        }

        public async Task<Projeto?> GetByIdAsync(int id)
        {
            return await _context.Projetos
                .Include(p => p.Financiador)
                .Include(p => p.Bolsas)
                .Include(p => p.HistoricoStatus)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projeto> AddAsync(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<Projeto> UpdateAsync(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }


        public async Task DeleteAsync(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddHistoricoStatusAsync(HistoricoProjetoStatus historicoStatus)
        {
            await _context.HistoricoStatusProjetos.AddAsync(historicoStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHistoricoStatusAsync(HistoricoProjetoStatus historico)
        {
            _context.HistoricoStatusProjetos.Update(historico);
            await _context.SaveChangesAsync();
        }
    }
}
