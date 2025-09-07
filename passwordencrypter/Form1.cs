using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace passwordencrypter
{
    public partial class Form1 : Form
    {
        public string passwordsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MaggiEncryptor"
        );
        public string selectedFile;
        public System.Windows.Forms.ToolTip cryptographytip = new System.Windows.Forms.ToolTip();
        public bool filteringEnabled = true;
        public bool safeMode = true;
        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            Directory.CreateDirectory(passwordsPath);
            string[] files = Directory.GetFiles(passwordsPath);
            foreach (string file in files)
            {
                passwords.Items.Add(Path.GetFileName(file));
            }
            if (passwords.Items.Count >= 1)
            {
                passwords.SelectedIndex = 0;
                selectedFile = passwords.Items[passwords.SelectedIndex].ToString();
            }
        }
        private void refreshList()
        {
            string[] files = Directory.GetFiles(passwordsPath);
            passwords.Items.Clear();
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                if (!name.EndsWith(".crypt") && filteringEnabled)
                {
                    continue;
                }
                passwords.Items.Add(name);
            }
            if (passwords.Items.Count >= 1)
            {
                passwords.SelectedIndex = 0;
                selectedFile = passwords.Items[passwords.SelectedIndex].ToString();
            }
        }

        private void showFile(string filepath)
        {
            if (filepath == null)
            {
                fileName.Text = null;
                filecontent.Text = null;
                fileName.Enabled = false;
                filecontent.Enabled = false;
                filePassword.Enabled = false;
            }
            else 
            {
                if (File.Exists(filepath))
                {
                    selectedFile = filepath;
                    string content = File.ReadAllText(filepath);
                    filecontent.Text = content;
                    fileName.Text = Path.GetFileNameWithoutExtension(filepath);
                    fileName.Enabled = true;
                    filecontent.Enabled = true;
                    filePassword.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No file found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private byte[] cryptographyfunc(string pass, string data, bool decrypt)
        {
            using (Aes aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(pass, Encoding.UTF8.GetBytes("randomsaltstuff255252336246414234"));
                aes.Key = key.GetBytes(32);
                aes.IV = key.GetBytes(16);

                if (!decrypt) // ENCRYPT
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(data);
                            }
                        }
                        return ms.ToArray();
                    }
                }
                else // DECRYPT
                {
                    byte[] cipherBytes = Convert.FromBase64String(data);
                    using (MemoryStream ms = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                string plain = sr.ReadToEnd();
                                return Encoding.UTF8.GetBytes(plain); // return as byte[] like encrypt
                            }
                        }
                    }
                }
            }
        }
        private void encryptbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePassword.Text) && !string.IsNullOrEmpty(filecontent.Text))
            {
                string password = filePassword.Text;
                string content = filecontent.Text;
                byte[] encryptedData = cryptographyfunc(filePassword.Text, "MEncrypt" + content, false);
                filecontent.Text = Convert.ToBase64String(encryptedData);
                System.Windows.Forms.ToolTip tooltip1 = new System.Windows.Forms.ToolTip();
                tooltip1.IsBalloon = true;
                tooltip1.Show("Press this to save", writebutton, 0, -40, 3000);

            }
            else
            {
                MessageBox.Show("No password found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void decryptbtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(filePassword.Text))
            {
                string password = filePassword.Text;
                byte[] decryptedData = cryptographyfunc(filePassword.Text, filecontent.Text, true);
                string encodedString = Encoding.UTF8.GetString(decryptedData);
                if (!encodedString.StartsWith("MEncrypt") && safeMode) // if safe mode is enabled it can detect if the file is actually decrypted
                {
                    MessageBox.Show("Wrong password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                encodedString = encodedString.Substring("MEncrypt".Length);
                filecontent.Text = encodedString;
                cryptographytip.IsBalloon = true;
                cryptographytip.Show("Press this to save", writebutton, 0, -40, 3000);

            }
            else
            {
                MessageBox.Show("No password found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void writebutton_Click(object sender, EventArgs e)
        {
            string newName = fileName.Text + ".crypt";
            string newContent = filecontent.Text;
            string newPath = Path.Combine(passwordsPath, newName);
            if (selectedFile != null && File.Exists(newPath))
            {

                passwords.SelectedIndexChanged -= passwords_SelectedIndexChanged; // unsubscribe so it doesnt cause issues
                passwords.Items[passwords.SelectedIndex] = newName;
                passwords.SelectedIndexChanged += passwords_SelectedIndexChanged; // resubscribe
                File.WriteAllText(selectedFile, newContent);
                File.Move(selectedFile, newPath);
                showFile(newPath); // show the file
            }
        }// save to file

        private void passwords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(passwords.SelectedIndex >= 0)
            {
                string filepath = Path.Combine(passwordsPath, passwords.SelectedItem.ToString());
                showFile(filepath);
            }
        }// list index change

        private void createPassFile_Click(object sender, EventArgs e)
        {



            if (passwords.SelectedIndex >= 0) //check if something is already selected
            {
                passwords.SelectedIndex = -1;
                showFile(null); // clear the labels
                MessageBox.Show("You can now name the new file.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileName.Enabled = true;
            }
            else //if not, attempt to make a new file
            {
                string filename; // make sure the file name is valid
                if (fileName.Text == null || fileName.Text == "")
                {
                    filename = "default";
                }
                else
                {
                    filename = fileName.Text.Trim().Replace(".", "");
                }

                string newfile = Path.Combine(passwordsPath, filename + ".crypt"); // create path

                if (File.Exists(newfile)) // check if it already exists
                {
                    MessageBox.Show("File already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.WriteAllText(newfile, "");
                    passwords.Items.Add(Path.GetFileName(newfile));
                    showFile(newfile); // show the file
                }
            }
        }

        private void changedirbutton_click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog newdirdialog = new FolderBrowserDialog())
            {
                DialogResult = newdirdialog.ShowDialog(this);

                if (DialogResult == DialogResult.OK)
                {
                    string folderPath = newdirdialog.SelectedPath;
                    if (Directory.Exists(folderPath)) 
                    {
                        passwordsPath = folderPath;
                        directorylabel.Text = folderPath;
                        refreshList();
                    }
                }
            }
        }

        private void filteringButton_Click(object sender, EventArgs e)
        {
            filteringEnabled = !filteringEnabled;
            filteringButton.Text = "Filtering : "+filteringEnabled;
            refreshList();
        }






        private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void safemodebutton_Click(object sender, EventArgs e)
        {
            safeMode = !safeMode;
            safemodebutton.Text = "Safe mode : " + safeMode;
        }
    }
}
