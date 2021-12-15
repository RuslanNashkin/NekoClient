
namespace RuslanNashkinNekoClientApp
{
    partial class CreateBrakForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.postavshikFilterComboBox = new System.Windows.Forms.ComboBox();
            this.zapchastiFilterComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(18, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 53);
            this.textBox1.TabIndex = 0;
            // 
            // postavshikFilterComboBox
            // 
            this.postavshikFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postavshikFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postavshikFilterComboBox.FormattingEnabled = true;
            this.postavshikFilterComboBox.Location = new System.Drawing.Point(20, 102);
            this.postavshikFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.postavshikFilterComboBox.Name = "postavshikFilterComboBox";
            this.postavshikFilterComboBox.Size = new System.Drawing.Size(392, 55);
            this.postavshikFilterComboBox.TabIndex = 1;
            // 
            // zapchastiFilterComboBox
            // 
            this.zapchastiFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zapchastiFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zapchastiFilterComboBox.FormattingEnabled = true;
            this.zapchastiFilterComboBox.Location = new System.Drawing.Point(20, 189);
            this.zapchastiFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zapchastiFilterComboBox.Name = "zapchastiFilterComboBox";
            this.zapchastiFilterComboBox.Size = new System.Drawing.Size(392, 55);
            this.zapchastiFilterComboBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 376);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 122);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateBrakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 512);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zapchastiFilterComboBox);
            this.Controls.Add(this.postavshikFilterComboBox);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateBrakForm";
            this.Text = "CreateBrakForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox postavshikFilterComboBox;
        private System.Windows.Forms.ComboBox zapchastiFilterComboBox;
        private System.Windows.Forms.Button button1;
    }
}