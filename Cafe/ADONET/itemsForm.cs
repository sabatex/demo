using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET
{
    public partial class itemsForm : Form
    {
        public itemsForm()
        {
            InitializeComponent();
        }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.restorantDataSet.items);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.itemsTableAdapter.Update(this.restorantDataSet);
        }
    }
}
