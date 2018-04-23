using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsApplication1
{
    public partial class Form1 : XtraForm
    {
        DataTable DT;
        
        public Form1()
        {
            InitializeComponent();

            DT = new DataTable();
            DT.Columns.Add("Text", typeof(string));
            DT.Rows.Add("Text");
            DT.Rows.Add("Text");

            gridControl1.DataSource = DT;

            myMemoEdit1.DataBindings.Add("EditValue",DT, "Text", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            myMemoEdit1.Properties.ScrollWidth = trackBarControl1.Value;
            repositoryItemMyMemoEdit1.ScrollWidth = trackBarControl1.Value;
        }

        private void trackBarControl2_EditValueChanged(object sender, EventArgs e)
        {
            myMemoEdit1.Properties.ScrollButtonWidth = trackBarControl2.Value;
            repositoryItemMyMemoEdit1.ScrollButtonWidth = trackBarControl2.Value;
        }

        private void myMemoEdit1_EditValueChanged_1(object sender, EventArgs e)
        {
            BindingManagerBase Manager = BindingContext[DT];
            Manager.EndCurrentEdit();
        }
    }
}
