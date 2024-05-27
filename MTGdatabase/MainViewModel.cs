using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input; // For ICommand
using MagicCardDatabase.Commands; // Create this class to hold the RelayCommand

namespace MagicCardDatabase
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ScryfallApiService scryfallService = new ScryfallApiService();
        private string _searchTerm;

        public ObservableCollection<MagicCard> SearchResults { get; } = new ObservableCollection<MagicCard>();

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new RelayCommand(async _ => await SearchAsync());
        }

        private async Task SearchAsync()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                SearchResults.Clear();
                var results = await scryfallService.SearchCards(SearchTerm);
                foreach (var card in results)
                {
                    SearchResults.Add(card);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
