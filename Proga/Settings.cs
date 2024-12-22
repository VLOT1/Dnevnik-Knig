using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Proga
{
    public partial class Settings : Form
    {
        MainScreen mainScreen;

        public Settings(MainScreen mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyCustomMaskToBookList();
        }

        private void ApplyCustomMaskToBookList()
        {
            string mask = textBoxSettings.Text;

            if (string.IsNullOrWhiteSpace(mask) || !IsMaskValid(mask))
            {
                MessageBox.Show("Пожалуйста, укажите хотя бы один из следующих параметров в маске: Название, Автор, Жанр, Оценка.", "Ошибка маски");
                return;
            }

            mainScreen.clearListBox1();
            var booksToDisplay = mainScreen.searchBooks.Count > 0 ? mainScreen.searchBooks : mainScreen.books;

            foreach (Book book in booksToDisplay)
            {
                string formattedString = FormatBookString(book, mask);
                mainScreen.addStringToListBox1(formattedString);
            }
        }

        private bool IsMaskValid(string mask)
        {
            return mask.Contains("Название") || mask.Contains("Автор") || mask.Contains("Жанр") || mask.Contains("Оценка");
        }
        public string GetCustomMask()
        {
            return textBoxSettings.Text;
        }
        private string FormatBookString(Book book, string mask)
        {
            return mask.Replace("Название", book.GetName())
                       .Replace("Автор", book.GetAuthor())
                       .Replace("Жанр", book.GetGenre())
                       .Replace("Оценка", book.GetScore().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainScreen.clearListBox1();
            DisplayDefaultBookList();
        }

        private void DisplayDefaultBookList()
        {
            var booksToDisplay = mainScreen.searchBooks.Count > 0 ? mainScreen.searchBooks : mainScreen.books;

            foreach (Book book in booksToDisplay)
            {
                mainScreen.addStringToListBox1(book.GetName());
            }
        }
    }
}
