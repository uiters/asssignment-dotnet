using BookStoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class FrmChangeAccount : Form
    {
        private string id;
        private readonly IEmployeeService employeeService = FrmLogin.employeeService;
        public FrmChangeAccount(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmChangeAccount_Load(object sender, EventArgs e)
        {
            Employee employee = employeeService.GetEmployee(id);
            lbID.Text = employee.Id;
            lbRole.Text = employee.Role.ToString();
            txbPassword.Text = employee.Pass;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee(id, txbPassword.Text, Convert.ToBoolean(lbRole.Text));
                if (employee.IsNotCorrect())
                {
                    ShowError("Password is empty, try again!");
                } else
                {
                    if (employeeService.ChangePassword(id, employee.Pass))
                    {
                        MessageBox.Show("Change Success", "What happend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        ShowError("Change password failed");
                    }
                }

            }catch
            {
                ShowError("Change password failed");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
