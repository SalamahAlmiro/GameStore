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
using System.Reflection;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Interaction logic for Discounts.xaml
    /// </summary>
    public partial class DiscountsView : UserControl
    {
        private DiscountsViewModel _viewModel;
        public DiscountsView()
        {
            InitializeComponent();
            _viewModel = new DiscountsViewModel();
            this.DataContext = _viewModel;
            LoadDiscounted();
        }
        private void LoadDiscounted()
        {
            StackPanel.Children.Clear();
            foreach (GameModel game in _viewModel.Games)
            {
                var border = new Border
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    Padding = new Thickness(5)
                };

                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(215) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(165) });

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(460) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(320) });

                Image gameImage = new Image
                {
                    Source = new BitmapImage(new Uri(game.ImagePath, UriKind.RelativeOrAbsolute)),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                Grid.SetRow(gameImage, 1);
                Grid.SetColumn(gameImage, 1);
                grid.Children.Add(gameImage);

                TextBlock gameTitle = new TextBlock
                {
                    Text = game.Title,
                    FontSize = 25,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(5, 5, 0, 0)
                };
                Grid.SetRow(gameTitle, 2);
                Grid.SetColumn(gameTitle, 1);
                grid.Children.Add(gameTitle);

                TextBlock gameDescription = new TextBlock
                {
                    Text = game.Descript,
                    FontSize = 15,
                    FontWeight = FontWeights.Light,
                    Foreground = Brushes.LightGray,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(8, 40, 0, 0)
                };
                Grid.SetRow(gameDescription, 2);
                Grid.SetColumn(gameDescription, 1);
                grid.Children.Add(gameDescription);

                TextBlock oldPrice = new TextBlock
                {
                    Text = game.Price,
                    FontSize = 12,
                    Foreground = Brushes.Gray,
                    TextDecorations = TextDecorations.Strikethrough,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 275, 24)
                };
                Grid.SetRow(oldPrice, 2);
                Grid.SetColumn(oldPrice, 2);
                grid.Children.Add(oldPrice);

                TextBlock newPrice = new TextBlock
                {
                    Text = game.NewPrice,
                    FontSize = 18,
                    Foreground = Brushes.LightGreen,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 215, 21)
                };
                Grid.SetRow(newPrice, 2);
                Grid.SetColumn(newPrice, 2);
                grid.Children.Add(newPrice);

                var buyNowButton = new CustomControls.ModernButton
                {
                    ButtonContent = "Buy Now",
                    Height = 30,
                    Width = 80,
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 130, 20),
                };
                buyNowButton.Click += (s, e) =>
                {
                    _viewModel.AddToOwnership(game.Title);
                };
                Grid.SetRow(buyNowButton, 2);
                Grid.SetColumn(buyNowButton, 2);
                grid.Children.Add(buyNowButton);

                border.Child = grid;


                StackPanel.Children.Add(border);
            }
        }
    }
}

