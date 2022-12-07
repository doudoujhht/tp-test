using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;
using System.IO;
using System.Text;

namespace ViewModel
{
    public class ViewModelMusique : INotifyPropertyChanged
    {
        private Lecteur _lecteurMusique;
        private BackgroundWorker _backgroundWorker;   // Un thread pour exécuter la lecture en arrière-plan


        public string TempsRestant => _lecteurMusique.IsPlaying || _lecteurMusique.IsPaused ? _lecteurMusique.GetRemainingTime() : "00:00";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ViewModelMusique()
        {
            _lecteurMusique = new Lecteur();
        }

        #region Code pour faire jouer le fichier audio

        public void Play()
        {
            string path = "assets/intro-transition.wav"; // Il faudra changer ça pour les vrais fichiers
            _lecteurMusique.Play(path);
            PartirThread();
            OnPropertyChanged();
        }

        private void PartirThread()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += Attendre;
            _backgroundWorker.ProgressChanged += PropagerTemps;
            _backgroundWorker.RunWorkerCompleted += ProchaineChanson;
            _backgroundWorker.RunWorkerAsync();
        }

        private void PropagerTemps(object? sender, ProgressChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TempsRestant));
        }


        private void Attendre(object? sender, DoWorkEventArgs e)
        {

            while (_lecteurMusique.IsActive)
            {
                System.Threading.Thread.Sleep(20);
                _backgroundWorker.ReportProgress(0);
            }
        }

        private void ProchaineChanson(object? sender, RunWorkerCompletedEventArgs e)
        {
            // Traitement requis quand la chanson est terminée
        }

        #endregion
    }
}