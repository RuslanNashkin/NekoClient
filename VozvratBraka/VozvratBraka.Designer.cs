
namespace RuslanNashkinNekoClientApp
{
    partial class VozvratBraka
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.insertButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.brakFilterComboBox = new System.Windows.Forms.ComboBox();
            this.zapchastiFilterComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.insertButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(140)))), ((int)(((byte)(32)))));
            this.insertButton.FlatAppearance.BorderSize = 4;
            this.insertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertButton.ForeColor = System.Drawing.Color.White;
            this.insertButton.Location = new System.Drawing.Point(1122, 14);
            this.insertButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(292, 162);
            this.insertButton.TabIndex = 22;
            this.insertButton.Text = "Добавить запись";
            this.insertButton.UseVisualStyleBackColor = false;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(1060, 751);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.brakFilterComboBox);
            this.panel1.Controls.Add(this.zapchastiFilterComboBox);
            this.panel1.Location = new System.Drawing.Point(1108, 286);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 562);
            this.panel1.TabIndex = 24;
            this.panel1.Visible = false;
            // 
            // brakFilterComboBox
            // 
            this.brakFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brakFilterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brakFilterComboBox.FormattingEnabled = true;
            this.brakFilterComboBox.Location = new System.Drawing.Point(24, 129);
            this.brakFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brakFilterComboBox.Name = "brakFilterComboBox";
            this.brakFilterComboBox.Size = new System.Drawing.Size(265, 28);
            this.brakFilterComboBox.TabIndex = 2;
            this.brakFilterComboBox.Tag = "ID_Brak";
            // 
            // zapchastiFilterComboBox
            // 
            this.zapchastiFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zapchastiFilterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zapchastiFilterComboBox.FormattingEnabled = true;
            this.zapchastiFilterComboBox.Location = new System.Drawing.Point(24, 29);
            this.zapchastiFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zapchastiFilterComboBox.Name = "zapchastiFilterComboBox";
            this.zapchastiFilterComboBox.Size = new System.Drawing.Size(265, 28);
            this.zapchastiFilterComboBox.TabIndex = 1;
            this.zapchastiFilterComboBox.Tag = "ID_Zapchasti";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1149, 238);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(184, 24);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Показать фильтры";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // VozvratBraka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 865);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VozvratBraka";
            this.Text = "VozvratBraka";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox brakFilterComboBox;
        private System.Windows.Forms.ComboBox zapchastiFilterComboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}