using System;
using System.Collections.Generic;

namespace Frotas.Domain
{
    public interface IVeiculoRepository
    {
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
    }
}
