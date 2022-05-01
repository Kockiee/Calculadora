using System.Windows.Forms;
using System.Drawing;
using System;

class EspecialTextBox : TextBox
{
    [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect, 
        int nBottomRect,
                        
        int nheightRect,
        int nweightRect
    );
    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15));
    }
}

