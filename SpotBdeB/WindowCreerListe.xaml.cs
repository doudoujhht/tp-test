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
using ViewModel;

namespace SpotBdeB
{
    public partial class WindowCreerListe : Window
    {
        public static RoutedCommand AnnulerOperationCommand = new RoutedCommand();

        private ViewModelMusique _viewModelMusique;
        public WindowCreerListe(ViewModelMusique viewModelMusique)
        {
            _viewModelMusique = viewModelMusique;
            InitializeComponent();
        }
        
        private void AnnulerOperationCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AnnulerOperationCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
