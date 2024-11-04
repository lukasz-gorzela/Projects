using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace NotesManager
{
    public partial class Form1 : Form
    {
        private List<Note> notes = new List<Note>();
        private List<Category> categories = new List<Category>();

        private const string PlaceholderTextTitle = "Tytuł:";
        private const string PlaceholderTextContent = "Notatka:";
        private const string PlaceholderTextSearch = "Szukaj:";

        private System.Windows.Forms.Timer reminderTimer;
        public Form1()
        {
            InitializeComponent();
            InitializeCategories();
            InitializeDeleteNoteButton();
            InitializeTextBox(titleTextBox, PlaceholderTextTitle);
            InitializeTextBox(contentTextBox, PlaceholderTextContent);
            InitializeTextBox(searchTextBox, PlaceholderTextSearch);


            notesListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(notesListView_ItemSelectionChanged);
            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Tick += new EventHandler(reminderTimer_Tick);
            reminderTimer.Interval = 1000; 
            reminderTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeCategoryFilterComboBox();
        }

        private void InitializeTextBox(TextBox textBox, string placeholderText)
        {
           
            textBox.Text = placeholderText;
            textBox.ForeColor = SystemColors.GrayText; 

           
            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

           
            if (textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; 
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.ForeColor = SystemColors.GrayText; 
            }
        }

        private string GetPlaceholderText(TextBox textBox)
        {
            if (textBox == titleTextBox)
            {
                return PlaceholderTextTitle;
            }
            else if (textBox == contentTextBox)
            {
                return PlaceholderTextContent;
            }
            else if (textBox == searchTextBox)
            {
                return PlaceholderTextSearch;
            }
            else
            {
                return "";
            }
        }

        private void InitializeCategoryFilterComboBox()
        {
            
            categoryFilterComboBox.Items.Add("Wszystkie");

            
            foreach (Category category in categories)
            {
                categoryFilterComboBox.Items.Add(category.Name);
            }

            
            categoryFilterComboBox.SelectedIndex = 0;
        }
        private void InitializeCategories()
        {
           
            categories.Add(new Category("Praca", Color.Yellow));
            categories.Add(new Category("Dom", Color.Green));
            categories.Add(new Category("Osobiste", Color.Blue));
            categories.Add(new Category("Szkoła", Color.Red));
            categories.Add(new Category("Zakupy", Color.Purple));
            categories.Add(new Category("Lista", Color.Brown));
            categories.Add(new Category("Przypomnienia", Color.Black));

            
            foreach (Category category in categories)
            {
                categoryComboBox.Items.Add(category.Name);
            }

            
            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            string title = titleTextBox.Text;
            string content = contentTextBox.Text;
            DateTime creationDate = DateTime.Now;
            Category selectedCategory = categories[categoryComboBox.SelectedIndex];

            Note newNote = new Note(title, content, creationDate, selectedCategory);
            notes.Add(newNote);

            if (notesListView.Items.Count > 0)
            {
                notesListView.Items[notesListView.Items.Count - 1].Selected = true;
            }

            ListViewItem item = new ListViewItem(new string[] { title, content, creationDate.ToString(), selectedCategory.Name });
            item.Tag = newNote; 
            notesListView.Items.Add(item);

            
            titleTextBox.Clear();
            contentTextBox.Clear();
        }

        private void notesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DisplaySelectedNoteContent();
        }

        private void DisplaySelectedNoteContent()
        {
            if (notesListView.SelectedItems.Count > 0)
            {
                Note selectedNote = notesListView.SelectedItems[0].Tag as Note;

                
                contentTextBox.Text = selectedNote.Content;
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            
            string searchTerm = searchTextBox.Text.ToLower();

            notesListView.Items.Clear();

            foreach (Note note in notes)
            {
                if (note.Title.ToLower().Contains(searchTerm) || note.Content.ToLower().Contains(searchTerm))
                {
                    ListViewItem item = new ListViewItem(new string[] { note.Title, note.Content, note.CreationDate.ToString(), note.Category.Name });
                    item.Tag = note;
                    notesListView.Items.Add(item);
                }
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedCategoryName = categoryFilterComboBox.SelectedItem as string;

            notesListView.Items.Clear();

            foreach (Note note in notes)
            {
                if (note.Category.Name == selectedCategoryName || selectedCategoryName == "Wszystkie")
                {
                    ListViewItem item = new ListViewItem(new string[] { note.Title, note.Content, note.CreationDate.ToString(), note.Category.Name });
                    item.Tag = note;
                    notesListView.Items.Add(item);
                }
            }
        }
        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterNotes();
        }

        private void FilterNotes()
        {
            
            string selectedCategoryName = categoryFilterComboBox.SelectedItem as string;

            notesListView.Items.Clear();

            foreach (Note note in notes)
            {
                if (selectedCategoryName == "Wszystkie" || note.Category.Name == selectedCategoryName)
                {
                    ListViewItem item = new ListViewItem(new string[] { note.Title, note.Content, note.CreationDate.ToString(), note.Category.Name });
                    item.Tag = note;
                    notesListView.Items.Add(item);
                }
            }
        }
        private void SaveNotesToFile(string filePath)
        {
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Note note in notes)
                        {
                            writer.WriteLine($"{note.Title},{note.Content},{note.CreationDate},{note.Category.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania do pliku: {ex.Message}");
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                SaveNotesToFile(filePath);
            }
        }
        private List<Note> LoadNotesFromFile(string filePath)
        {
            List<Note> loadedNotes = new List<Note>();

            try
            {
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        
                        Note loadedNote = ParseLineAndCreateNote(line);
                        if (loadedNote != null)
                        {
                            loadedNotes.Add(loadedNote);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania pliku: {ex.Message}");
            }

            return loadedNotes;
        }
        private Note ParseLineAndCreateNote(string line)
        {
            try
            {
                
                string[] parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    string title = parts[0].Trim();
                    string content = parts[1].Trim();
                    DateTime creationDate = DateTime.Parse(parts[2].Trim());
                    string categoryName = parts[3].Trim();

                    
                    Category category = categories.FirstOrDefault(c => c.Name == categoryName);

                    if (category != null)
                    {
                        
                        return new Note(title, content, creationDate, category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas przetwarzania linii: {ex.Message}");
            }

            
            return null;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            openFileDialog.Title = "Wybierz plik tekstowy do wczytania";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                
                List<Note> loadedNotes = LoadNotesFromFile(filePath);

                
                notes.AddRange(loadedNotes);

                
                foreach (Note loadedNote in loadedNotes)
                {
                    ListViewItem item = new ListViewItem(new string[] { loadedNote.Title, loadedNote.Content, loadedNote.CreationDate.ToString(), loadedNote.Category.Name });
                    item.Tag = loadedNote;
                    notesListView.Items.Add(item);
                }

                MessageBox.Show("Pomyślnie wczytano notatki z pliku.");
            }
        }
        private void InitializeDeleteNoteButton()
        {
            DeleteNoteButton.Click += DeleteNoteButton_Click;
        }

        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            if (notesListView.SelectedItems.Count > 0)
            {
                Note selectedNote = notesListView.SelectedItems[0].Tag as Note;

                
                categoryComboBox.Items.Remove(selectedNote.Title);
                notes.Remove(selectedNote);

                
                DisplayNotes();
            }
            else
            {
                MessageBox.Show("Proszę wybrać notatkę przed usunięciem.");
            }
        }
        private void DisplayNotes()
        {
            
            notesListView.Items.Clear();

            foreach (Note note in notes)
            {
                ListViewItem item = new ListViewItem(new string[] { note.Title, note.Content, note.CreationDate.ToString(), note.Category.Name });
                item.Tag = note;
                notesListView.Items.Add(item);
            }
        }
        private void setReminderButton_Click(object sender, EventArgs e)
        {
           
            if (notesListView.SelectedItems.Count > 0)
            {
                Note selectedNote = notesListView.SelectedItems[0].Tag as Note;

                
                DateTime reminderDateTime = reminderDateTimePicker.Value;

                
                selectedNote.ReminderDateTime = reminderDateTime;

                
                MessageBox.Show($"Ustawiono przypomnienie dla notatki '{selectedNote.Title}' na {reminderDateTime}");
            }
            else
            {
                MessageBox.Show("Proszę wybrać notatkę przed ustawieniem przypomnienia.");
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reminderDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            reminderDateTimePicker.Format = DateTimePickerFormat.Custom;
            reminderDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
        }
        private async void reminderTimer_Tick(object sender, EventArgs e)
        {
            foreach (Note note in notes)
            {
                if (!note.IsReminderDisplayed && note.ReminderDateTime != DateTime.MinValue && DateTime.Now.ToUniversalTime() >= note.ReminderDateTime.ToUniversalTime())
                {

                    reminderTimer.Stop();

                   
                    MessageBox.Show($"Przypomnienie dla notatki '{note.Title}'!");

                   
                    note.IsReminderDisplayed = true;

                   
                    await Task.Delay(5000); 

                    reminderTimer.Start();
                }
            }
        }
    }

    public class Note
    {
        public string Title { get; }
        public string Content { get; }
        public DateTime CreationDate { get; }
        public Category Category { get; }
        public DateTime ReminderDateTime { get; set; }
        public bool IsReminderDisplayed { get; set; }

        public Note(string title, string content, DateTime creationDate, Category category)
        {
            Title = title;
            Content = content;
            CreationDate = creationDate;
            Category = category;
        }
    }

    public class Category
    {
        public string Name { get; }
        public Color Color { get; }

        public Category(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
    

