using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using WPF_LoginForm.Models;

namespace WPF_LoginForm.Repositories
{
    public class GameRepository : RepositoryBase, IGameRepository
    {
        public void add(GameModel game)
        {
            throw new NotImplementedException();
        }

        public void delete(GameModel game)
        {
            throw new NotImplementedException();
        }

        public List<GameModel> GetAll()
        {
            var games = new List<GameModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Games]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var game = new GameModel
                        {
                            Title = reader["Title"].ToString(),
                            Descript = reader["Descript"].ToString(),
                            Price = reader["Price"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                        };
                        games.Add(game);
                    }
                }
            }
            return games;
        }

        public List<GameModel> GetGameByOwner(string username)
        {
            var getgamecommand = new SqlCommand();
            var games = new List<GameModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT g.Title, g.Descript, g.Price, g.ImagePath FROM Ownership o INNER JOIN Games g ON o.Title = g.Title WHERE o.Username = @username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var game = new GameModel
                        {
                            Title = reader["Title"].ToString(),
                            Descript = reader["Descript"].ToString(),
                            Price = reader["Price"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),

                        };
                        games.Add(game);
                    }
                }
            }
            return games;
        }

        public List<GameModel> GetDiscounted() 
        { 
            var games = new List<GameModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open(); 
                command.Connection = connection;
                command.CommandText = "SELECT g.Title, g.Descript, g.Price, d.NewPrice, g.ImagePath FROM Discounts d INNER JOIN Games g ON d.Title = g.Title";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var game = new GameModel
                        {
                            Title = reader["Title"].ToString(),
                            Descript = reader["Descript"].ToString(),
                            Price = reader["Price"].ToString(),
                            NewPrice = reader["NewPrice"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                        };
                        games.Add(game);
                    }
                }
            }
            return games; 
        }

    }
}
