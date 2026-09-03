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
    public partial class DestinationSources : Form
    {
        public DestinationSources()
        {
            InitializeComponent();
        }

        private void DestinationSources_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.sources' table. You can move, or remove it, as needed.
            this.sourcesTableAdapter.Fill(this.restorantDataSet.sources);
            this.restorantDataSet.sources.RowChanging += rowChanging;

        }

        private void rowChanging(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                SqlCommand cmdNewID = new SqlCommand("SELECT IDENT_CURRENT('sources')",
                this.sourcesTableAdapter.Connection);
                this.sourcesTableAdapter.Connection.Open();
                var nid = cmdNewID.ExecuteScalar();
                var id = (decimal)nid;
                this.sourcesTableAdapter.Connection.Close();
                e.Row["id"] = (int)id + 1;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.sourcesTableAdapter.Update(this.restorantDataSet.sources);
        }

        private void sourcesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            var a = e.NewObject;
        }

        private void sourcesBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            
        }

        private void sourcesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }
    }
}
