using MagicCardDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MagicCardDatabase
{
    public partial class MainWindow : Window
    {
        private readonly List<MagicCard> _allCards = new List<MagicCard>();
        private bool isDarkMode = false;
        private MagicCardDatabase.ThemeManager themeManager = new ThemeManager();

        public MainWindow()
        {
            
            InitializeComponent();
            themeManager.ApplyTheme(themeManager.Themes[0], Application.Current.Resources);
            DataContext = new MainViewModel();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllCards();
           UpdateCardList();

        }

        private void LoadAllCards()
        {
      
            
        }

        private void UpdateCardList()
        {
            cardListBox.ItemsSource = _allCards;
            cardListBox.Items.Refresh();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            IEnumerable<MagicCard> filteredCards = _allCards;

            var selectedItem = searchCriteriaComboBox.SelectedItem as ComboBoxItem;
            string selectedCriteria = selectedItem?.Content.ToString();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                switch (selectedCriteria)
                {
                    case "Name":
                        filteredCards = _allCards.Where(card => card.Name.ToLower().Contains(searchText));
                        break;
                    case "Number":
                        filteredCards = _allCards.Where(card => card.CollectorNumber.ToString().Contains(searchText));
                        break;
                    case "Set":
                        filteredCards = _allCards.Where(card => card.Set.ToLower().Contains(searchText));
                        break;
                    case "Type":
                        filteredCards = _allCards.Where(card => card.TypeLine.ToLower().Contains(searchText)); // Use TypeLine
                        break;
                    case "Rarity":
                        filteredCards = _allCards.Where(card => card.Rarity.ToLower().Contains(searchText));
                        break;
                }
            }

            // Update the ListBox to show only the filtered results
            cardListBox.ItemsSource = filteredCards.ToList();
            cardListBox.Items.Refresh();
        }

        

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == (SolidColorBrush)FindResource("PlaceholderBrush"))
            {
                textBox.Text = "";
                textBox.Foreground = (SolidColorBrush)FindResource("LightModeForeground"); // Use LightModeForeground instead of Brushes.Black
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetPlaceholder(textBox, GetPlaceholderText(textBox));
            }
        }


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.Foreground = (SolidColorBrush)FindResource("PlaceholderBrush");
            }
        }
  
        private string GetPlaceholderText(TextBox textBox)
        {
            if (textBox == nameTextBox) return "Card Name";
            if (textBox == numberTextBox) return "Card Number";
            if (textBox == typeTextBox) return "Card Type";
            if (textBox == setTextBox) return "Card Set";
            if (textBox == rarityTextBox) return "Card Rarity";
            if (textBox == searchTextBox) return "Search..."; // Add placeholder for search box
            return string.Empty;
        }

        private void LightModeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            themeManager.ApplyTheme(themeManager.Themes[0], Application.Current.Resources); // Apply "Light" theme
        }

        private void DarkModeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            themeManager.ApplyTheme(themeManager.Themes[1], Application.Current.Resources); // Apply "Dark" theme
        }



    }
}
