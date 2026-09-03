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
using System.Linq;

namespace ADONET
{
    public partial class Order : Form
    {
        private RestorantDataSet.orderRow order;

        public Order()
        {
            InitializeComponent();
        }

        public Order(object order)
        {
            InitializeComponent();
            var d = order as DataRowView;
            this.order = (RestorantDataSet.orderRow)d.Row;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restorantDataSet.items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.restorantDataSet.items);
            // TODO: This line of code loads data into the 'restorantDataSet.sources' table. You can move, or remove it, as needed.
            this.sourcesTableAdapter.Fill(this.restorantDataSet.sources);
            // TODO: This line of code loads data into the 'restorantDataSet.abonent' table. You can move, or remove it, as needed.
            this.abonentTableAdapter.Fill(this.restorantDataSet.abonent);
            // TODO: This line of code loads data into the 'restorantDataSet.waiters' table. You can move, or remove it, as needed.
            this.waitersTableAdapter.Fill(this.restorantDataSet.waiters);
            // TODO: This line of code loads data into the 'restorantDataSet.details' table. You can move, or remove it, as needed.
            this.detailsTableAdapter.Fill(this.restorantDataSet.details);
            
            
            this.orderTableAdapter.Fill(this.restorantDataSet.order);
            if (order == null)
            {
                order = restorantDataSet.order.NeworderRow();
                order.abonent_id = 1;
                order.waiter_id = 1;
                order.source_id = 1;
                order.time_order = DateTime.Now;
                order.end_order = DateTime.Now;
                this.restorantDataSet.order.AddorderRow(order);
            }

            abonent.SelectedItem = order.abonent_id;
            waiter.SelectedItem = order.waiter_id;
            item_source.SelectedItem = order.source_id;
            time_order.Value = order.time_order;
            end_order.Value = order.end_order;

            this.detailsBindingSource.Filter = $"order_id={order.id}";
            restorantDataSet.details.TableNewRow += newRow;
        }

        private void newRow(object sender, DataTableNewRowEventArgs e)
        {
            //SqlCommand cmdNewID = new SqlCommand("SELECT IDENT_CURRENT('details')",
            //    this.detailsTableAdapter.Connection);
            ////SqlCommand cmdNewID = new SqlCommand("SELECT MAX(id) from waiters",
            ////this.waitersTableAdapter.Connection);


            //this.detailsTableAdapter.Connection.Open();
            //var id = (int)(decimal)cmdNewID.ExecuteScalar();
            //this.detailsTableAdapter.Connection.Close();

            //e.Row["id"] = id + 1;
            e.Row["order_id"] = order.id;
        }

        bool cellChange = false;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cellChange) return;
            cellChange = true;
            var c = e.ColumnIndex;
            var dg = sender as DataGridView;
            if (dg.CurrentCell != null)
            {
                var col = dg.Columns[c];
                var row = dg.CurrentRow;
                switch (col.DataPropertyName)
                {
                    case "items_id":
                        var id = (int)dg.CurrentCell.Value;
                        var dr = restorantDataSet.items.FindByid(id);
                        row.Cells["priceDataGridViewTextBoxColumn"].Value = dr.price;
                        if (row.Cells["countDataGridViewTextBoxColumn"].Value != System.DBNull.Value)
                            row.Cells["billDataGridViewTextBoxColumn"].Value = (decimal)row.Cells["countDataGridViewTextBoxColumn"].Value * dr.price;

                        break;
                    case "price":
                        if (row.Cells["countDataGridViewTextBoxColumn"].Value != System.DBNull.Value)
                            row.Cells["billDataGridViewTextBoxColumn"].Value = (decimal)row.Cells["countDataGridViewTextBoxColumn"].Value * (decimal)dg.CurrentCell.Value;
                        break;
                    case "count":
                        if (row.Cells["priceDataGridViewTextBoxColumn"].Value != System.DBNull.Value)
                            row.Cells["billDataGridViewTextBoxColumn"].Value = (decimal)row.Cells["priceDataGridViewTextBoxColumn"].Value * (decimal)dg.CurrentCell.Value;
                        break;
                    case "bill":
                        decimal count = 0;
                        if (row.Cells["countDataGridViewTextBoxColumn"].Value != System.DBNull.Value)
                        {
                            count = (decimal)row.Cells["countDataGridViewTextBoxColumn"].Value;
                        }
                       
                        var bill = (decimal)dg.CurrentCell.Value;
                            if (bill == 0)
                            {
                                row.Cells["priceDataGridViewTextBoxColumn"].Value = 0;
                            }
                            else
                            {
                                if (count == 0)
                                {
                                    row.Cells["countDataGridViewTextBoxColumn"].Value = 1;
                                    count = 1;
                                }
                                row.Cells["priceDataGridViewTextBoxColumn"].Value = bill / count;
                            }
                        break;
                }

            }
            cellChange = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //orderTableAdapter.Insert(time_order: time_order.Value,
            //                         end_order: end_order.Value,
            //                         bill: 0,
            //                         waiter_id: (int)waiter.SelectedValue,
            //                         abonent_id: (int)abonent.SelectedValue,
            //                         source_id: (int)item_source.SelectedValue);
            order.time_order = time_order.Value;
            order.end_order = end_order.Value;
            order.waiter_id = (int)waiter.SelectedValue;
            order.abonent_id = (int)abonent.SelectedValue;
            order.source_id = (int)item_source.SelectedValue;
            decimal summ = 0;
            foreach (var item in detailsBindingSource)
            {
                var d = item as DataRowView;
                summ += (decimal)d["bill"];
            }

            order.bill = summ;
            //restorantDataSet.order.AddorderRow(order);
            orderTableAdapter.Update(restorantDataSet.order);
            detailsTableAdapter.Update(restorantDataSet.details);                     
        
        }
    }
}
