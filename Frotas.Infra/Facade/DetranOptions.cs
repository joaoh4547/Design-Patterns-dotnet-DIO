using System;
using System.Collections.Generic;
using System.Text;

namespace Frotas.Infra.Facade
{
     public class DetranOptions
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string VistoriaUri { get; set; }
        public int QuantidadeDeDiasAgendamento { get; set; }
    }
}
