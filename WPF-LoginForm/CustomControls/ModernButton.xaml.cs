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

namespace WPF_LoginForm.CustomControls
{
    /// <summary>
    /// Interaction logic for ModernButton.xaml
    /// </summary>
    public partial class ModernButton : UserControl
    {
        public static readonly DependencyProperty ButtonContentProperty =
        DependencyProperty.Register("ButtonContent", typeof(object), typeof(ModernButton), new PropertyMetadata(null));

        public object ButtonContent
        {
            get => GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        public event RoutedEventHandler Click;

        public ModernButton()
        {
            InitializeComponent();
        }
        protected virtual void OnClick()
        {
            Click?.Invoke(this, new RoutedEventArgs());
        }
        private void InternalButton_Click(object sender, RoutedEventArgs e)
        {
            OnClick();
        }
    }
}
