using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Accessibility;

namespace WindowsApplication1
{
    [UserRepositoryItem("RegisterMyMemoEdit")]
    public class RepositoryItemMyMemoEdit : RepositoryItemMemoEdit
    {
        public virtual event EventHandler Assigned;
        
        static RepositoryItemMyMemoEdit() { RegisterMyMemoEdit(); }

        public RepositoryItemMyMemoEdit()
        {
            fScrollWidth = 17;
            fScrollButtonWidth = 17;
        }

        public const string MyMemoEditName = "MyMemoEdit";
        public override string EditorTypeName { get { return MyMemoEditName; } }

        public static void RegisterMyMemoEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                MyMemoEditName,                     //Specifies the editor's name.
                typeof(MyMemoEdit),                 //Specifies the type of the editor class.
                typeof(RepositoryItemMyMemoEdit),   //Specifies the type of the custom repository item class.
                typeof(MyMemoEditViewInfo),         //Specifies the type of the editor's ViewInfo class.
                new MemoEditPainter(),              //An instance of the editor's Painter class.
                true,                               //Specifies whether the custom editor will be visible at design time within container controls
                null,                               //Specifies the image that will be displayed along
                typeof(TextEditAccessible)
                ));
        }
        
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemMyMemoEdit source = item as RepositoryItemMyMemoEdit;
                if (source == null) return;
                fScrollWidth = source.fScrollWidth;
                fScrollButtonWidth = source.fScrollButtonWidth;
                Assigned(this, new EventArgs());
            }
            finally
            {
                EndUpdate();
            }
        }

        private int fScrollWidth;
        private int fScrollButtonWidth;

       [DefaultValue(17)]
        public int ScrollWidth
        {
            get { return fScrollWidth; }
            set
            {
                if (fScrollWidth != value)
                {
                    fScrollWidth = value;
                    OnPropertiesChanged();
                    if (OwnerEdit != null)
                        (OwnerEdit as MyMemoEdit).UpdateScrollBars();
                }
            }
        }

        [DefaultValue(17)]
        public int ScrollButtonWidth
        {
            get { return fScrollButtonWidth; }
            set
            {
                if (fScrollButtonWidth != value)
                {
                    fScrollButtonWidth = value;
                    OnPropertiesChanged();
                    if (OwnerEdit != null)
                        (OwnerEdit as MyMemoEdit).UpdateScrollBars();
                }
            }
        }
    }

}
