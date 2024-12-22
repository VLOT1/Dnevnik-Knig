using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proga
{
    public partial class BookAdd : Form
    {
        MainScreen mainScreen;
        //Storage storage;
        public string name;
        public string genre;
        public string text;
        public string emotions;
        public string author;

        public Image cover;
        public int score;

        private bool isInternalChange = false;

        public BookAdd(Storage storage, MainScreen mainScreen)
        {
            InitializeComponent();
            //this.storage = storage;
            this.mainScreen = mainScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            cover = mainScreen.AddImage();
            UISetImage();
        }
        private void UISetImage()
        {
            pictureBox1.Image = cover;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            collectInfo();
            if(text.Length == 0)
                text = "Не указано";

            if (name.Length == 0)
                name = "Не указано";

            if (genre.Length == 0)
                genre = "Не указано";

            if (author.Length == 0)
                author = "Не указано";

            mainScreen.saveEverything(author, name, genre, cover, text, score, emotions);
            this.Close();
        }
        private void collectInfo()
        {
            name = textBox1.Text;
            genre = textBox2.Text;
            text = textBox5.Text;
            author = textBox3.Text;
            emotions = $"Happy {trackBar1.Value}; Sad {trackBar2.Value}; Surprised {trackBar3.Value}; Angry {trackBar4.Value}; Scared {trackBar5.Value}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isInternalChange) return;

            CheckBox currentCheckBox = (CheckBox)sender;
            int currentTag = int.Parse(currentCheckBox.Tag.ToString());

            if (currentCheckBox.Checked)
            {
                score = currentTag;

                isInternalChange = true;
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is CheckBox checkBox && (int.Parse(checkBox.Tag.ToString()) != currentTag))
                    {
                        checkBox.Checked = false;
                    }
                }
                isInternalChange = false;
            }
            else
            {
                score = 0;
            }
        }

        private void BookAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
