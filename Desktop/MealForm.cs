using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class MealForm : Form
    {
        private List<MealDataModel> ToModify = new List<MealDataModel>();
        private List<MealDataModel> ToDelete = new List<MealDataModel>();

        public MealForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure wannt to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = this.dataGridView1.CurrentRow;
                    ToDelete.Add(new MealDataModel(row));
                    mealDataModelBindingSource.RemoveCurrent();
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Confirm")
            {
                if (MessageBox.Show("Are you sure wannt to Confirm this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = this.dataGridView1.CurrentRow;
                    ToModify.Add(new MealDataModel(row));
                    mealDataModelBindingSource.RemoveCurrent();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MealForm_Load(object sender, EventArgs e)
        {
            using (var DbContext = new VISEntities())
            {
                XmlManager.ReadMealXml();
                var ids = XmlManager.MealIdList;
                var data = DbContext.Meal.Where(x => ids.Contains(x.Meal_id)).ToList();
                foreach(var item in data)
                {
                    mealDataModelBindingSource.Add(new MealDataModel(item));
                }
            }

            this.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var DbContext = new VISEntities())
            {
                foreach (var item in this.ToModify)
                {
                    var meal = DbContext.Meal.Where(x => x.Meal_id == item.Meal_id).FirstOrDefault();
                    item.ModifyMeal(meal);
                    XmlManager.RemoveMealId(meal.Meal_id);
                }

                foreach (var item in this.ToDelete)
                {
                    XmlManager.RemoveMealId(item.Meal_id);
                }
                DbContext.SaveChanges();
                XmlManager.WriteMealXml();
            }

            MessageBox.Show("Changes has been saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
               
    }
}
