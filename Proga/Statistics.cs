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
    public partial class Statistics : Form
    {
        MainScreen mainScreen;
        List<Book> books;
        int onescore = 0, twoscore = 0, threescore = 0, fourscore = 0, fivescore = 0;
        double onescoreP = 0, twoscoreP = 0, threescoreP = 0, fourscoreP = 0, fivescoreP = 0;
        double mediumtextlength = 0; int alltextlength = 0;
        int allgenres = 0;
        int allbooks = 0;
        int allauthors = 0;
        int bookswithnotext = 0;
        int nocovercounter = 0;
        int allscoressum = 0;
        string mostPopularGenre;
        string mostPopularAuthor;
        int mostFrequentScore;
        double mediumScore;
        HashSet<string> GuniqueGenres;
        HashSet<string> GuniqueAuthors;

        HashSet<string> uniqueGenres;
        HashSet<string> uniqueAuthors;
        Dictionary<string, int> genreCount;
        Dictionary<string, int> authorCount;
        int[] overallEmotionValues;

        bool isStatShowed = false;
        private string[] initialLabelTexts;

        int previousIndex = -1;
        List<Book> newbooks = new List<Book>();
        public Statistics(MainScreen mainScreen, List<Book> books)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.books = books;
            comboBox2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            GuniqueGenres = new HashSet<string>();
            GuniqueAuthors = new HashSet<string>();
            foreach (Book book in books)
            {
                GuniqueGenres.Add(book.GetGenre());
                GuniqueAuthors.Add(book.GetAuthor());
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
        //0 всё
        //1 автор
        //2 жанр
        //3 оценка
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previousIndex == comboBox1.SelectedIndex) return;
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.SelectedIndex = -1;
                comboBox2.Enabled = false;
                EveryStat(books);
                StatsForSet();
                return;
            }
            else
            {
                StatCustom(comboBox1.SelectedIndex);
            }
            previousIndex = comboBox1.SelectedIndex;
        }
        private void StatsForSet()
        {
            addInfoToLabel(MediumTextLengthLabel, mediumtextlength);
            addInfoToLabel(MPopGenre, mostPopularGenre);
            addInfoToLabel(MPopAuthor, mostPopularAuthor);
            addInfoToLabel(MPopScore, mostFrequentScore);
            addInfoToLabel(MediumScore, mediumScore);
            addInfoToLabel(Onescorelabel, onescore);
            addInfoToLabel(twoscorelabel, twoscore);
            addInfoToLabel(threescorelabel, threescore);
            addInfoToLabel(fourscorelabel, fourscore);
            addInfoToLabel(fivescorelabel, fivescore);
            addInfoToLabel(onescorelabelP, onescoreP);
            addInfoToLabel(twoscorelabelP, twoscoreP);
            addInfoToLabel(threescorelabelP, threescoreP);
            addInfoToLabel(fourscorelabelP, fourscoreP);
            addInfoToLabel(fivescorelabelP, fivescoreP);
            addInfoToLabel(TotalBooks, allbooks);
            addInfoToLabel(TotalGenres, allgenres);
            addInfoToLabel(TotalAuthors, allauthors);
            addInfoToLabel(NoCover, nocovercounter);
            addInfoToLabel(NoReviews, bookswithnotext);
        }
        private void EveryStat(List<Book> books)
        {
            InitializeCounters();

            foreach (Book book in books)
            {
                ProcessBook(book);
            }

            FinalizeStatistics();
        }

        private void InitializeCounters()
        {
            uniqueGenres = new HashSet<string>();
            uniqueAuthors = new HashSet<string>();
            genreCount = new Dictionary<string, int>();
            authorCount = new Dictionary<string, int>();
            overallEmotionValues = new int[5];
            onescore = 0; twoscore = 0; threescore = 0; fourscore = 0; fivescore = 0;
            onescoreP = 0; twoscoreP = 0; threescoreP = 0; fourscoreP = 0; fivescoreP = 0;
            mediumtextlength = 0; alltextlength = 0;
            allgenres = 0;
            allbooks = 0;
            allauthors = 0;
            bookswithnotext = 0;
            nocovercounter = 0;
            allscoressum = 0;
            mostPopularGenre = null;
            mostPopularAuthor = null;
            mostFrequentScore = 0;
            mediumScore = 0;
        }

        private void ProcessBook(Book book)
        {
            string text = book.GetText();
            string author = book.GetAuthor();
            string genre = book.GetGenre();
            int score = book.GetScore();

            allbooks++;
            CountScores(score);
            UpdateTextLength(text);
            UpdateCoverCount(book);
            UpdateEmptyTextCount(text);
            UpdateUniqueGenresAndAuthors(genre, author);
            UpdateGenreCount(genre);
            UpdateAuthorCount(author);
            UpdateEmotionValues(book);
            UpdateSumScores(score);
        }
        private void UpdateSumScores(int score)
        {
            allscoressum += score;
        }
        private void CountScores(int score)
        {
            if (score == 1) onescore++;
            else if (score == 2) twoscore++;
            else if (score == 3) threescore++;
            else if (score == 4) fourscore++;
            else if (score == 5) fivescore++;
        }

        private void UpdateTextLength(string text)
        {
            alltextlength += text.Length;
        }

        private void UpdateCoverCount(Book book)
        {
            if (book.GetCover() == null)
            {
                nocovercounter++;
            }
        }

        private void UpdateEmptyTextCount(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                bookswithnotext++;
            }
        }

        private void UpdateUniqueGenresAndAuthors(string genre, string author)
        {
            uniqueGenres.Add(genre);
            uniqueAuthors.Add(author);
        }

        private void UpdateGenreCount(string genre)
        {
            if (genreCount.ContainsKey(genre))
                genreCount[genre]++;
            else
                genreCount[genre] = 1;
        }

        private void UpdateAuthorCount(string author)
        {
            if (authorCount.ContainsKey(author))
                authorCount[author]++;
            else
                authorCount[author] = 1;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> authorsList = GuniqueAuthors.ToList();
            List<string> genresList = GuniqueGenres.ToList();
            newbooks.Clear();
            if (comboBox1.SelectedIndex == 1)
            {
                foreach (Book book in books)
                {
                    if (book.author == authorsList[comboBox2.SelectedIndex])
                    {
                        newbooks.Add(book);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                foreach (Book book in books)
                {
                    if (book.genre == genresList[comboBox2.SelectedIndex])
                    {
                        newbooks.Add(book);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                foreach (Book book in books)
                {
                    if (book.score == comboBox2.SelectedIndex + 1)
                    {
                        newbooks.Add(book);
                    }
                }
            }
            EveryStat(newbooks);
            StatsForSet();
        }

        private void UpdateEmotionValues(Book book)
        {
            int[] emotionValues = mainScreen.GetEmotionValues(book);
            for (int i = 0; i < emotionValues.Length; i++)
            {
                overallEmotionValues[i] += emotionValues[i];
            }
        }

        private void FinalizeStatistics()
        {
            allgenres = uniqueGenres.Count();
            allauthors = uniqueAuthors.Count();
            mediumtextlength = (double)alltextlength / (double)allbooks;
            mostPopularGenre = genreCount.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            mostPopularAuthor = authorCount.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            CalculateScoreStatistics();
            UpdateEmotionImage();
        }

        private void CalculateScoreStatistics()
        {
            int[] maxhelp = new int[] { onescore, twoscore, threescore, fourscore, fivescore };
            int maxscore = maxhelp.Max();
            mostFrequentScore = Array.IndexOf(maxhelp, maxscore) + 1;
            mediumScore = (double)allscoressum / allbooks;
            onescoreP = (double)onescore / allbooks * 100;
            twoscoreP = (double)twoscore / allbooks * 100;
            threescoreP = (double)threescore / allbooks * 100;
            fourscoreP = (double)fourscore / allbooks * 100;
            fivescoreP = (double)fivescore / allbooks * 100;
        }

        private void UpdateEmotionImage()
        {
            int maxIndex = Array.IndexOf(overallEmotionValues, overallEmotionValues.Max());
            switch (maxIndex)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources.kxas0u;
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources.sad;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.strange;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.angry;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.scared;
                    break;
                default:
                    pictureBox1.Image = null;
                    break;
            }
        }
        private void addInfoToLabel(Label label, int info)
        {
            string baseText = label.Text.Split(':')[0];
            label.Text = baseText + ": " + info.ToString();
        }
        private void addInfoToLabel(Label label, string info)
        {
            string baseText = label.Text.Split(':')[0];
            label.Text = baseText + ": " + info;
        }
        private void addInfoToLabel(Label label, double info)
        {
            string baseText = label.Text.Split(':')[0];
            label.Text = baseText + ": " + info.ToString("0.00");
        }
        private void StatCustom(int index)
        {
            comboBox2.Items.Clear();
            comboBox2.Enabled = true;
            if (index is 1)
            {
                foreach (string author in GuniqueAuthors) {
                    comboBox2.Items.Add(author);
                }
            } else if (index is 2)
            {
                foreach (string genre in GuniqueGenres)
                {
                    comboBox2.Items.Add(genre);
                }
            }
            else
            {
                for (int i = 1;i < 6; i++)
                {
                    comboBox2.Items.Add(i.ToString());
                }
            }
        }
 
    }
}
