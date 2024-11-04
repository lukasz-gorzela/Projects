
namespace Randomix
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
            this.DodajOsobebutton = new System.Windows.Forms.Button();
            this.LosujParyButton = new System.Windows.Forms.Button();
            this.RzutKostkaButton = new System.Windows.Forms.Button();
            this.ImieTextBox = new System.Windows.Forms.TextBox();
            this.ListaOsobListBox = new System.Windows.Forms.ListBox();
            this.LosujTrojkiButton = new System.Windows.Forms.Button();
            this.UsunOsobeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DodajOsobebutton
            // 
            this.DodajOsobebutton.Location = new System.Drawing.Point(380, 58);
            this.DodajOsobebutton.Name = "DodajOsobebutton";
            this.DodajOsobebutton.Size = new System.Drawing.Size(146, 70);
            this.DodajOsobebutton.TabIndex = 0;
            this.DodajOsobebutton.Text = "dodaj osobe";
            this.DodajOsobebutton.UseVisualStyleBackColor = true;
            this.DodajOsobebutton.Click += new System.EventHandler(this.DodajOsobeButton_Click);
            // 
            // LosujParyButton
            // 
            this.LosujParyButton.Location = new System.Drawing.Point(562, 58);
            this.LosujParyButton.Name = "LosujParyButton";
            this.LosujParyButton.Size = new System.Drawing.Size(170, 70);
            this.LosujParyButton.TabIndex = 1;
            this.LosujParyButton.Text = "losuj pary";
            this.LosujParyButton.UseVisualStyleBackColor = true;
            this.LosujParyButton.Click += new System.EventHandler(this.LosujParyButton_Click);
            // 
            // RzutKostkaButton
            // 
            this.RzutKostkaButton.Location = new System.Drawing.Point(992, 64);
            this.RzutKostkaButton.Name = "RzutKostkaButton";
            this.RzutKostkaButton.Size = new System.Drawing.Size(160, 64);
            this.RzutKostkaButton.TabIndex = 2;
            this.RzutKostkaButton.Text = "rzut kostka";
            this.RzutKostkaButton.UseVisualStyleBackColor = true;
            this.RzutKostkaButton.Click += new System.EventHandler(this.RzutKostkaButton_Click);
            // 
            // ImieTextBox
            // 
            this.ImieTextBox.Location = new System.Drawing.Point(40, 58);
            this.ImieTextBox.Name = "ImieTextBox";
            this.ImieTextBox.Size = new System.Drawing.Size(266, 31);
            this.ImieTextBox.TabIndex = 3;
            // 
            // ListaOsobListBox
            // 
            this.ListaOsobListBox.FormattingEnabled = true;
            this.ListaOsobListBox.ItemHeight = 25;
            this.ListaOsobListBox.Location = new System.Drawing.Point(40, 206);
            this.ListaOsobListBox.Name = "ListaOsobListBox";
            this.ListaOsobListBox.Size = new System.Drawing.Size(266, 304);
            this.ListaOsobListBox.TabIndex = 4;
            // 
            // LosujTrojkiButton
            // 
            this.LosujTrojkiButton.Location = new System.Drawing.Point(757, 58);
            this.LosujTrojkiButton.Name = "LosujTrojkiButton";
            this.LosujTrojkiButton.Size = new System.Drawing.Size(197, 70);
            this.LosujTrojkiButton.TabIndex = 5;
            this.LosujTrojkiButton.Text = "losuj grupy";
            this.LosujTrojkiButton.UseVisualStyleBackColor = true;
            this.LosujTrojkiButton.Click += new System.EventHandler(this.LosujTrojkiButton_Click);
            // 
            // UsunOsobeButton
            // 
            this.UsunOsobeButton.Location = new System.Drawing.Point(380, 160);
            this.UsunOsobeButton.Name = "UsunOsobeButton";
            this.UsunOsobeButton.Size = new System.Drawing.Size(146, 63);
            this.UsunOsobeButton.TabIndex = 7;
            this.UsunOsobeButton.Text = "usun osobe";
            this.UsunOsobeButton.UseVisualStyleBackColor = true;
            this.UsunOsobeButton.Click += new System.EventHandler(this.UsunOsobeButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1312, 781);
            this.Controls.Add(this.UsunOsobeButton);
            this.Controls.Add(this.LosujTrojkiButton);
            this.Controls.Add(this.ListaOsobListBox);
            this.Controls.Add(this.ImieTextBox);
            this.Controls.Add(this.RzutKostkaButton);
            this.Controls.Add(this.LosujParyButton);
            this.Controls.Add(this.DodajOsobebutton);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DodajOsobebutton;
        private System.Windows.Forms.Button LosujParyButton;
        private System.Windows.Forms.Button RzutKostkaButton;
        private System.Windows.Forms.TextBox ImieTextBox;
        private System.Windows.Forms.ListBox ListaOsobListBox;
        private System.Windows.Forms.Button LosujTrojkiButton;
        private System.Windows.Forms.Button UsunOsobeButton;
    }
}

