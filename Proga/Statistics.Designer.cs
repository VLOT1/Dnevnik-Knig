namespace Proga
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fivescorelabelP = new System.Windows.Forms.Label();
            this.onescorelabelP = new System.Windows.Forms.Label();
            this.fourscorelabelP = new System.Windows.Forms.Label();
            this.twoscorelabelP = new System.Windows.Forms.Label();
            this.threescorelabelP = new System.Windows.Forms.Label();
            this.fivescorelabel = new System.Windows.Forms.Label();
            this.Onescorelabel = new System.Windows.Forms.Label();
            this.fourscorelabel = new System.Windows.Forms.Label();
            this.twoscorelabel = new System.Windows.Forms.Label();
            this.threescorelabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NoCover = new System.Windows.Forms.Label();
            this.TotalBooks = new System.Windows.Forms.Label();
            this.NoReviews = new System.Windows.Forms.Label();
            this.TotalGenres = new System.Windows.Forms.Label();
            this.TotalAuthors = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MediumScore = new System.Windows.Forms.Label();
            this.MPopScore = new System.Windows.Forms.Label();
            this.MediumTextLengthLabel = new System.Windows.Forms.Label();
            this.MPopEmotion = new System.Windows.Forms.Label();
            this.MPopGenre = new System.Windows.Forms.Label();
            this.MPopAuthor = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 396);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(15, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(153, 21);
            this.comboBox2.TabIndex = 16;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Всё",
            "По автору",
            "По жанру",
            "По оценке"});
            this.comboBox1.Location = new System.Drawing.Point(15, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "Критерий статистики:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fivescorelabelP);
            this.groupBox4.Controls.Add(this.onescorelabelP);
            this.groupBox4.Controls.Add(this.fourscorelabelP);
            this.groupBox4.Controls.Add(this.twoscorelabelP);
            this.groupBox4.Controls.Add(this.threescorelabelP);
            this.groupBox4.Controls.Add(this.fivescorelabel);
            this.groupBox4.Controls.Add(this.Onescorelabel);
            this.groupBox4.Controls.Add(this.fourscorelabel);
            this.groupBox4.Controls.Add(this.twoscorelabel);
            this.groupBox4.Controls.Add(this.threescorelabel);
            this.groupBox4.Location = new System.Drawing.Point(328, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(316, 161);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Оценки:";
            // 
            // fivescorelabelP
            // 
            this.fivescorelabelP.AutoSize = true;
            this.fivescorelabelP.Location = new System.Drawing.Point(132, 136);
            this.fivescorelabelP.Name = "fivescorelabelP";
            this.fivescorelabelP.Size = new System.Drawing.Size(28, 13);
            this.fivescorelabelP.TabIndex = 16;
            this.fivescorelabelP.Text = "В %:";
            // 
            // onescorelabelP
            // 
            this.onescorelabelP.AutoSize = true;
            this.onescorelabelP.Location = new System.Drawing.Point(132, 16);
            this.onescorelabelP.Name = "onescorelabelP";
            this.onescorelabelP.Size = new System.Drawing.Size(28, 13);
            this.onescorelabelP.TabIndex = 12;
            this.onescorelabelP.Text = "В %:";
            // 
            // fourscorelabelP
            // 
            this.fourscorelabelP.AutoSize = true;
            this.fourscorelabelP.Location = new System.Drawing.Point(132, 106);
            this.fourscorelabelP.Name = "fourscorelabelP";
            this.fourscorelabelP.Size = new System.Drawing.Size(28, 13);
            this.fourscorelabelP.TabIndex = 15;
            this.fourscorelabelP.Text = "В %:";
            // 
            // twoscorelabelP
            // 
            this.twoscorelabelP.AutoSize = true;
            this.twoscorelabelP.Location = new System.Drawing.Point(132, 46);
            this.twoscorelabelP.Name = "twoscorelabelP";
            this.twoscorelabelP.Size = new System.Drawing.Size(28, 13);
            this.twoscorelabelP.TabIndex = 13;
            this.twoscorelabelP.Text = "В %:";
            // 
            // threescorelabelP
            // 
            this.threescorelabelP.AutoSize = true;
            this.threescorelabelP.Location = new System.Drawing.Point(132, 76);
            this.threescorelabelP.Name = "threescorelabelP";
            this.threescorelabelP.Size = new System.Drawing.Size(28, 13);
            this.threescorelabelP.TabIndex = 14;
            this.threescorelabelP.Text = "В %:";
            // 
            // fivescorelabel
            // 
            this.fivescorelabel.AutoSize = true;
            this.fivescorelabel.Location = new System.Drawing.Point(6, 136);
            this.fivescorelabel.Name = "fivescorelabel";
            this.fivescorelabel.Size = new System.Drawing.Size(88, 13);
            this.fivescorelabel.TabIndex = 11;
            this.fivescorelabel.Text = "Всего оценок 5:";
            // 
            // Onescorelabel
            // 
            this.Onescorelabel.AutoSize = true;
            this.Onescorelabel.Location = new System.Drawing.Point(6, 16);
            this.Onescorelabel.Name = "Onescorelabel";
            this.Onescorelabel.Size = new System.Drawing.Size(88, 13);
            this.Onescorelabel.TabIndex = 7;
            this.Onescorelabel.Text = "Всего оценок 1:";
            // 
            // fourscorelabel
            // 
            this.fourscorelabel.AutoSize = true;
            this.fourscorelabel.Location = new System.Drawing.Point(6, 106);
            this.fourscorelabel.Name = "fourscorelabel";
            this.fourscorelabel.Size = new System.Drawing.Size(88, 13);
            this.fourscorelabel.TabIndex = 10;
            this.fourscorelabel.Text = "Всего оценок 4:";
            // 
            // twoscorelabel
            // 
            this.twoscorelabel.AutoSize = true;
            this.twoscorelabel.Location = new System.Drawing.Point(6, 46);
            this.twoscorelabel.Name = "twoscorelabel";
            this.twoscorelabel.Size = new System.Drawing.Size(88, 13);
            this.twoscorelabel.TabIndex = 8;
            this.twoscorelabel.Text = "Всего оценок 2:";
            // 
            // threescorelabel
            // 
            this.threescorelabel.AutoSize = true;
            this.threescorelabel.Location = new System.Drawing.Point(6, 76);
            this.threescorelabel.Name = "threescorelabel";
            this.threescorelabel.Size = new System.Drawing.Size(88, 13);
            this.threescorelabel.TabIndex = 9;
            this.threescorelabel.Text = "Всего оценок 3:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NoCover);
            this.groupBox3.Controls.Add(this.TotalBooks);
            this.groupBox3.Controls.Add(this.NoReviews);
            this.groupBox3.Controls.Add(this.TotalGenres);
            this.groupBox3.Controls.Add(this.TotalAuthors);
            this.groupBox3.Location = new System.Drawing.Point(6, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 161);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дополнительные";
            // 
            // NoCover
            // 
            this.NoCover.AutoSize = true;
            this.NoCover.Location = new System.Drawing.Point(6, 136);
            this.NoCover.Name = "NoCover";
            this.NoCover.Size = new System.Drawing.Size(163, 13);
            this.NoCover.TabIndex = 11;
            this.NoCover.Text = "Количество книг без обложки:";
            // 
            // TotalBooks
            // 
            this.TotalBooks.AutoSize = true;
            this.TotalBooks.Location = new System.Drawing.Point(6, 16);
            this.TotalBooks.Name = "TotalBooks";
            this.TotalBooks.Size = new System.Drawing.Size(66, 13);
            this.TotalBooks.TabIndex = 7;
            this.TotalBooks.Text = "Всего книг:";
            // 
            // NoReviews
            // 
            this.NoReviews.AutoSize = true;
            this.NoReviews.Location = new System.Drawing.Point(6, 106);
            this.NoReviews.Name = "NoReviews";
            this.NoReviews.Size = new System.Drawing.Size(156, 13);
            this.NoReviews.TabIndex = 10;
            this.NoReviews.Text = "Количество книг без отзыва:";
            // 
            // TotalGenres
            // 
            this.TotalGenres.AutoSize = true;
            this.TotalGenres.Location = new System.Drawing.Point(6, 46);
            this.TotalGenres.Name = "TotalGenres";
            this.TotalGenres.Size = new System.Drawing.Size(81, 13);
            this.TotalGenres.TabIndex = 8;
            this.TotalGenres.Text = "Всего жанров:";
            // 
            // TotalAuthors
            // 
            this.TotalAuthors.AutoSize = true;
            this.TotalAuthors.Location = new System.Drawing.Point(6, 76);
            this.TotalAuthors.Name = "TotalAuthors";
            this.TotalAuthors.Size = new System.Drawing.Size(84, 13);
            this.TotalAuthors.TabIndex = 9;
            this.TotalAuthors.Text = "Всего авторов:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.MediumScore);
            this.groupBox2.Controls.Add(this.MPopScore);
            this.groupBox2.Controls.Add(this.MediumTextLengthLabel);
            this.groupBox2.Controls.Add(this.MPopEmotion);
            this.groupBox2.Controls.Add(this.MPopGenre);
            this.groupBox2.Controls.Add(this.MPopAuthor);
            this.groupBox2.Location = new System.Drawing.Point(328, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 200);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Основные";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(210, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // MediumScore
            // 
            this.MediumScore.AutoSize = true;
            this.MediumScore.Location = new System.Drawing.Point(6, 166);
            this.MediumScore.Name = "MediumScore";
            this.MediumScore.Size = new System.Drawing.Size(92, 13);
            this.MediumScore.TabIndex = 12;
            this.MediumScore.Text = "Средняя оценка:";
            // 
            // MPopScore
            // 
            this.MPopScore.AutoSize = true;
            this.MPopScore.Location = new System.Drawing.Point(6, 136);
            this.MPopScore.Name = "MPopScore";
            this.MPopScore.Size = new System.Drawing.Size(197, 13);
            this.MPopScore.TabIndex = 11;
            this.MPopScore.Text = "Самая часто встречающаяся оценка:";
            // 
            // MediumTextLengthLabel
            // 
            this.MediumTextLengthLabel.AutoSize = true;
            this.MediumTextLengthLabel.Location = new System.Drawing.Point(6, 16);
            this.MediumTextLengthLabel.Name = "MediumTextLengthLabel";
            this.MediumTextLengthLabel.Size = new System.Drawing.Size(126, 13);
            this.MediumTextLengthLabel.TabIndex = 7;
            this.MediumTextLengthLabel.Text = "Средняя длина отзыва:";
            // 
            // MPopEmotion
            // 
            this.MPopEmotion.AutoSize = true;
            this.MPopEmotion.Location = new System.Drawing.Point(6, 106);
            this.MPopEmotion.Name = "MPopEmotion";
            this.MPopEmotion.Size = new System.Drawing.Size(201, 13);
            this.MPopEmotion.TabIndex = 10;
            this.MPopEmotion.Text = "Самая часто встречающаюся эмоция:";
            // 
            // MPopGenre
            // 
            this.MPopGenre.AutoSize = true;
            this.MPopGenre.Location = new System.Drawing.Point(6, 46);
            this.MPopGenre.Name = "MPopGenre";
            this.MPopGenre.Size = new System.Drawing.Size(138, 13);
            this.MPopGenre.TabIndex = 8;
            this.MPopGenre.Text = "Самый популярный жанр:";
            // 
            // MPopAuthor
            // 
            this.MPopAuthor.AutoSize = true;
            this.MPopAuthor.Location = new System.Drawing.Point(6, 76);
            this.MPopAuthor.Name = "MPopAuthor";
            this.MPopAuthor.Size = new System.Drawing.Size(141, 13);
            this.MPopAuthor.TabIndex = 9;
            this.MPopAuthor.Text = "Самый популярный автор:";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 408);
            this.Controls.Add(this.groupBox1);
            this.Name = "Statistics";
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label MPopScore;
        private System.Windows.Forms.Label MPopEmotion;
        private System.Windows.Forms.Label MPopGenre;
        private System.Windows.Forms.Label MPopAuthor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label fivescorelabelP;
        private System.Windows.Forms.Label onescorelabelP;
        private System.Windows.Forms.Label fourscorelabelP;
        private System.Windows.Forms.Label twoscorelabelP;
        private System.Windows.Forms.Label threescorelabelP;
        private System.Windows.Forms.Label fivescorelabel;
        private System.Windows.Forms.Label Onescorelabel;
        private System.Windows.Forms.Label fourscorelabel;
        private System.Windows.Forms.Label twoscorelabel;
        private System.Windows.Forms.Label threescorelabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label NoCover;
        private System.Windows.Forms.Label TotalBooks;
        private System.Windows.Forms.Label NoReviews;
        private System.Windows.Forms.Label TotalGenres;
        private System.Windows.Forms.Label TotalAuthors;
        private System.Windows.Forms.Label MediumScore;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label MediumTextLengthLabel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}