using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ScrollHelpers;

namespace WindowsApplication1
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCROLLBARINFO
    {
        public const uint
            STATE_SYSTEM_INVISIBLE = 0x00008000,
            STATE_SYSTEM_OFFSCREEN = 0x00010000,
            STATE_SYSTEM_UNAVAILABLE = 0x00000001,
            OBJID_VSCROLL = 0xFFFFFFFB,
            OBJID_HSCROLL = 0xFFFFFFFA;
        const int CCHILDREN_SCROLLBAR = 5;
        public Int32 cbSize;
        public GDIRect rcScrollBar;
        public Int32 dxyLineButton;
        public Int32 xyThumbTop;
        public Int32 xyThumbBottom;
        public Int32 reserved;
        public Int32 rgstate0, rgstate1, rgstate2, rgstate3, rgstate4, rgstate5;
        public void Init()
        {
            this.rcScrollBar = new GDIRect();
            this.cbSize = Marshal.SizeOf(this);
            this.dxyLineButton = this.xyThumbTop = this.xyThumbBottom = this.reserved = 0;
            this.rgstate0 = this.rgstate1 = this.rgstate2 = this.rgstate3 = this.rgstate4 = this.rgstate5 = 0;
        }
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern bool GetScrollBarInfo(IntPtr hwnd, uint idObject, ref SCROLLBARINFO psbi);
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCROLLINFO
    {
        public const int
            SIF_RANGE = 0x0001,
            SIF_PAGE = 0x0002,
            SIF_POS = 0x0004,
            SIF_DISABLENOSCROLL = 0x0008,
            SIF_TRACKPOS = 0x0010,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);
        public const int SB_HORZ = 0, SB_VERT = 1;
        public Int32 cbSize, fMask, nMin, nMax, nPage, nPos, nTrackPos;
        public void Init()
        {
            this.cbSize = Marshal.SizeOf(this);
            this.nMin = this.nMax = this.nPage = this.nPos = this.nTrackPos = 0;
            this.fMask = SIF_ALL;
        }
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern int SetScrollInfo(IntPtr handle, int fnBar, ref SCROLLINFO scrollInfo, bool redraw);
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern bool GetScrollInfo(IntPtr handle, int fnBar, ref SCROLLINFO scrollInfo);
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct GDIRect
    {
        public int left, top, right, bottom;
        public GDIRect(int l, int t, int r, int b)
        {
            left = l; top = t; right = r; bottom = b;
        }
        public GDIRect(Rectangle r)
        {
            left = r.Left; top = r.Top; right = r.Right; bottom = r.Bottom;
        }
        public Rectangle ToRectangle()
        {
            return new Rectangle(left, top, right - left, bottom - top);
        }
    }

    public class MyScrollBarAPIHelper : ScrollBarEditorsAPIHelper
    {
        private int fWidth;

        public MyScrollBarAPIHelper()
        {
            Type SHelperType = typeof(DevExpress.XtraEditors.ScrollHelpers.ScrollBarAPIHelper);

            FieldInfo fHScroll = SHelperType.GetField("hscroll", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo fVScroll = SHelperType.GetField("vscroll", BindingFlags.Instance | BindingFlags.NonPublic);

            ScrollBarBase hscroll;
            ScrollBarBase vscroll;

            hscroll = new MyMemoEditHScrollBar();
            vscroll = new MyMemoEditVScrollBar();
            hscroll.Scroll += new ScrollEventHandler(OnHScroll_Scroll);
            vscroll.Scroll += new ScrollEventHandler(OnVScroll_Scroll);
            hscroll.MouseLeave += new EventHandler(OnScroll_Leave);
            vscroll.MouseLeave += new EventHandler(OnScroll_Leave);

            vscroll.Visible = true;
            hscroll.Visible = true;

            fHScroll.SetValue(this, hscroll);
            fVScroll.SetValue(this, vscroll);

            fWidth = 17;
        }

        public override void Init(Control control, Control parent)
        {
            base.Init(control, parent);
        }

        public void SetScrollBarsWidth(int Width)
        {
            if (Width >= 0)
            {
                fWidth = Width;
                UpdateScrollBars();
            }
        }

        public void SetScrollBarsButtonWidth(int Width)
        {
            if (Width >= 0)
            {
                (VScroll as MyMemoEditVScrollBar).ViewInfo.SetButtonWidth(Width);
                (HScroll as MyMemoEditHScrollBar).ViewInfo.SetButtonWidth(Width);
            }
        }

        protected override void UpdateDXScrollBar(bool isHorz)
        {
            if (IsLockUpdate) return;
            ScrollBarBase dxScroll = isHorz ? (ScrollBarBase)HScroll : (ScrollBarBase)VScroll;
            if (SourceControl == null) return;
            if (!SourceControl.IsHandleCreated || !dxScroll.Parent.IsHandleCreated)
            {
                dxScroll.Visible = false;
                return;
            }
            BeginUpdate();
            try
            {
                SCROLLBARINFO sbInfo = new SCROLLBARINFO();
                sbInfo.Init();
                SCROLLBARINFO.GetScrollBarInfo(SourceControl.Handle, isHorz ? SCROLLBARINFO.OBJID_HSCROLL : SCROLLBARINFO.OBJID_VSCROLL, ref sbInfo);
                Rectangle scrollBounds = sbInfo.rcScrollBar.ToRectangle();
                if ((SourceControl != null && !SourceControl.Visible) || scrollBounds.IsEmpty || sbInfo.rgstate0 == SCROLLBARINFO.STATE_SYSTEM_INVISIBLE || sbInfo.rgstate0 == SCROLLBARINFO.STATE_SYSTEM_OFFSCREEN)
                {
                    dxScroll.Visible = false;
                    return;
                }
                scrollBounds = dxScroll.Parent.RectangleToClient(scrollBounds);

                if (isHorz)
                {
                    
                    scrollBounds.Height = fWidth;
                }
                else
                {
                    scrollBounds.Width = fWidth;
                }
                dxScroll.Bounds = scrollBounds;
                ScrollArgs currentArgs = new ScrollArgs(dxScroll), args = new ScrollArgs();
                if (sbInfo.rgstate0 == SCROLLBARINFO.STATE_SYSTEM_UNAVAILABLE)
                {
                    args.Maximum = args.Minimum = 0;
                    args.Value = 0;
                    args.Enabled = false;
                }
                else
                {
                    SCROLLINFO sInfo = new SCROLLINFO();
                    sInfo.Init();
                    SCROLLINFO.GetScrollInfo(SourceControl.Handle, isHorz ? SCROLLINFO.SB_HORZ : SCROLLINFO.SB_VERT, ref sInfo);
                    args.Enabled = true;
                    args.Maximum = sInfo.nMax;
                    args.Minimum = sInfo.nMin;
                    args.LargeChange = sInfo.nPage;
                    args.SmallChange = isHorz ? 8 : 1;
                    args.Value = sInfo.nTrackPos;
                }
                dxScroll.Visible = true;
                if (currentArgs.IsEquals(args)) return;
                args.AssignTo(dxScroll);
            }
            finally
            {
                EndUpdate();
            }
        }
    }   
}
