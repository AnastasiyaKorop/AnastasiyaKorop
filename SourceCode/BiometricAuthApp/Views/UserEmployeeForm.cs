using BiometricAuthApp.Models;
using BiometricAuthApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BiometricAuthApp.Views
{
    public partial class UserEmployeeForm : Form
    {
        private List<Employee> employees;
        private List<Client> clients;
        private List<ClientEmployeeConnection> connections;
        private readonly ClientEmployeeService clientEmployeeService = new();
        private ViewMode viewMode = ViewMode.Employee;

        public UserEmployeeForm()
        {
            InitializeComponent();
            treeView1.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;

            try
            {
                LoadClients();
                LoadConnections();
                LoadEmployees();
                RebuildTree();
                FillClientBox();
                FillEmployeeBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            clients = clientEmployeeService.GetClients();
        }
        private void LoadEmployees()
        {
            employees = clientEmployeeService.GetEmployees();

        }

        public void LoadConnections()
        {
            connections = clientEmployeeService.GetClientsConnections();
        }

        private void RebuildTree()
        {
            if (viewMode == ViewMode.Employee)
            {
                BuildTreeForEmployee();
            }
            if (viewMode == ViewMode.Client)
            {
                BuildTreeForClient();
            }

        }

        public void FillClientBox()
        {
            clientCombo.DataSource = clients.Select(e => new
            {
                Display = $"{e.FirstName} {e.LastName}",
                Value = e.Id
            }).ToList();
            clientCombo.DisplayMember = "Display";
            clientCombo.ValueMember = "Value";
        }

        public void FillEmployeeBox()
        {
            employeeCombo.DataSource = employees.Select(e => new
            {
                Display = $"{e.FirstName} {e.LastName}",
                Value = e.Id
            }).ToList();
            employeeCombo.DisplayMember = "Display";
            employeeCombo.ValueMember = "Value";
        }

        private void BuildTreeForEmployee()
        {
            treeView1.Nodes.Clear();

            foreach (var employee in employees)
            {
                TreeNode employeeNode = new TreeNode($"{employee.FirstName} {employee.LastName} (Адрес: {employee.Address})") { Tag = employee };

                var connectionsForEmployee = connections.Where(a => a.EmployeeId == employee.Id).ToList();

                foreach (var connection in connectionsForEmployee)
                {
                    var client = clients.Where(c => c.Id == connection.UserId).First();
                    TreeNode clientNode = new TreeNode($"{client.FirstName} {client.LastName} (Телефон: {client.Phone})") { Tag = client };
                    employeeNode.Nodes.Add(clientNode);
                }

                treeView1.Nodes.Add(employeeNode);
            }
            treeView1.ExpandAll();
        }

        private void BuildTreeForClient()
        {
            treeView1.Nodes.Clear();
            foreach (var client in clients)
            {
                TreeNode clientNode = new TreeNode($"{client.FirstName} {client.LastName} (Телефон: {client.Phone})") { Tag = client };

                var connectionsForClient = connections.Where(a => a.UserId == client.Id).ToList();

                foreach (var connection in connectionsForClient)
                {
                    var employee = employees.Where(c => c.Id == connection.EmployeeId).First();
                    TreeNode employeeNode = new TreeNode($"{employee.FirstName} {employee.LastName} (Адрес: {employee.Address})") { Tag = employee };

                    clientNode.Nodes.Add(employeeNode);
                }

                treeView1.Nodes.Add(clientNode);
            }
            treeView1.ExpandAll();
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
                return;
            try
            {
                if (e.Node.Tag is Employee employee)
                {
                    var client = e.Node.Parent.Tag as Client;
                    clientEmployeeService.RemoveClientEmployee(connections.Find(a => a.UserId == client.Id && a.EmployeeId == employee.Id));
                }
                else if (e.Node.Tag is Client client)
                {

                    var employee1 = e.Node.Parent.Tag as Employee;
                    clientEmployeeService.RemoveClientEmployee(connections.Find(a => a.UserId == client.Id && a.EmployeeId == employee1.Id));
                }

                LoadConnections();
                RebuildTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка удаления связи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var clientID = clientCombo.SelectedValue as dynamic;
            var employeeId = employeeCombo.SelectedValue as dynamic;

            if (clientID == null)
            {
                MessageBox.Show("Клиент не выбран!", @"Ошибка выбора Клиента", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (employeeId == null)
            {
                MessageBox.Show("Работник не выбран!", @"Ошибка выбора Работника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                clientEmployeeService.AddClientEmployee(clients.First(a => a.Id == clientID), employees.First(a => a.Id == employeeId));
                LoadConnections();
                RebuildTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RebuildTree();
        }

        private void ChengeSortButton_Click(object sender, EventArgs e)
        {
            viewMode = viewMode == ViewMode.Employee ? ViewMode.Client : ViewMode.Employee;
            RebuildTree();
        }

        enum ViewMode
        {
            Employee,
            Client
        }
    }


}
