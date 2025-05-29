using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Models
{
    public interface IGameRepository
    {
        void add(GameModel game);
        void delete(GameModel game);
        List<GameModel> GetAll();

        List<GameModel> GetGameByOwner(string username);

        List<GameModel> GetDiscounted();
    }
}
