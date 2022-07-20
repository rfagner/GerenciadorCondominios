using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.BLL.Models
{
    public class HistoricoRecursos
    {
        public int HistoricoRecursosId { get; set; }
        public decimal Valor { get; set; }
        public Tipos Tipo { get; set; }
        public int Dia { get; set; }
        public int MesId { get; set; }
        public virtual Mes Mes { get; set; }
        public int Ano { get; set; }
    }

    public enum Tipos
    {
        Entrada, Saida
    }
}
