using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Proga
{
    public class DBClass
    {
        private SQLiteConnection SQLiteConn;
        public DBClass()
        {
            SQLiteConn = new SQLiteConnection();
            ConnectToDatabase("bdBooks.db");
        }
        public Image GetImageFromDatabase()
        {
            try
            {
                string query = "SELECT Cover FROM " + "Books";
                SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);
                command.Parameters.AddWithValue("0", 1);

                byte[] imageData = (byte[])command.ExecuteScalar();

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Нет данных об изображении для выбранной записи.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения из базы данных: " + ex.Message);
                return null;
            }
        }
        public void SaveImageToDatabase(Image image)
        {
            try
            {
                byte[] imageData;
                if (image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        imageData = ms.ToArray();
                    }

                    string query = "UPDATE Cover SET Cover = @Cover";
                    SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);
                    command.Parameters.AddWithValue("@Cover", imageData);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Выберите изображение перед сохранением.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения в базе данных: " + ex.Message);
            }
        }
        public void GetAdditionalDataFromDatabase(out string Name, out string Genre, out Image cover, out string text, out int score, out string emotions)
        {
            Name = string.Empty;
            Genre = string.Empty;
            cover = null;
            text = string.Empty;
            score = 0;
            emotions = string.Empty;

            string query = "SELECT Name, Genre, Cover, Text, Score, Emotions FROM Books";
            SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name"));
                    Genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? string.Empty : reader.GetString(reader.GetOrdinal("Genre"));
                    cover = reader.IsDBNull(reader.GetOrdinal("Cover")) ? null : Image.FromStream(new MemoryStream((byte[])reader["Cover"]));
                    text = reader.IsDBNull(reader.GetOrdinal("Text")) ? string.Empty : reader.GetString(reader.GetOrdinal("Text"));
                    score = reader.IsDBNull(reader.GetOrdinal("Score")) ? 0 : reader.GetInt32(reader.GetOrdinal("Score"));
                    emotions = reader.IsDBNull(reader.GetOrdinal("Emotions")) ? string.Empty : reader.GetString(reader.GetOrdinal("Emotions"));
                }
            }
        }
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            string query = "SELECT Author, Name, Genre, Cover, Text, Score, Emotions FROM Books";
            SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string author = reader.IsDBNull(reader.GetOrdinal("Author")) ? string.Empty : reader.GetString(reader.GetOrdinal("Author"));
                    string name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name"));
                    string genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? string.Empty : reader.GetString(reader.GetOrdinal("Genre"));
                    Image cover = reader.IsDBNull(reader.GetOrdinal("Cover")) ? null : Image.FromStream(new MemoryStream((byte[])reader["Cover"]));
                    string text = reader.IsDBNull(reader.GetOrdinal("Text")) ? string.Empty : reader.GetString(reader.GetOrdinal("Text"));
                    int score = reader.IsDBNull(reader.GetOrdinal("Score")) ? 0 : reader.GetInt32(reader.GetOrdinal("Score"));
                    string emotions = reader.IsDBNull(reader.GetOrdinal("Emotions")) ? string.Empty : reader.GetString(reader.GetOrdinal("Emotions"));

                    books.Add(new Book(author, name, genre, cover, text, score, emotions));
                }
            }
            return books;
        }
        public void SaveParametersToDatabase(string author, string Name, string Genre, Image cover, string text, int score, string emotions)
        {
            try
            {
                byte[] coverBytes = null;
                if (cover != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cover.Save(ms, cover.RawFormat);
                        coverBytes = ms.ToArray();
                    }
                }
                string query = "INSERT INTO Books (Author, Name, Genre, Cover, Text, Score, Emotions) " +
                               "VALUES (@Author, @Name, @Genre, @Cover, @Text, @Score, @Emotions)";
                SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);
                command.Parameters.AddWithValue("@Author", Name);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Genre", Genre);
                command.Parameters.AddWithValue("@Cover", coverBytes);
                command.Parameters.AddWithValue("@Text", text);
                command.Parameters.AddWithValue("@Score", score);
                command.Parameters.AddWithValue("@Emotions", emotions);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении параметров в базе данных: " + ex.Message);
            }
        }
        public void DeleteBookByID(int bookID)
        {
            try
            {
                string query = "DELETE FROM Books WHERE Index = @ID";
                SQLiteCommand command = new SQLiteCommand(query, SQLiteConn);
                command.Parameters.AddWithValue("@ID", bookID);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении записи из базы данных: " + ex.Message);
            }
        }

        public void ConnectToDatabase(string dbFileName)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string solutionDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
                string dbFilePath = Path.Combine(solutionDirectory, dbFileName);

                string connectionString = $"Data Source={dbFilePath};Version=3;";
                SQLiteConn.ConnectionString = connectionString;
                SQLiteConn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }
        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public void SaveBooks(List<Book> books)
        {
            using (var connection = SQLiteConn)
            {
                string deleteQuery = "DELETE FROM Books";
                using (var deleteCommand = new SQLiteCommand(deleteQuery, connection))
                {
                    deleteCommand.ExecuteNonQuery();
                }
                foreach (var book in books)
                {
                    byte[] coverBytes = book.GetCover() != null ? ImageToByteArray(book.GetCover()) : null;

                    string insertQuery = @"INSERT INTO Books (author, name, genre, cover, text, score, emotions) 
                                   VALUES (@Author, @Name, @Genre, @Cover, @Text, @Score, @Emotions)";
                    using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Author", book.GetAuthor());
                        insertCommand.Parameters.AddWithValue("@Name", book.GetName());
                        insertCommand.Parameters.AddWithValue("@Genre", book.GetGenre());
                        insertCommand.Parameters.AddWithValue("@Cover", coverBytes);
                        insertCommand.Parameters.AddWithValue("@Text", book.GetText());
                        insertCommand.Parameters.AddWithValue("@Score", book.GetScore());
                        insertCommand.Parameters.AddWithValue("@Emotions", book.GetEmotions());
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }




    }
}
