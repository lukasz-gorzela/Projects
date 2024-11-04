
namespace NotesManager
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.reminderDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.setReminderButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.categoryFilterComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.notesListView = new System.Windows.Forms.ListView();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteNoteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reminderDateTimePicker
            // 
            this.reminderDateTimePicker.Location = new System.Drawing.Point(897, 37);
            this.reminderDateTimePicker.Name = "reminderDateTimePicker";
            this.reminderDateTimePicker.Size = new System.Drawing.Size(377, 31);
            this.reminderDateTimePicker.TabIndex = 29;
            this.reminderDateTimePicker.ValueChanged += new System.EventHandler(this.reminderDateTimePicker_ValueChanged);
            // 
            // setReminderButton
            // 
            this.setReminderButton.Location = new System.Drawing.Point(897, 76);
            this.setReminderButton.Name = "setReminderButton";
            this.setReminderButton.Size = new System.Drawing.Size(377, 108);
            this.setReminderButton.TabIndex = 28;
            this.setReminderButton.Text = "Ustaw Przypomnienie";
            this.setReminderButton.UseVisualStyleBackColor = true;
            this.setReminderButton.Click += new System.EventHandler(this.setReminderButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(645, 419);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(227, 98);
            this.searchButton.TabIndex = 27;
            this.searchButton.Text = "Szukaj Notatki";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // categoryFilterComboBox
            // 
            this.categoryFilterComboBox.FormattingEnabled = true;
            this.categoryFilterComboBox.Location = new System.Drawing.Point(645, 547);
            this.categoryFilterComboBox.Name = "categoryFilterComboBox";
            this.categoryFilterComboBox.Size = new System.Drawing.Size(227, 33);
            this.categoryFilterComboBox.TabIndex = 26;
            this.categoryFilterComboBox.Click += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(645, 375);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(227, 38);
            this.searchTextBox.TabIndex = 25;
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(0, 39);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(407, 717);
            this.contentTextBox.TabIndex = 24;
            // 
            // notesListView
            // 
            this.notesListView.HideSelection = false;
            this.notesListView.Location = new System.Drawing.Point(645, 39);
            this.notesListView.MultiSelect = false;
            this.notesListView.Name = "notesListView";
            this.notesListView.Size = new System.Drawing.Size(227, 309);
            this.notesListView.TabIndex = 23;
            this.notesListView.UseCompatibleStateImageBehavior = false;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(410, 76);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(173, 33);
            this.categoryComboBox.TabIndex = 22;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(410, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(175, 70);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Dodaj Notatkę";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(0, 0);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(407, 31);
            this.titleTextBox.TabIndex = 20;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(897, 401);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(377, 116);
            this.saveButton.TabIndex = 30;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(897, 545);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(377, 130);
            this.openFileButton.TabIndex = 31;
            this.openFileButton.Text = "Wczytaj";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(645, 586);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(227, 89);
            this.filterButton.TabIndex = 32;
            this.filterButton.Text = "Filtruj";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Lista Notatek";
            // 
            // DeleteNoteButton
            // 
            this.DeleteNoteButton.Location = new System.Drawing.Point(897, 234);
            this.DeleteNoteButton.Name = "DeleteNoteButton";
            this.DeleteNoteButton.Size = new System.Drawing.Size(377, 114);
            this.DeleteNoteButton.TabIndex = 34;
            this.DeleteNoteButton.Text = "Usuń Notatkę";
            this.DeleteNoteButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 755);
            this.Controls.Add(this.DeleteNoteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.reminderDateTimePicker);
            this.Controls.Add(this.setReminderButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.categoryFilterComboBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.notesListView);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.titleTextBox);
            this.Name = "Form1";
            this.Text = "NotesManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker reminderDateTimePicker;
        private System.Windows.Forms.Button setReminderButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox categoryFilterComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.ListView notesListView;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteNoteButton;
    }
}

