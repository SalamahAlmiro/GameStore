using System;
using System.Collections.Generic;
using System.Linq;
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
using WPF_LoginForm.ViewModels;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        public LibraryView()
        {
            InitializeComponent();
            DataContextChanged += LibraryView_DataContextChanged;
        }

        private void LibraryView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is LibraryViewModel viewModel)
            {
                LoadGamesFromCollection(viewModel.Games);
            }
        }
        private void LoadGamesFromCollection(IEnumerable<GameModel> games)
        {
            StackPanel.Children.Clear();
            foreach (GameModel game in games)
            {
                var border = new Border
                {
                    Margin = new Thickness(0, 0, 0, 10),
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

                var modernButton = new CustomControls.ModernButton
                {
                    ButtonContent = "Play",
                    Width = 50,
                    Height = 30,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(360, 0, 0, 0)
                };
                modernButton.Click += (s, e) =>
                {
                    MessageBox.Show($"Launching {label.Text}");
                };

                /*modernButton.Click += (s, e) =>
                {
                    try
                    {
                        MessageBox.Show($"Launching {label.Text}");
                        string pathToExecutable = @"C:\Users\salam\Desktop\Risk of Rain 2.url";

                        System.Diagnostics.Process.Start(pathToExecutable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to launch the program: {ex.Message}");
                    }
                };*/

                Grid.SetColumn(modernButton, 1);
                grid.Children.Add(modernButton);

                border.Child = grid;


                StackPanel.Children.Add(border);
            }
        }
    }
}
