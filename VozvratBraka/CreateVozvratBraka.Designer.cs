
namespace RuslanNashkinNekoClientApp
{
    partial class CreateVozvratBraka
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
            this.button1 = new System.Windows.Forms.Button();
            this.zapchastiFilterComboBox = new System.Windows.Forms.ComboBox();
            this.brakFilterComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 79);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zapchastiFilterComboBox
            // 
            this.zapchastiFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zapchastiFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zapchastiFilterComboBox.FormattingEnabled = true;
            this.zapchastiFilterComboBox.Location = new System.Drawing.Point(12, 69);
            this.zapchastiFilterComboBox.Name = "zapchastiFilterComboBox";
            this.zapchastiFilterComboBox.Size = new System.Drawing.Size(263, 39);
            this.zapchastiFilterComboBox.TabIndex = 5;
            // 
            // brakFilterComboBox
            // 
            this.brakFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brakFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brakFilterComboBox.FormattingEnabled = true;
            this.brakFilterComboBox.Location = new System.Drawing.Point(12, 12);
            this.brakFilterComboBox.Name = "brakFilterComboBox";
            this.brakFilterComboBox.Size = new System.Drawing.Size(263, 39);
            this.brakFilterComboBox.TabIndex = 4;
            // 
            // CreateVozvratBraka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 284);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zapchastiFilterComboBox);
            this.Controls.Add(this.brakFilterComboBox);
            this.Name = "CreateVozvratBraka";
            this.Text = "CreateVozvratBraka";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox zapchastiFilterComboBox;
        private System.Windows.Forms.ComboBox brakFilterComboBox;
    }
}