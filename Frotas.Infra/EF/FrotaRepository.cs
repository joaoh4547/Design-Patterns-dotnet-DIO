using Frotas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frotas.Infra.EF
{
   public class FrotaRepository : IVeiculoRepository
    {
        private readonly FrotaContext _context;

        public FrotaRepository(FrotaContext context)
        {
            _context = context;
        }

        public void Add(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public Veiculo GetById(Guid id)
        {
            return _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        }

        public void Update(Veiculo veiculo)
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
