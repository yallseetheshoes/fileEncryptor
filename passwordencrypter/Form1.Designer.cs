namespace passwordencrypter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwords = new System.Windows.Forms.ListBox();
            this.directorylabel = new System.Windows.Forms.Label();
            this.encryptbtn = new System.Windows.Forms.Button();
            this.writebutton = new System.Windows.Forms.Button();
            this.decryptbtn = new System.Windows.Forms.Button();
            this.filecontent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filePassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.createPassFile = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.safemodebutton = new System.Windows.Forms.Button();
            this.changedirbutton = new System.Windows.Forms.Button();
            this.filteringButton = new System.Windows.Forms.Button();
            this.viewDirBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwords
            // 
            this.passwords.FormattingEnabled = true;
            this.passwords.Location = new System.Drawing.Point(12, 12);
            this.passwords.Name = "passwords";
            this.passwords.Size = new System.Drawing.Size(156, 420);
            this.passwords.TabIndex = 0;
            this.passwords.SelectedIndexChanged += new System.EventHandler(this.passwords_SelectedIndexChanged);
            // 
            // directorylabel
            // 
            this.directorylabel.AutoSize = true;
            this.directorylabel.Location = new System.Drawing.Point(174, 12);
            this.directorylabel.Name = "directorylabel";
            this.directorylabel.Size = new System.Drawing.Size(243, 13);
            this.directorylabel.TabIndex = 1;
            this.directorylabel.Text = "C:\\Users\\magnu\\AppData\\Local\\MaggiEncryptor";
            // 
            // encryptbtn
            // 
            this.encryptbtn.Location = new System.Drawing.Point(339, 409);
            this.encryptbtn.Name = "encryptbtn";
            this.encryptbtn.Size = new System.Drawing.Size(75, 23);
            this.encryptbtn.TabIndex = 2;
            this.encryptbtn.Text = "Encrypt";
            this.encryptbtn.UseVisualStyleBackColor = true;
            this.encryptbtn.Click += new System.EventHandler(this.encryptbtn_Click);
            // 
            // writebutton
            // 
            this.writebutton.Location = new System.Drawing.Point(203, 409);
            this.writebutton.Name = "writebutton";
            this.writebutton.Size = new System.Drawing.Size(49, 23);
            this.writebutton.TabIndex = 3;
            this.writebutton.Text = "Save";
            this.writebutton.UseVisualStyleBackColor = true;
            this.writebutton.Click += new System.EventHandler(this.writebutton_Click);
            // 
            // decryptbtn
            // 
            this.decryptbtn.Location = new System.Drawing.Point(258, 409);
            this.decryptbtn.Name = "decryptbtn";
            this.decryptbtn.Size = new System.Drawing.Size(75, 23);
            this.decryptbtn.TabIndex = 4;
            this.decryptbtn.Text = "Decrypt";
            this.decryptbtn.UseVisualStyleBackColor = true;
            this.decryptbtn.Click += new System.EventHandler(this.decryptbtn_Click);
            // 
            // filecontent
            // 
            this.filecontent.Location = new System.Drawing.Point(177, 139);
            this.filecontent.Multiline = true;
            this.filecontent.Name = "filecontent";
            this.filecontent.Size = new System.Drawing.Size(349, 195);
            this.filecontent.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password - Not saved";
            // 
            // filePassword
            // 
            this.filePassword.Location = new System.Drawing.Point(177, 353);
            this.filePassword.Multiline = true;
            this.filePassword.Name = "filePassword";
            this.filePassword.Size = new System.Drawing.Size(349, 50);
            this.filePassword.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Contents";
            // 
            // createPassFile
            // 
            this.createPassFile.Location = new System.Drawing.Point(177, 410);
            this.createPassFile.Name = "createPassFile";
            this.createPassFile.Size = new System.Drawing.Size(20, 20);
            this.createPassFile.TabIndex = 9;
            this.createPassFile.Text = "+";
            this.createPassFile.UseVisualStyleBackColor = true;
            this.createPassFile.Click += new System.EventHandler(this.createPassFile_Click);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(177, 100);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(349, 20);
            this.fileName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "File name";
            // 
            // safemodebutton
            // 
            this.safemodebutton.Location = new System.Drawing.Point(420, 410);
            this.safemodebutton.Name = "safemodebutton";
            this.safemodebutton.Size = new System.Drawing.Size(106, 23);
            this.safemodebutton.TabIndex = 12;
            this.safemodebutton.Text = "Safe mode : True";
            this.safemodebutton.UseVisualStyleBackColor = true;
            this.safemodebutton.Click += new System.EventHandler(this.safemodebutton_Click);
            // 
            // changedirbutton
            // 
            this.changedirbutton.Location = new System.Drawing.Point(174, 28);
            this.changedirbutton.Name = "changedirbutton";
            this.changedirbutton.Size = new System.Drawing.Size(98, 23);
            this.changedirbutton.TabIndex = 13;
            this.changedirbutton.Text = "Change";
            this.changedirbutton.UseVisualStyleBackColor = true;
            this.changedirbutton.Click += new System.EventHandler(this.changedirbutton_click);
            // 
            // filteringButton
            // 
            this.filteringButton.Location = new System.Drawing.Point(174, 57);
            this.filteringButton.Name = "filteringButton";
            this.filteringButton.Size = new System.Drawing.Size(98, 23);
            this.filteringButton.TabIndex = 14;
            this.filteringButton.Text = "Filtering True";
            this.filteringButton.UseVisualStyleBackColor = true;
            this.filteringButton.Click += new System.EventHandler(this.filteringButton_Click);
            // 
            // viewDirBtn
            // 
            this.viewDirBtn.Location = new System.Drawing.Point(278, 28);
            this.viewDirBtn.Name = "viewDirBtn";
            this.viewDirBtn.Size = new System.Drawing.Size(98, 23);
            this.viewDirBtn.TabIndex = 15;
            this.viewDirBtn.Text = "View";
            this.viewDirBtn.UseVisualStyleBackColor = true;
            this.viewDirBtn.Click += new System.EventHandler(this.viewDirBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 446);
            this.Controls.Add(this.viewDirBtn);
            this.Controls.Add(this.filteringButton);
            this.Controls.Add(this.changedirbutton);
            this.Controls.Add(this.safemodebutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.createPassFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filePassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filecontent);
            this.Controls.Add(this.decryptbtn);
            this.Controls.Add(this.writebutton);
            this.Controls.Add(this.encryptbtn);
            this.Controls.Add(this.directorylabel);
            this.Controls.Add(this.passwords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Maggi\'s password encryptor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox passwords;
        private System.Windows.Forms.Label directorylabel;
        private System.Windows.Forms.Button encryptbtn;
        private System.Windows.Forms.Button writebutton;
        private System.Windows.Forms.Button decryptbtn;
        private System.Windows.Forms.TextBox filecontent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createPassFile;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button safemodebutton;
        private System.Windows.Forms.Button changedirbutton;
        private System.Windows.Forms.Button filteringButton;
        private System.Windows.Forms.Button viewDirBtn;
    }
}

