using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Models
{
    public class GameModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        public string Price { get; set; }

        public string NewPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
