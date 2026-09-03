using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET
{
    public partial class Waiters : Form
    {
        public Waiters()
        {
            InitializeComponent();
        }

        private void Waiters_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.waiters' table. You can move, or remove it, as needed.
            this.waitersTableAdapter.Fill(this.restorantDataSet.waiters);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.waitersTableAdapter.Update(this.restorantDataSet.waiters);
        }

        private void waitersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //SqlCommand cmdNewID = new SqlCommand("SELECT IDENT_CURRENT('waiters')",
            //this.waitersTableAdapter.Connection);
           // SqlCommand cmdNewID = new SqlCommand("SELECT MAX(id) from waiters",
           //this.waitersTableAdapter.Connection);

           //this.waitersTableAdapter.Connection.Open();
           //var id = (int)cmdNewID.ExecuteScalar();
           //this.waitersTableAdapter.Connection.Close();

           // var ds = this.waitersBindingSource.DataSource as DataView;
           // var t = ds.  ddNew(); 
           // t["id"] = id + 1;
           // e.NewObject = t;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //SqlCommand cmdNewID = new SqlCommand("SELECT MAX(id) from waiters",this.waitersTableAdapter.Connection);

            //this.waitersTableAdapter.Connection.Open();
            //var id = (int)cmdNewID.ExecuteScalar();
            //this.waitersTableAdapter.Connection.Close();



            ////var t = this.restorantDataSet.waiters.NewRow();

            ////e.Row.Cells["id"].Value = (int)id + 1;
            //var x = this.waitersBindingSource.Current as DataRowView;
            //x["id"] = id + 1;


        }
    }
}
