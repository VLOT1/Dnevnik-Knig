using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Proga
{
    public class Book
    {
        private static int startingInt = 0;
        public int ID;
        public string author;
        public string name;
        public string genre;
        public string text;
        public Image cover;
        public int score;
        public string emotions;
        public Book(string author, string Name, string Genre, Image cover, string text, int score, string emotions) {
            this.ID = startingInt++;
            this.author = author;
            this.name = Name;
            this.genre = Genre;
            this.cover = cover;
            this.text = text;
            this.score = score;
            this.emotions = emotions;
        }
        public string GetAuthor()
        {
            return this.author;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetText()
        {
            return this.text;
        }
        public string GetEmotions()
        {
            return this.emotions;
        }
        public Image GetCover()
        {
            return this.cover;
        }
        public int GetScore()
        {
            return this.score;
        }
        public int GetID()
        {
            return this.ID;
        }
        public string GetGenre()
        {
            return this.genre;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
        public void SetEmotions(string emotions)
        {
            this.emotions = emotions;
        }
        public void SetCover(Image cover)
        {
            this.cover = cover;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }
        public void AddToBD(DBClass dbclass)
        {
            dbclass.SaveParametersToDatabase(this.author, this.name, this.genre, this.cover, this.text, this.score, this.emotions);
        }
        public void DeleteFromBD(int bookID, DBClass dbclass)
        {
            dbclass.DeleteBookByID(bookID);
        }
        public void SetGenre(string genre)
        {
            this.genre = genre;
        }
    }
}
