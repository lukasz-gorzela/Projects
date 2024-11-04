using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randomix
{
    public partial class Form1 : Form
    {
        private List<string> listaOsob = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DodajOsobeButton_Click(object sender, EventArgs e)
        {
            string imie = ImieTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(imie))
            {
                if (!listaOsob.Contains(imie))
                {
                    listaOsob.Add(imie);
                    ImieTextBox.Clear();
                    AktualizujListeOsob();
                }
                else
                {
                    MessageBox.Show("Osoba o tym imieniu już istnieje na liście.");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź imię osoby.");
            }
        }

        private void UsunOsobeButton_Click(object sender, EventArgs e)
        {
            if (ListaOsobListBox.SelectedIndex != -1)
            {
                listaOsob.RemoveAt(ListaOsobListBox.SelectedIndex);
                AktualizujListeOsob();
            }
            else
            {
                MessageBox.Show("Wybierz osobę do usunięcia.");
            }
        }

        private void AktualizujListeOsob()
        {
            ListaOsobListBox.Items.Clear();
            foreach (string osoba in listaOsob)
            {
                ListaOsobListBox.Items.Add(osoba);
            }
        }

        private void LosujParyButton_Click(object sender, EventArgs e)
        {
            if (listaOsob.Count < 2)
            {
                MessageBox.Show("Dodaj co najmniej dwie osoby do listy.");
                return;
            }

            List<string> losowaneOsoby = listaOsob.ToList();
            losowaneOsoby.Shuffle();

            string komunikat = "Wyniki losowania:\n\n";

            for (int i = 0; i < losowaneOsoby.Count; i += 2)
            {
                List<string> grupa = losowaneOsoby.GetRange(i, Math.Min(2, losowaneOsoby.Count - i));
                komunikat += string.Join(", ", grupa) + "\n";
            }

            MessageBox.Show(komunikat);
        }

        private void LosujTrojkiButton_Click(object sender, EventArgs e)
        {
            if (listaOsob.Count < 3)
            {
                MessageBox.Show("Dodaj co najmniej trzy osoby do listy.");
                return;
            }

            List<string> losowaneOsoby = listaOsob.ToList();
            losowaneOsoby.Shuffle();

            string komunikat = "Wyniki losowania trójek:\n\n";

            for (int i = 0; i < losowaneOsoby.Count; i += 3)
            {
                List<string> grupa = losowaneOsoby.GetRange(i, Math.Min(3, losowaneOsoby.Count - i));
                komunikat += string.Join(", ", grupa) + "\n";
            }

            MessageBox.Show(komunikat);
        }

        private void RzutKostkaButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int wynikRzutu = random.Next(1, 7);
            MessageBox.Show($"Wynik rzutu kostką: {wynikRzutu}");
        }

        
    }

    // Rozszerzenie metody do tasowania listy
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}