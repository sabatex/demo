using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET
{
    public partial class Abonents : Form
    {
        public Abonents()
        {
            InitializeComponent();
        }

        private void Abonents_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.abonent' table. You can move, or remove it, as needed.
            this.abonentTableAdapter.Fill(this.restorantDataSet.abonent);

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            SqlCommand cmdNewID = new SqlCommand("SELECT IDENT_CURRENT('abonent')",
                        this.abonentTableAdapter.Connection);
            this.abonentTableAdapter.Connection.Open();



            var nid = cmdNewID.ExecuteScalar();
            var id = (int)(decimal)nid +1;
            this.abonentTableAdapter.Connection.Close();

            var d = this.abonentBindingSource.Current as DataRowView;
            d["id"] = id;



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.abonentTableAdapter.Update(this.restorantDataSet.abonent);
        }
    }
}
