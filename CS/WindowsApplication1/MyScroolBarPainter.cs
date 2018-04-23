using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Skins;

namespace WindowsApplication1
{
    public class MyScrollBarPainter : SkinScrollBarPainter
    {
        public MyScrollBarPainter(ISkinProvider Skin) : base(Skin) { }

        public override int ThumbMinWidth
        {
            get
            {
                return 8;
            }
        }
    }
}
