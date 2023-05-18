namespace lab10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            unicorn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)unicorn).BeginInit();
            SuspendLayout();
            // 
            // unicorn
            // 
            unicorn.Image = (Image)resources.GetObject("unicorn.Image");
            unicorn.Location = new Point(201, 451);
            unicorn.Name = "unicorn";
            unicorn.Size = new Size(66, 67);
            unicorn.TabIndex = 0;
            unicorn.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 543);
            Controls.Add(unicorn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)unicorn).EndInit();
            ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }

        #endregion

        private PictureBox unicorn;
    }
}