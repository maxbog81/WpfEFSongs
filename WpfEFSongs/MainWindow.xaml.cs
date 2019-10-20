using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfEFSongs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TrackContainer _container = new TrackContainer();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _container;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var track = new Track
            {
                ArtistName = ArtistNameTxt.Text,
                TrackName = TrackNameTxt.Text
            };
            _container.TrackSet.Add(track);
            _container.SaveChanges();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _container.TrackSet.Load();
        }
    }
}
