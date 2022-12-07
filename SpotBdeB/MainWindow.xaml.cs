using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;
using Microsoft.Win32;
using System.Diagnostics;

namespace SpotBdeB
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand PlayCommand = new RoutedCommand();
        public static RoutedCommand AjouterListeCmd = new RoutedCommand();
        
        private ViewModelMusique _viewModelMusique;

        public MainWindow()
        {
            _viewModelMusique = new ViewModelMusique();
            InitializeComponent();
            DataContext = _viewModelMusique;
        }

        private void PlayCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PlayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        { 
            _viewModelMusique.Play();
        }

        private void AjouterListe_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void AjouterListe_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowCreerListe windowAjouterListe = new WindowCreerListe(_viewModelMusique);
            windowAjouterListe.ShowDialog();
        }
    }
}
