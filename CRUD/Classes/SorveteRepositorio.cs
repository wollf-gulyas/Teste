using System;
using System.Collections.Generic;
using TESTE.Sorvete.Interfaces;

namespace TESTE.Sorvete
{
	public class SorveteRepositorio : IRepositorio<Sorvete>
	{
        private List<Sorvete> listaSorvete = new List<Sorvete>();
		
		public void Atualiza(int id, Sorvete objeto)
		{
			listaSorvete[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSorvete[id].Excluir();
		}

		public void Insere(Sorvete objeto)
		{
			listaSorvete.Add(objeto);
		}

		public List<Sorvete> Lista()
		{
			return listaSorvete;
		}

		public int ProximoId()
		{
			return listaSorvete.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSorvete[id];
		}
	}
}