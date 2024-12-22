using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Proga
{
    public partial class MainScreen : Form
    {
        private DBClass DBClass;
        private BookAdd bookAdd;
        private Settings settings;
        private Storage storage;
        private Statistics statistics;

        public List<Book> books;

        private bool isProgrammaticCheck = false;
        private int previousIndex = 155;

        public List<Book> searchBooks = new List<Book>();
        public List<Book> sortedBooks = new List<Book>();
        public enum SortCriteria
        {
            Genre,
            Score,
            Author,
            Title
        }
        public enum SortOrder
        {
            Ascending,
            Descending
        }
        public MainScreen()
        {
            InitializeComponent();
            this.DBClass = new DBClass();
            this.storage = new Storage();
            this.books = getBooksFromBD();
            populateListBox();
            LockAllControlsExceptListBox(this); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void добавитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookAdd = new BookAdd(storage, this);
            bookAdd.Show();
            isProgramChanging = true;
            listBox1.Items.Clear();
            isProgramChanging = false;
            populateListBox();
        }
        public Image AddImage()
        {
            Image prevImage = pictureBox2.Image;
            Image image = LoadImageFromComputer();
            if (image is null)
            {
                Console.WriteLine("Debug: prevImage is used");
                return prevImage;
            }
            return image;
        }
        private Image LoadImageFromComputer()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    return (Image.FromFile(selectedFile));
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                return null;
            }
        }
        public void saveEverything(string author, string Name, string Genre, Image cover, string text, int score, string emotions)
        {
            books.Add(new Book(author, Name, Genre, cover, text, score, emotions));
            books.Last().AddToBD(DBClass);
            addBookToListBox(books.Last());
        }
        private List<Book> getBooksFromBD()
        {
            return DBClass.LoadBooks();
        }
        private void populateListBox()
        {
            foreach (Book book in books)
            {
                addBookToListBox(book);
            }
        }
        private void addBookToListBox(Book book)
        {
            listBox1.Items.Add(book.GetName());
        }
        bool isProgramChanging = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProgramChanging == true) return;
            Console.WriteLine("Index:" + listBox1.SelectedIndex);
            UnLockAllControlsExceptListBox(this);
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex == previousIndex || selectedIndex == -1) return;

            previousIndex = selectedIndex;

            Book selectedBook;
            int Idbook;
            if (searchBooks.Count > 0)
            {
                selectedBook = searchBooks[selectedIndex];
            }
            else if (sortedBooks.Count > 0)
            {
                selectedBook = sortedBooks[selectedIndex];
            }
            else
            {
                selectedBook = books[selectedIndex];
            }

            int ID = selectedBook.GetID();
            Console.WriteLine(ID);
            textBox1.Text = selectedBook.GetText();
            textBox2.Text = selectedBook.GetName();
            textBox3.Text = selectedBook.GetGenre();
            textBox4.Text = selectedBook.GetAuthor();

            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            int score = selectedBook.GetScore();
            isProgrammaticCheck = true;

            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.Checked = false;
            }
            if (score >= 1 && score <= 5)
            {
                checkBoxes[score - 1].Checked = true;
            }

            isProgrammaticCheck = false;
            pictureBox2.Image = selectedBook.GetCover();
            setEmotionsScales(parseEmotions(selectedBook.GetEmotions()));
        }
        private int[] parseEmotions(string emotions)
        {
            int[] emotionValues = new int[5];
            string[] parts = emotions.Split(';');
            int[] values = parts.Select(part =>
            {
                string number = System.Text.RegularExpressions.Regex.Match(part, @"\d+").Value;
                return int.Parse(number);
            }).ToArray();
            return values;
        }
        private void setEmotionsScales(int[] emotionValues)
        {
            trackBar1.Value = emotionValues[0];
            trackBar2.Value = emotionValues[1];
            trackBar3.Value = emotionValues[2];
            trackBar4.Value = emotionValues[3];
            trackBar5.Value = emotionValues[4];
        }
        public int[] GetEmotionValues(Book book)
        {
            return parseEmotions(book.emotions);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int ID = books[listBox1.SelectedIndex].GetID();
            books[ID].SetName(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int ID = books[listBox1.SelectedIndex].GetID();
            books[ID].SetGenre(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int ID = books[listBox1.SelectedIndex].GetID();
            books[ID].SetAuthor(textBox4.Text);
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (isProgrammaticCheck)
            //    return;

            CheckBox currentCheckBox = (CheckBox)sender;
            int currentTag = int.Parse(currentCheckBox.Tag.ToString());
            int ID = books[listBox1.SelectedIndex].GetID();
            if (currentCheckBox.Checked)
            {
                books[ID].SetScore(currentTag);
                //isProgrammaticCheck = true; // 
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is CheckBox checkBox && (int.Parse(checkBox.Tag.ToString()) != currentTag))
                    {
                        checkBox.Checked = false;
                    }
                }
                //isProgrammaticCheck = false;
            }
            else
            {
                books[ID].SetScore(0);
            }
        }
        private void LockAllControlsExceptListBox(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (!(control is ListBox) && !(control is ToolStrip) && !(control.Tag == "noblock"))
                {
                    control.Enabled = false;
                }
            }
        }
        private void UnLockAllControlsExceptListBox(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (!(control is ListBox))
                {
                    control.Enabled = true;
                }
            }
        }
        private void UpdateEmotions()
        {
            string emotions = $"Happy {trackBar1.Value}; Sad {trackBar2.Value}; Surprised {trackBar3.Value}; Angry {trackBar4.Value}; Scared {trackBar5.Value}";
            int ID = books[listBox1.SelectedIndex].GetID();
            books[ID].SetEmotions(emotions);
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            UpdateEmotions();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBClass.SaveBooks(books);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Название 0
        //Автор 1
        //Оценка 2
        //Жанр 3
        private void backfromsort()
        {
            listBox1.Items.Clear();
            populateListBox();
        }
        private void moveToFirst()
        {
            if (listBox1.Items.Count == 0)
            {
                LockAllControlsExceptListBox(this);
            } else
            {
                //isProgramChanging = true;
                listBox1.SelectedIndex = 0;
                //isProgramChanging = false;
            }
        }
        private bool areyousure(string text)
        {
            DialogResult result = MessageBox.Show(
               text,
               "Подтверждение",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
           );

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else return false;
            }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!areyousure("Вы уверены что хотите выполнить поиск?"))
            {
                return;
            }
            sortedBooks.Clear();    
            isProgramChanging = true;
            listBox1.Items.Clear();
            isProgramChanging = false;
            searchBooks.Clear();
            
            string searchText = search.Text.ToLower();

            if (comboBox1.SelectedIndex != -1)
            {
                foreach (Book book in books)
                {
                    bool match = false;
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            match = book.name.ToLower().Contains(searchText);
                            break;
                        case 1:
                            match = book.author.ToLower().Contains(searchText);
                            break;
                        case 2:
                            match = book.score.ToString().Contains(searchText);
                            break;
                        case 3:
                            match = book.genre.ToLower().Contains(searchText);
                            break;
                    }
                    if (match)
                    {
                        searchBooks.Add(book);
                        string displayText;
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                displayText = book.name;
                                break;
                            case 1:
                                displayText = $"{book.name} - {book.author}";
                                break;
                            case 2:
                                displayText = $"{book.name} - {book.score}";
                                break;
                            case 3:
                                displayText = $"{book.name} - {book.genre}";
                                break;
                            default:
                                displayText = book.name;
                                break;
                        }
                        listBox1.Items.Add(displayText);
                    }
                }
            }
            if (searchBooks.Count == 0)
            {
                foreach (Book book in books)
                {
                    listBox1.Items.Add(book.name);
                }
            }
            if (searchBooks.Count > 0)
            {
               
            }
            moveToFirst();
        }

        private List<Book> SortBooks(List<Book> books, SortCriteria criteria, SortOrder order)
        {
            IOrderedEnumerable<Book> sortedBooks;
            DebugBookList(books);
            if (criteria == SortCriteria.Author)
            {
                sortedBooks = order == SortOrder.Ascending
                    ? books.OrderBy(book => book.GetAuthor(), StringComparer.OrdinalIgnoreCase)
                    : books.OrderByDescending(book => book.GetAuthor(), StringComparer.OrdinalIgnoreCase);
            }
            else if (criteria == SortCriteria.Title)
            {
                sortedBooks = order == SortOrder.Ascending
                    ? books.OrderBy(book => book.GetName(), StringComparer.OrdinalIgnoreCase)
                    : books.OrderByDescending(book => book.GetName(), StringComparer.OrdinalIgnoreCase);
            }
            else if (criteria == SortCriteria.Genre)
            {
                sortedBooks = order == SortOrder.Ascending
                    ? books.OrderBy(book => book.GetGenre(), StringComparer.OrdinalIgnoreCase)
                    : books.OrderByDescending(book => book.GetGenre(), StringComparer.OrdinalIgnoreCase);
            }
            else if (criteria == SortCriteria.Score)
            {
                sortedBooks = order == SortOrder.Ascending
                    ? books.OrderBy(book => book.GetScore())
                    : books.OrderByDescending(book => book.GetScore());
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(criteria), "Invalid sort criteria");
            }

            return sortedBooks.ToList();
        }
        private void SortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!areyousure("Вы уверены что хотите выполнить сортировку?")) 
            {
                return;
            }
            searchBooks.Clear();
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem != null)
            {
                SortCriteria criteria = SortCriteria.Genre;
                SortOrder order = SortOrder.Ascending;

                switch (clickedItem.Tag)
                {
                    case "genreAsc":
                        criteria = SortCriteria.Genre;
                        order = SortOrder.Ascending;
                        break;
                    case "genreDesc":
                        criteria = SortCriteria.Genre;
                        order = SortOrder.Descending;
                        break;
                    case "scoreAsc":
                        criteria = SortCriteria.Score;
                        order = SortOrder.Ascending;
                        break;
                    case "scoreDesc":
                        criteria = SortCriteria.Score;
                        order = SortOrder.Descending;
                        break;
                    case "authorAsc":
                        criteria = SortCriteria.Author;
                        order = SortOrder.Ascending;
                        break;
                    case "authorDesc":
                        criteria = SortCriteria.Author;
                        order = SortOrder.Descending;
                        break;
                    case "titleAsc":
                        criteria = SortCriteria.Title;
                        order = SortOrder.Ascending;
                        break;
                    case "titleDesc":
                        criteria = SortCriteria.Title;
                        order = SortOrder.Descending;
                        break;
                }
                //MessageBox.Show("Сортировка по: " + criteria + " " + order);
                List<Book> sortedBooks = SortBooks(books, criteria, order);
                UpdateBookList(sortedBooks, criteria);
                this.sortedBooks = sortedBooks;
                DebugBookList(sortedBooks);
                moveToFirst();
            }
        }
        private void UpdateBookList(List<Book> books, SortCriteria criteria)
        {
            isProgramChanging = true;
            listBox1.Items.Clear();
            isProgramChanging = false;
            foreach (Book book in books)
            {
                string bookInfo;
                switch (criteria)
                {
                    case SortCriteria.Author:
                        bookInfo = $"{book.GetName()} - {book.GetAuthor()}";
                        break;
                    case SortCriteria.Genre:
                        bookInfo = $"{book.GetName()} - {book.GetGenre()}";
                        break;
                    case SortCriteria.Score:
                        bookInfo = $"{book.GetName()} - {book.GetScore()}";
                        break;
                    case SortCriteria.Title:
                        bookInfo = $"{book.GetName()}";
                        break;
                    default:
                        bookInfo = $"{book.GetName()} - Unknown";
                        break;
                }
                Console.WriteLine($"Adding to ListBox: {bookInfo}");
                listBox1.Items.Add(bookInfo);
            }
        }
        private void DebugBookList(List<Book> books)
        {
            foreach (var book in listBox1.Items)
            {
                string bookInfo = book.ToString();
                Console.WriteLine($"ListBox content: {bookInfo}");
            }
        }

        private void отображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings = new Settings(this);
            settings.Show();
        }
        public void clearListBox1()
        {
            isProgramChanging = true;
            listBox1.Items.Clear();
            isProgramChanging = false;
        }
        public void addStringToListBox1(string stringer)
        {
            listBox1.Items.Add((string)stringer);
        }
        public List<Book> GetsearchBooks()
        {
            return searchBooks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image cover = AddImage();
            pictureBox2.Image = cover; 
        }

        private void статистикаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            statistics = new Statistics(this, books);
            statistics.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (searchBooks.Count > 0)
            {
                int ID = searchBooks[listBox1.SelectedIndex].GetID();
                books[ID].text = textBox1.Text;
            }
            else if (sortedBooks.Count > 0)
            {
                int ID = sortedBooks[listBox1.SelectedIndex].GetID();
                books[ID].text = textBox1.Text;
            }
            else
            {
                int ID = books[listBox1.SelectedIndex].GetID();
                books[ID].text = textBox1.Text;
            }
        }
        private void deletee() {
            int selectedIndex = listBox1.SelectedIndex;
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить выбранный элемент?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (listBox1.SelectedItem != null)
                {
                    listBox1.Items.RemoveAt(selectedIndex);
                    books.RemoveAt(selectedIndex);
                }
                moveToFirst();
            }
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deletee();
        }
        private void saveBook()
        {
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 }; //Так это изи фикс чекай
            int selectedIndex = listBox1.SelectedIndex;
            Book selectedBook;
            if (searchBooks.Count > 0)
            {
                selectedBook = searchBooks[selectedIndex];
            }
            else if (sortedBooks.Count > 0)
            {
                selectedBook = sortedBooks[selectedIndex];
            }
            else
            {
                selectedBook = books[selectedIndex];
            }
            int ID = selectedBook.GetID();
            if (textBox1.Text.Length == 0)
                textBox1.Text = "Не указано"; // текст
            books[ID].SetText(textBox1.Text);

            if (textBox2.Text.Length == 0)
                textBox2.Text = "Не указано"; // название
            books[ID].SetName(textBox2.Text);

            if (textBox3.Text.Length == 0)
                textBox3.Text = "Не указано"; // жанр
            books[ID].SetGenre(textBox3.Text);

            if (textBox4.Text.Length == 0)
                textBox4.Text = "Не указано"; // автор
            books[ID].SetAuthor(textBox4.Text);

            books[ID].SetCover(pictureBox2.Image); // обложка
            UpdateEmotions(); // шкалы
            foreach (CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked) books[ID].SetScore(int.Parse(checkBox.Tag.ToString())); // оценка
            }
            //isProgramChanging = true;
            //listBox1.SelectedIndex = -1;
            //isProgramChanging = false;
            MessageBox.Show("Книга сохранена.");
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveBook();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            deletee(); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) 
            {
                saveBook();
            }
        }
    }
}
