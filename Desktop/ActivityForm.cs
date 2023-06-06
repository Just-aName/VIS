using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class ActivityForm : Form
    {

        private List<ActivityDataModel> ToModify = new List<ActivityDataModel>();
        private List<ActivityDataModel> ToDelete = new List<ActivityDataModel>();


        public ActivityForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            using (var DbContext = new VISEntities())
            {
                XmlManager.ReadActivityXml();
                var ids = XmlManager.ActivityIdList;
                var data = DbContext.Activity.Where(x => ids.Contains(x.Activity_id)).ToList();
                ;
                foreach (var item in data)
                {
                    activityDataModelBindingSource.Add(new ActivityDataModel(item));
                }
            }
            this.TopMost = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure wannt to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = this.dataGridView1.CurrentRow;
                    ToDelete.Add(new ActivityDataModel(row));
                    activityDataModelBindingSource.RemoveCurrent();
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Confirm")
            {
                if (MessageBox.Show("Are you sure wannt to Confirm this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = this.dataGridView1.CurrentRow;
                    ToModify.Add(new ActivityDataModel(row));
                    activityDataModelBindingSource.RemoveCurrent();
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (var DbContext = new VISEntities())
            {
                foreach (var item in this.ToModify)
                {
                    var activity = DbContext.Activity.Where(x => x.Activity_id == item.Activity_id).FirstOrDefault();
                    item.ModifyActivity(activity);
                    XmlManager.RemoveActivityId(activity.Activity_id);
                }

                foreach (var item in this.ToDelete)
                {
                    XmlManager.RemoveActivityId(item.Activity_id);
                }
                DbContext.SaveChanges();
                XmlManager.WriteActivityXml();
            }
        }
    }
}
