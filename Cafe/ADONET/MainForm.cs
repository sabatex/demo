using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADONET
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet2.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.restorantDataSet2.items);
            // TODO: This line of code loads data into the 'restorantDataSet2.details' table. You can move, or remove it, as needed.
            this.detailsTableAdapter.Fill(this.restorantDataSet2.details);
            // TODO: This line of code loads data into the 'restorantDataSet2.sources' table. You can move, or remove it, as needed.
            this.sourcesTableAdapter.Fill(this.restorantDataSet2.sources);
            // TODO: This line of code loads data into the 'restorantDataSet2.waiters' table. You can move, or remove it, as needed.
            this.waitersTableAdapter.Fill(this.restorantDataSet2.waiters);
            // TODO: This line of code loads data into the 'restorantDataSet1.abonent' table. You can move, or remove it, as needed.
            this.abonentTableAdapter.Fill(this.restorantDataSet1.abonent);
            // TODO: This line of code loads data into the 'restorantDataSet.order' table. You can move, or remove it, as needed.
            this.orderTableAdapter.Fill(this.restorantDataSet.order);
         }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void waitersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            var a = e.NewObject; 
        }

        private void waitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Waiters();
            f.Show();
        }

        private void abonentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Abonents();
            f.Show();
        }

        private void sourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new DestinationSources();
            f.Show();
        }


        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            var f = new Order();
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new Order(orderBindingSource.Current);
            f.Show();
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new itemsForm();
            f.Show();
        }

        private void clientCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ClientCard();
            f.Show();
        }

        private void orderBindingSource_PositionChanged(object sender, EventArgs e)
        {
            var r = orderBindingSource.Current as DataRowView;
            int id = 0;
            if (r != null)
            {
                id = (int)r["id"];
            }
            this.detailsBindingSource.Filter = $"order_id={id}";
        }
    }
}
