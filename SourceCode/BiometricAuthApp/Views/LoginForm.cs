using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiometricAuthApp.Models;
using BiometricAuthApp.Services;

namespace BiometricAuthApp.Views
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly Action<LoginForm>? _onSuccess;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            _onSuccess = null;
        }

        public LoginForm(Action<LoginForm> onSuccess)
        {
            InitializeComponent();
            _authService = new AuthService();
            _onSuccess = onSuccess;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            scannerButton.Enabled = false;

            try
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                var user = await Task.Run(() => _authService.Authenticate(username, password));

                if (user != null)
                {
                    LogitSuccess(user);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Произошла ошибка. Попробуйте позже.", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Console.WriteLine($@"Ошибка: {ex.Message}");
            }
            finally
            {
                loginButton.Enabled = true;
                scannerButton.Enabled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //using (NewAdminFaceScannerForm form = new NewAdminFaceScannerForm())
            using (FaceLoginForm form = new FaceLoginForm())
            {
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Login Success");
                    var user = await Task.Run(() => _authService.FindUserByName(form.UserName));
                    LogitSuccess(user);
                }
                else
                {
                    Console.WriteLine("No login");
                }
            }
        }
        

        private void LogitSuccess(User user)
        {
            if(_onSuccess!= null)
            {

                _onSuccess.Invoke(this);
                return;
            }
            MessageBox.Show($@"Добро пожаловать, {user.Username}!", @"Авторизация успешна",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
