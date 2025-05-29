using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;
using WPF_LoginForm.ViewModels;
using WPF_LoginForm.CustomControls;
using WPF_LoginForm.Core;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        private StoreViewModel _viewModel;
        public StoreView()
        {
            InitializeComponent();
            _viewModel = new StoreViewModel();
            this.DataContext = _viewModel; 
            LoadGamesFromCollection();
        }
        private void LoadGamesFromCollection()
        {
            StackPanel.Children.Clear();
            foreach (GameModel game in _viewModel.Games)
            {
                var border = new Border
                {   
                    Margin = new Thickness(0,0,0,10),
                    Padding = new Thickness(5)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) }); 
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); 
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });

                var image = new Image
                {
                    Source = new BitmapImage(new Uri(game.ImagePath, UriKind.RelativeOrAbsolute)),
                    Width = 200,
                    Height = 80,
                };
                Grid.SetColumn(image, 0);
                grid.Children.Add(image);

                var label = new TextBlock
                {
                    Text = game.Title,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10, 0, 0, 0),
                    FontSize = 24,
                    Foreground = Brushes.White
                };
                Grid.SetColumn(label, 1);
                grid.Children.Add(label);

                var label2 = new TextBlock
                {
                    Text = game.Price,
                    VerticalAlignment= VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0,0,105,0),
                    FontSize = 15,
                    Foreground= Brushes.White,
                };
                Grid.SetColumn(label2, 1);
                grid.Children.Add(label2);

                var modernButton = new CustomControls.ModernButton
                {
                    ButtonContent = "Buy",
                    Width = 50,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(360,0,0,0),
                };
                modernButton.Click += (s, e) =>
                {
                    _viewModel.AddToOwnership(game);
                };

                Grid.SetColumn(modernButton, 1); 
                grid.Children.Add(modernButton);

                border.Child = grid;
                StackPanel.Children.Add(border);
            }
        }
    }
}