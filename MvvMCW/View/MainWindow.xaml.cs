using MvvMCW.Service;
using MvvMCW.ViewModel;

namespace MvvMCW.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MovieViewModel(new JsonFileService());
        }
    }
}