using ProductLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductDemo
{
    public partial class ProductDemo : Form
    {
        public static IProductDB productDB;
        DataGridViewRow row;

        public ProductDemo()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Product product = TryGetProduct();
            if (product != null)
            {
                try
                {
                    if (productDB.AddNewProduct(product))
                    {
                        MessageBox.Show("Add Success", "What happend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataView.Rows.Clear();
                        LoadProduct();
                    } else
                    {
                        MessageBox.Show("Add Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show("Add Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Product TryGetProduct()
        {
            try
            {
                int id = Convert.ToInt32(txbId.Text);
                string name = Convert.ToString(txbName.Text);
                decimal quantity = Convert.ToDecimal(txbQuantity.Text);
                int price = Convert.ToInt32(txbPrice.Text);
                return new Product(id, name, 0, price)
                {
                    Quantity = quantity
                };


            }
            catch (Exception ex)
            {
                MessageBox.Show("Data input is wrong", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Product product = TryGetProduct();
            try
            {
                if (productDB.RemoveProduct(product))
                {
                    MessageBox.Show("Delete Success", "What happend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataView.Rows.Clear();
                    LoadProduct();
                }
                else
                {
                    MessageBox.Show("Delete Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Delete Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ProductDemo_Load(object sender, EventArgs e)
        {
            const string connectSting = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Product;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            DataProvider provider = new DataProvider(connectSting);
            productDB = new ProductDB(provider);
            LoadProduct();
        }

        private void LoadProduct()
        {
            List<Product> products = productDB.GetProductList();
            products.ForEach(addRowToView);
        }

        private void addRowToView(Product product)
        {
            DataGridViewRow row = (DataGridViewRow)dataView.RowTemplate.Clone();
            row.CreateCells(dataView, product.ProductID, product.ProductName, product.Quantity, product.UnitPrice);
            dataView.Rows.Add(row);
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                row = dataView.SelectedRows[0];
                if (row != null) SetData(row);
            }
        }

        private void SetData(DataGridViewRow row)
        {
            txbId.Text = Convert.ToString(row.Cells[0].Value);
            txbName.Text = Convert.ToString(row.Cells[1].Value);
            txbQuantity.Text = Convert.ToString(row.Cells[2].Value);
            txbPrice.Text = Convert.ToString(row.Cells[0].Value);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Product product = TryGetProduct();
            if (product != null)
            {
                try
                {
                    if (productDB.UpdateProduct(product))
                    {
                        MessageBox.Show("Update Success", "What happend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataView.Rows.Clear();
                        LoadProduct();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Update Failed", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }
    }
}
