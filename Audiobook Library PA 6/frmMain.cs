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
    public partial class frmMain : Form // Main form that shows everything to the user 
    {
        string cwid; // Takes the cwid from the first form
        List<Book> myBooks; // New list that turns the Books into a list in c#

        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid; // tempCWID to store the user's cwid
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage; // Formats the image 
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList(); // Loads all the data from Jeff's database
        }

        private void LoadList() // Method that loads all the data from Jeff's database
        {
            myBooks = BookFile.GetAllBooks(cwid); // Makes sure to only call the data from the user's CWID
            lstBooks.DataSource = myBooks;
        }

        private void lblIsbn_Click(object sender, EventArgs e)
        {

        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; // Displays the selected book

            // Trasfers the data to the text box
            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();
            txtIsbnData.Text = myBook.isbn;

            try
            {
                pbCover.Load(myBook.cover); // Loads the cover, uses a try catch in case it fails
            }

            catch
            {

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; // Runs the selected book in the edit function
            frmEdit myForm = new frmEdit(myBook, "edit", cwid); // Calls the edit function

            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }

            else
            {
                LoadList(); // Loads the book list
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the program
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; // Loads the selected book

            myBook.copies--; // Reduces the numbe of copies
            BookFile.SaveBook(myBook, cwid, "edit"); // Edits the book
            LoadList(); // Runs the list again
        }

        // Return method that lets the user add one to the book count
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        // Completely deletes the book from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid); // Removes the book using the DeleteBook method
                LoadList();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book(); // New book form 
            frmEdit myForm = new frmEdit(myBook, "new", cwid); // Calls the new book class

            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }

            else
            {
                LoadList();
            }
        }
    }
}
