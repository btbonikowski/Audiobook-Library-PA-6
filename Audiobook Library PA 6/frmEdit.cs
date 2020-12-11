using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audiobook_Library_PA_6
{
    public partial class frmEdit : Form // Edit and new book class
    {

        private Book myBook;
        private string cwid;
        private string mode;
        public frmEdit(Object tempBook, string tempMode, string tempCwid) // Lets the user choose what mode
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e) // if mode is edit, this will run
        {
            if(mode == "edit")
            {
                // Rewrites the data
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtLengthData.Text = myBook.length.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;

                //pbCover.Load(myBook.cover);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the program 
        }

        private void btnSave_Click(object sender, EventArgs e) // Saves everything in the program by editing the property of the Book list
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.cwid = cwid;
            pbCover.Load(myBook.cover);

            BookFile.SaveBook(myBook, cwid, mode); // Saves the book to the file 

            // Informs the user that the content was saved by generating a new message box 
            MessageBox.Show("Content was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
