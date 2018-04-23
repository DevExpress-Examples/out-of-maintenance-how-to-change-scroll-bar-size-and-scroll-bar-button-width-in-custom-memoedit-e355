using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

namespace WindowsApplication1
{
    public class MyMemoEditScrollBarViewInfo : ScrollBarViewInfo
    {
        int fWidth;

        public MyMemoEditScrollBarViewInfo(IScrollBar SB)
            : base(SB)
        {
            if (ScrollBarType == ScrollBarType.Horizontal)
                fWidth = SystemInformation.HorizontalScrollBarArrowWidth;
            else
                fWidth = SystemInformation.VerticalScrollBarArrowHeight;
        }

        public override int ButtonWidth
        {
            get
            {
                if (fWidth > ScrollBarWidth * 2)
                    return 0;
                if (fWidth > ScrollBarWidth / 2)
                    fWidth = ScrollBarWidth / 2;
                return fWidth;
            }
        }
        public void SetButtonWidth(int Width)
        {
            if (Width >= 0)
            {
                fWidth = Width;
                CalculateCore();
            }
        }
    }

}
