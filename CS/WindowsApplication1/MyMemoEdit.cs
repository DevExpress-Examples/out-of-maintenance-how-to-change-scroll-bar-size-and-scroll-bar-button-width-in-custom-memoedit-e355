using System;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace WindowsApplication1
{
    public class MyMemoEdit : MemoEdit
    {
        static MyMemoEdit() { RepositoryItemMyMemoEdit.RegisterMyMemoEdit(); }

        public MyMemoEdit()
            : base()
        {
            scrollHelper = new MyScrollBarAPIHelper();
            scrollHelper.Init(MaskBox, this);
            scrollHelper.ScrollMouseLeave += new EventHandler(OnScroll_MouseLeave);
            scrollHelper.LookAndFeel = LookAndFeel;

            Properties.Assigned += new EventHandler(OnPropertiesAssigned);
        }
        
        public bool HScrollVisible
        {
            get
            {
                return ((Properties.ScrollBars == System.Windows.Forms.ScrollBars.Both)
                        || (Properties.ScrollBars == System.Windows.Forms.ScrollBars.Horizontal)
                        )
                    && (!Properties.WordWrap);
            }
        }

        public bool VScrollVisible
        {
            get
            {
                return (Properties.ScrollBars == System.Windows.Forms.ScrollBars.Both)
                    || (Properties.ScrollBars == System.Windows.Forms.ScrollBars.Vertical);
            }
        }
        
        protected new MyScrollBarAPIHelper ScrollHelper { get { return scrollHelper as MyScrollBarAPIHelper; } }

        public virtual void UpdateScrollBars()
        {
            if (ScrollHelper != null)
            {
                ScrollHelper.SetScrollBarsWidth(Properties.ScrollWidth);
                ScrollHelper.SetScrollBarsButtonWidth(Properties.ScrollButtonWidth);
                Refresh();
            }
        }

        void OnScroll_MouseLeave(object sender, EventArgs e)
        {
            CheckMouseHere();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemMyMemoEdit.MyMemoEditName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyMemoEdit Properties
        {
            get { return base.Properties as RepositoryItemMyMemoEdit; }
        }

        protected virtual void OnPropertiesAssigned(object sender, EventArgs e)
        {
            UpdateScrollBars();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Properties.Assigned -= new EventHandler(OnPropertiesAssigned);
            }
            base.Dispose(disposing);
        }

    }
}
