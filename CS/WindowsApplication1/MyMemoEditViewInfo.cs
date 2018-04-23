using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace WindowsApplication1
{
    public class MyMemoEditViewInfo : MemoEditViewInfo
    {
        MyMemoEditViewInfo(RepositoryItem item) : base(item) { }

        public new RepositoryItemMyMemoEdit Item { get { return base.Item as RepositoryItemMyMemoEdit; } }
        public new MyMemoEdit OwnerControl { get { return base.OwnerControl as MyMemoEdit; } }

        protected override void CalcContentRect(Rectangle bounds)
        {
            base.CalcContentRect(bounds);
            if (OwnerControl != null)
            {
                if (OwnerControl.VScrollVisible)
                    fContentRect.Width = ContentRect.Width - Item.ScrollWidth + SystemInformation.VerticalScrollBarWidth + 1;
                if (OwnerControl.HScrollVisible)
                    fContentRect.Height = ContentRect.Height - Item.ScrollWidth + SystemInformation.VerticalScrollBarWidth + 1;
                fMaskBoxRect = ContentRect;
            }
        }
    }

}
