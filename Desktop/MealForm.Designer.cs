namespace Desktop
{
    partial class MealForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Confirm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mealidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kalorieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bilkovinyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tukyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cukryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlakninaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verejneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealDataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealDataModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(769, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mealidDataGridViewTextBoxColumn,
            this.nazevDataGridViewTextBoxColumn,
            this.kalorieDataGridViewTextBoxColumn,
            this.bilkovinyDataGridViewTextBoxColumn,
            this.tukyDataGridViewTextBoxColumn,
            this.cukryDataGridViewTextBoxColumn,
            this.vlakninaDataGridViewTextBoxColumn,
            this.verejneDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.Confirm,
            this.Delete});
            this.dataGridView1.DataSource = this.mealDataModelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(747, 448);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Confirm
            // 
            this.Confirm.HeaderText = "Confirm";
            this.Confirm.Name = "Confirm";
            this.Confirm.Text = "Confirm";
            this.Confirm.UseColumnTextForButtonValue = true;
            this.Confirm.Width = 60;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 60;
            // 
            // mealidDataGridViewTextBoxColumn
            // 
            this.mealidDataGridViewTextBoxColumn.DataPropertyName = "Meal_id";
            this.mealidDataGridViewTextBoxColumn.HeaderText = "Meal_id";
            this.mealidDataGridViewTextBoxColumn.Name = "mealidDataGridViewTextBoxColumn";
            this.mealidDataGridViewTextBoxColumn.Width = 60;
            // 
            // nazevDataGridViewTextBoxColumn
            // 
            this.nazevDataGridViewTextBoxColumn.DataPropertyName = "Nazev";
            this.nazevDataGridViewTextBoxColumn.HeaderText = "Nazev";
            this.nazevDataGridViewTextBoxColumn.Name = "nazevDataGridViewTextBoxColumn";
            // 
            // kalorieDataGridViewTextBoxColumn
            // 
            this.kalorieDataGridViewTextBoxColumn.DataPropertyName = "Kalorie";
            this.kalorieDataGridViewTextBoxColumn.HeaderText = "Kalorie";
            this.kalorieDataGridViewTextBoxColumn.Name = "kalorieDataGridViewTextBoxColumn";
            this.kalorieDataGridViewTextBoxColumn.Width = 60;
            // 
            // bilkovinyDataGridViewTextBoxColumn
            // 
            this.bilkovinyDataGridViewTextBoxColumn.DataPropertyName = "Bilkoviny";
            this.bilkovinyDataGridViewTextBoxColumn.HeaderText = "Bilkoviny";
            this.bilkovinyDataGridViewTextBoxColumn.Name = "bilkovinyDataGridViewTextBoxColumn";
            this.bilkovinyDataGridViewTextBoxColumn.Width = 60;
            // 
            // tukyDataGridViewTextBoxColumn
            // 
            this.tukyDataGridViewTextBoxColumn.DataPropertyName = "Tuky";
            this.tukyDataGridViewTextBoxColumn.HeaderText = "Tuky";
            this.tukyDataGridViewTextBoxColumn.Name = "tukyDataGridViewTextBoxColumn";
            this.tukyDataGridViewTextBoxColumn.Width = 60;
            // 
            // cukryDataGridViewTextBoxColumn
            // 
            this.cukryDataGridViewTextBoxColumn.DataPropertyName = "Cukry";
            this.cukryDataGridViewTextBoxColumn.HeaderText = "Cukry";
            this.cukryDataGridViewTextBoxColumn.Name = "cukryDataGridViewTextBoxColumn";
            this.cukryDataGridViewTextBoxColumn.Width = 60;
            // 
            // vlakninaDataGridViewTextBoxColumn
            // 
            this.vlakninaDataGridViewTextBoxColumn.DataPropertyName = "Vlaknina";
            this.vlakninaDataGridViewTextBoxColumn.HeaderText = "Vlaknina";
            this.vlakninaDataGridViewTextBoxColumn.Name = "vlakninaDataGridViewTextBoxColumn";
            this.vlakninaDataGridViewTextBoxColumn.Width = 60;
            // 
            // verejneDataGridViewTextBoxColumn
            // 
            this.verejneDataGridViewTextBoxColumn.DataPropertyName = "Verejne";
            this.verejneDataGridViewTextBoxColumn.HeaderText = "Verejne";
            this.verejneDataGridViewTextBoxColumn.Name = "verejneDataGridViewTextBoxColumn";
            this.verejneDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.verejneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.verejneDataGridViewTextBoxColumn.Width = 60;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "User_ID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "User_ID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // mealDataModelBindingSource
            // 
            this.mealDataModelBindingSource.DataSource = typeof(Desktop.MealDataModel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(769, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save Changes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "MealForm";
            this.Text = "MealForm";
            this.Load += new System.EventHandler(this.MealForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealDataModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource mealDataModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kalorieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bilkovinyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tukyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cukryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlakninaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn verejneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Confirm;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button button2;
    }
}