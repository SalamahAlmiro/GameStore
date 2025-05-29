using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    public class DiscountsViewModel : ViewModelBase
    {
        private readonly IGameRepository _gameRepository;
        private ObservableCollection<GameModel> _games;

        public IGameRepository GameRepository { get; set; }
        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set { _games = value; OnPropertyChanged(nameof(Games)); }
        }
        public DiscountsViewModel()
        {
            _gameRepository = new GameRepository();
            LoadGames();
        }
        private void LoadGames()
        {
            var games = _gameRepository.GetDiscounted();
            Games = new ObservableCollection<GameModel>(games);
        }
        public void AddToOwnership(String Title)
        {
            try
            {
                string username = Thread.CurrentPrincipal.Identity.Name;
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO [Ownership] (Title, Username) VALUES (@Title, @Username)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Username", username);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Game added to your library!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        protected SqlConnection GetConnection()
        {
            String _connectionString = "Server=(local); Database=TestDataBase; Integrated Security=true";
            return new SqlConnection(_connectionString);
        }
    }
}
