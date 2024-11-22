﻿using colabAPI.Business.Models.Entities;
using colabAPI.Business.DTOs;
using colabAPI.Business.Repository.Interfaces;
using colabAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace colabAPI.Business.Repository.Implementations
{
    public class BolsaRepository : IBolsaRepository, IDisposable
    {
        private readonly ApplicationDbContext _DbContext;

        public BolsaRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        
        public async Task<IEnumerable<BolsaDTO>> GetAllAsync()
        {
            return _DbContext.Bolsas
                .Include(b => b.Pesquisador)
                .Select(b => new BolsaDTO
                {
                    Id = b.Id,
                    Valor = b.Valor,
                    DataInicio = b.DataInicio,
                    DataFim = b.DataFim,
                    DataPrevistaFim = b.DataPrevistaFim,
                    Ativo = b.Ativo,
                    Categoria = b.Categoria,
                    PesquisadorId = b.PesquisadorId,
                }).ToList();
        }
        
        public async Task<BolsaDTO> GetByIdAsync(int id)
        {
            var bolsa = _DbContext.Bolsas
                .Include(b => b.Pesquisador)
                .FirstOrDefault(b => b.Id == id);

            if (bolsa == null) return null;

            return new BolsaDTO
            {
                Id = bolsa.Id,
                Valor = bolsa.Valor,
                DataInicio = bolsa.DataInicio,
                DataFim = bolsa.DataFim,
                DataPrevistaFim = bolsa.DataPrevistaFim,
                Ativo = bolsa.Ativo,
                Categoria = bolsa.Categoria,
                PesquisadorId = bolsa.PesquisadorId,
               };
        }
        
        public async Task AddAsync(Bolsa bolsa)
        {
            _DbContext.Bolsas.Add(bolsa);
        }
        
        public async Task UpdateAsync(Bolsa bolsa)
        {
            if (bolsa == null || bolsa.Id <= 0)
            {
                throw new ArgumentException("Invalid bolsa data");
            }


            var existeBolsa = _DbContext.Bolsas.Find(bolsa.Id);

            if (existeBolsa != null)
            {
                _DbContext.Entry(existeBolsa).CurrentValues.SetValues(bolsa);
            }
            else
            {
                throw new KeyNotFoundException("Bolsa not found");
            }
            
            _DbContext.SaveChanges();
        }
        
        public async Task DeleteAsync(int bolsaID)
        {
            var bolsa = _DbContext.Bolsas.Find(bolsaID);
            if (bolsa != null)
            {
                _DbContext.Bolsas.Remove(bolsa);
            }
        }
        
        public async Task Save()
        {
            _DbContext.SaveChanges();
        }
        
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _DbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
