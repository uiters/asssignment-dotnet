using BookStoreLibrary;
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

namespace BookStore
{
    public partial class FrmLogin : Form
    {
        public static IBookService bookService;
        public static IEmployeeService employeeService;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee employee = GetEmployee();
            if (employee.IsNotCorrect())
            {
                ShowError("Id or password is empty");
            } else
            {
                try
                {
                    if (employeeService.Login(employee.Id, employee.Pass))
                    {
                        if (employeeService.GetRole(employee.Id))
                        {
                            NavigateToMaintainBook(employee.Id);
                        }
                        else
                        {
                            NavigateToChangeAccount(employee.Id);
                        }
                    }
                    else
                    {
                        ShowError("Login failed");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    ShowError("Login failed");
                }
            }
        }

        private void NavigateToChangeAccount(string id)
        {
            this.Hide();
            new FrmChangeAccount(id).Show();
        }

        private void NavigateToMaintainBook(string id)
        {
            this.Hide();
            new FrmMaintainBooks().Show();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        Employee GetEmployee()
        {
            string username = txbID.Text;
            string pass = txbPassword.Text;
            Employee employee = new Employee(username, pass, false);
            return employee;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            bookService = new BookService(provider);
            employeeService = new EmployeeService(provider);
        }
    }
}
