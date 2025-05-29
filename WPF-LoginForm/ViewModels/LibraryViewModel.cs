using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        private readonly GameRepository _gameRepository;

        public ObservableCollection<GameModel> Games { get; }

        public LibraryViewModel(string username)
        {
            _gameRepository = new GameRepository();
            Games = new ObservableCollection<GameModel>(_gameRepository.GetGameByOwner(username));
        }
    }
}
