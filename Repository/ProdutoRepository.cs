using Dapper;
using ProjetoCRUD_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCRUD_Dapper.Repository
{
    public class ProdutoRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void CriarProduto(Produto produto)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    Produto prod = new Produto();

                    connection.Open();

                    var parametros = new DynamicParameters();

                    parametros.Add("Id", prod.Id, DbType.AnsiString);
                    parametros.Add("Nome_Produto", prod.Nome, DbType.Int32);
                    parametros.Add("Fabricante", prod.Fabricante, DbType.Int32);
                    parametros.Add("CodigoBarras", prod.CodigoDeBarras, DbType.Int32);
                    parametros.Add("Preco", prod.Preco, DbType.Int32);
                    parametros.Add("Estoque", prod.Estoque, DbType.Int32);

                    var execute = connection.Execute("INSERT INTO Produtos (Id, Nome_Produto, Fabricante, CodigoBarras, Preco, Estoque) " +
                    "Values (@Id, @Nome_Produto, @Fabricante, @CodigoBarras, @Preco, @Estoque)", parametros);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void DeletarProduto(Produto produto)
        {

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE Produtos SET Nome_Produto = @Nome_produto, Fabricante = @Fabricante, " +
                        "CodigoBarras = @CodigoBarras, Preco, @Preco, Estoque = @Estoque" +
                        "WHERE Id = @Id";

                    db.Execute(query, produto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public IEnumerable<Produto> ListarProdutos()
        {

            List<Produto> prods = new List<Produto>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {


                return db.Query<Produto>
                ("Select * From Produtos").ToList();

              
            }

        }


        public void AtualizarProduto() 
        {
            using (var connection = new SqlConnection(connectionString))
            {

                try
                {
                    Produto prod = new Produto();

                    connection.Open();

                    var parametros = new DynamicParameters();

                    parametros.Add("Id", prod.Id, DbType.AnsiString);
                    parametros.Add("Nome_Produto", prod.Nome, DbType.Int32);
                    parametros.Add("Fabricante", prod.Fabricante, DbType.Int32);
                    parametros.Add("CodigoBarras", prod.CodigoDeBarras, DbType.Int32);
                    parametros.Add("Preco", prod.Preco, DbType.Int32);
                    parametros.Add("Estoque", prod.Estoque, DbType.Int32);

                    var execute = connection.Execute("UPDATE Produtos set (Id = @Id, Nome_Produto = @Nome_Produto," +
                        " Fabricante = @Fabricante, CodigoBarras = @CodigoBarras, Preco = @Preco, Estoque = @Estoque)");

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        }


        public void DetalharProduto() { }

    }    
    
}
