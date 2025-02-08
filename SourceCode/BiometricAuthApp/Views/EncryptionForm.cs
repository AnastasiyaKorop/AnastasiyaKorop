using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BiometricAuthApp.Views
{
    public partial class EncryptionForm : Form
    {
        private readonly FileSecurityService _encryptionService;

        public EncryptionForm()
        {
            InitializeComponent();
            _encryptionService = new FileSecurityService();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var keys = _encryptionService.GenerateKeys();

            txtB.Text = keys.B;
            txtX.Text = keys.X;
            txtY.Text = keys.Y;

            MessageBox.Show(@"Ключи успешно сгенерированы!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveKeysButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"JSON files (*.json)|*.json",
                Title = @"Сохранить ключи"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var keys = new
                {
                    B = txtB.Text,
                    X = txtX.Text,
                    Y = txtY.Text
                };

                File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(keys));
                MessageBox.Show(@"Ключи успешно сохранены!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadKeysButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"JSON files (*.json)|*.json",
                Title = @"Загрузить ключи"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog.FileName);
                    var keys = JsonSerializer.Deserialize<JsonElement>(json);

                    txtB.Text = keys.GetProperty("B").GetString();
                    txtX.Text = keys.GetProperty("X").GetString();
                    txtY.Text = keys.GetProperty("Y").GetString();

                    _encryptionService.LoadKey(txtB.Text, txtX.Text, txtY.Text);

                    MessageBox.Show(@"Ключи успешно загружены!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Ошибка загрузки!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(exception);
                }
            }
        }

        private void SignFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"All files (*.*)|*.*",
                Title = @"Выбрать файл для подписи"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var fileData = File.ReadAllBytes(filePath);

                var signature = _encryptionService.SignData(fileData);
                File.WriteAllBytes(filePath + ".sig", signature);

                MessageBox.Show(@"Файл успешно подписан!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VerifyFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"All files (*.*)|*.*",
                Title = @"Выбрать файл для проверки"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var fileData = File.ReadAllBytes(filePath);

                var signaturePath = filePath + ".sig";
                try
                {
                    if (File.Exists(signaturePath))
                    {
                        var signature = File.ReadAllBytes(signaturePath);

                        if (_encryptionService.VerifyData(fileData, signature))
                        {
                            MessageBox.Show(@"Подпись подтверждена!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(@"Подпись не подтверждена!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Файл подписи не найден!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show(@"Файл подписи заблокирован!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //расшифровываем
        private async void DecodeButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"All files (*.enc*)|*.enc*",
                Title = @"Выбрать файл для расшифровки"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var verifyFaceForm = new LoginForm((f) =>
                {
                    f.DialogResult = DialogResult.OK;
                    f.Close();
                });
                if (verifyFaceForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show(@"Не удалось идентифицировать пользователя", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var filePath = openFileDialog.FileName;
                    await _encryptionService.DencryptFile(filePath, filePath.Remove(filePath.Length - 4));

                    MessageBox.Show(@"Файл успешно Расшифрован!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(@$"{ex.Message}!", @"Неудача", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //Шифруем
        private async void EncodeButton_Click_1(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"All files (*.*)|*.*",
                Title = @"Выбрать файл для шифрования"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;
                    await _encryptionService.EncryptFile(filePath, filePath + ".enc");

                    MessageBox.Show(@"Файл успешно Зашифрован!", @"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(@$"{ex.Message}!", @"Неудача", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
