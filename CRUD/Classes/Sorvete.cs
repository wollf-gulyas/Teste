using System;

namespace TESTE.Sorvete
{
    public class Sorvete : EnBase
    {
        // Atributos
		private string Sabor { get; set; }
		private string Descricao { get; set; }
        private bool Excluido { get; set; }

		public Sorvete(int id, string sabor, string descricao)
		{
			this.Id = id;
			this.Sabor = sabor;
			this.Descricao = descricao;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            
			retorno += "Sabor: " + this.Sabor + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			
			return retorno;
		}

        public string retornaSabor()
		{
			return this.Sabor;
		}

		public int retornaId()
		{
			return this.Id;
		}

        public bool retornaExcluido()
		{
			return this.Excluido;	
		}

        public void Excluir() {
            this.Excluido = true;
        }
    }
}