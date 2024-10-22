namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            BtnTestCommand = new Button();
            form1ViewModelBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1ViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(363, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 30F);
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(396, 52);
            label1.TabIndex = 2;
            label1.Text = "DPI Unaware Demo";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 335);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // BtnTestCommand
            // 
            BtnTestCommand.DataBindings.Add(new Binding("Command", form1ViewModelBindingSource, "MySetCommandCommand", true));
            BtnTestCommand.Location = new Point(478, 415);
            BtnTestCommand.Name = "BtnTestCommand";
            BtnTestCommand.Size = new Size(87, 23);
            BtnTestCommand.TabIndex = 4;
            BtnTestCommand.Text = "Command";
            BtnTestCommand.UseVisualStyleBackColor = true;
            // 
            // form1ViewModelBindingSource
            // 
            form1ViewModelBindingSource.DataSource = typeof(ViewModels.Form1ViewModel);
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", form1ViewModelBindingSource, "Name", true));
            textBox1.Location = new Point(363, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(239, 23);
            textBox1.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(363, 150);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(BtnTestCommand);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1ViewModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button BtnTestCommand;
        private BindingSource form1ViewModelBindingSource;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
    }
}
