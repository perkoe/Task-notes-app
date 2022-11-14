using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class NoteTaker : Form
    {
        //access the backend  for dataGridView
        DataTable notes = new DataTable();

        //keeping track if i am editing the note or not
        bool editing = false;


        public NoteTaker()
        {
            InitializeComponent();
        }
        private void NoteTaker_Load_1(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            //pointing to datasource so it can update the display
            previousNotes.DataSource = notes;
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {  
            //in case no one is cliking on a note
            try
            {
                    //access notes.the rows in the datatable[name of data grid view.the ceel user selected.refernces the index in data grid view]. and it deletes it
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();

            }
            catch(Exception ex) { Console.WriteLine("Not a valid note"); }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {       //bring up the notes  we have stored
            TitleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            //because if the user loads the notes he wants to probably edit it aswell
            editing = true;
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            //we want to cear out and start from scratch
            TitleBox.Text = "";
            noteBox.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
               //if editing is true we know the user changes the ntoes and save new changes(overwrite the last note)
            if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = TitleBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {//if editing is not true i save whatever is in the current note field
                notes.Rows.Add(TitleBox.Text, noteBox.Text);
            }

            TitleBox.Text = "";
            noteBox.Text = "";
            editing = false;

        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TitleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }


    }

}
