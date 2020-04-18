using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainProduct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HttpClient client = new HttpClient();
        string baseUri = "https://localhost:5001/api/products";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage resp = client.GetAsync(baseUri).Result;
                //kiem tra co loi hay khong ?
                resp.EnsureSuccessStatusCode();
                List<Product> proList = resp.Content.ReadAsAsync<List<Product>>().Result;
                //hien thi len GridView
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = proList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                int ProID = int.Parse(txtProductID.Text);
                string ProName = txtProductName.Text;
                float Price = float.Parse(txtUnitPrice.Text);
                int Quantity = int.Parse(txtQuantity.Text);
                //Tao doi tuong Product
                Product p = new Product
                {
                    ProductID = ProID,
                    ProductName = ProName,
                    UnitPrice = Price,
                    Quantity = Quantity
                };
                HttpResponseMessage resp = client.PostAsJsonAsync(baseUri, p).Result;
                resp.EnsureSuccessStatusCode();
                MessageBox.Show("Product is saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int ProID = int.Parse(txtProductID.Text);
                HttpResponseMessage resp = client.DeleteAsync(baseUri + ProID).Result;
                resp.EnsureSuccessStatusCode();
                MessageBox.Show("Delete successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int ProID = int.Parse(txtProductID.Text);
                HttpResponseMessage resp = client.GetAsync(baseUri + ProID).Result;
                //kiem tra truy cap thanh cong
                resp.EnsureSuccessStatusCode();
                Product p = resp.Content.ReadAsAsync<Product>().Result;
                if (p == null)
                {
                    MessageBox.Show("Product not found .");
                }
                else
                {
                    txtProductName.Text = p.ProductName;
                    txtQuantity.Text = p.Quantity.ToString();
                    txtUnitPrice.Text = p.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            dgvProducts.DataSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
