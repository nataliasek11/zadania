using System;
using System.ComponentModel;
using Zadanie3;

namespace Zadanie3
{
    public class MediaItem : INotifyPropertyChanged
    {
        private string tytul;
        private string autorRezyser;
        private string wydawcaStudio;
        private Nosnik nosnik;
        private DateTime dataWydania;

        public MediaItem()
        {
            DataWydania = DateTime.Now;
        }

        public string Tytul
        {
            get => tytul;
            set
            {
                tytul = value;
                OnPropertyChanged(nameof(Tytul));
            }
        }

        public string AutorRezyser
        {
            get => autorRezyser;
            set
            {
                autorRezyser = value;
                OnPropertyChanged(nameof(AutorRezyser));
            }
        }

        public string WydawcaStudio
        {
            get => wydawcaStudio;
            set
            {
                wydawcaStudio = value;
                OnPropertyChanged(nameof(WydawcaStudio));
            }
        }

        public Nosnik Nosnik
        {
            get => nosnik;
            set
            {
                nosnik = value;
                OnPropertyChanged(nameof(Nosnik));
            }
        }

        public DateTime DataWydania
        {
            get => dataWydania;
            set
            {
                dataWydania = value;
                OnPropertyChanged(nameof(DataWydania));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}