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
    public partial class ClientCard : Form
    {
        public ClientCard()
        {
            InitializeComponent();
        }

        private void ClientCard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.ClientCards' table. You can move, or remove it, as needed.
            this.clientCardsTableAdapter.Fill(this.restorantDataSet.ClientCards);
            restorantDataSet.ClientCards.TableNewRow += newRow;

        }

        private void newRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["Id"] = Guid.NewGuid();
        }
    }
}
