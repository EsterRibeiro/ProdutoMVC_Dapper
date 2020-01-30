using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCRUD_Dapper.Models
{
    public class Produto
    {
        public Produto(int id, string nome, string fabricante, string codigoDeBarras, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Fabricante = fabricante;
            CodigoDeBarras = codigoDeBarras;
            Preco = preco;
            Estoque = estoque;
        }

        public Produto() { }


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string CodigoDeBarras { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
