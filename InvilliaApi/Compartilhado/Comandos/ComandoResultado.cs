using System;
using System.Collections.Generic;
using System.Text;

namespace Compartilhado.Comandos
{
    public class ComandoResultado : IComandoResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }

        public ComandoResultado(bool sucesso, string mensagem, object data = null)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }
    }
}
