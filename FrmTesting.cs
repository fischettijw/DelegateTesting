using System;
using System.Windows.Forms;

namespace DelegateTesting
{
    public partial class FrmTesting : Form
    {
        delegate void MyDelegateInt(int t);
        ListBoxPrint P;
        public FrmTesting() { InitializeComponent(); }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            P = new ListBoxPrint(LbxOutput);
            MyDelegateInt delOne = this.MyFirstMethod;
            MyDelegateInt delTwo = this.MySecondMethod;

            int a = 5; delOne.Invoke(a);
            int b = 9; delTwo.Invoke(b);
            int x = 8; AnotherMethod(x, delOne);
            int y = 16; AnotherMethod(y, delTwo);
        }
        private void MyFirstMethod(int w) { P.Print($"My First Method = {w * 2}"); P.Print(); }
        private void MySecondMethod(int w) { P.Print($"My Second Method = {w * 4}"); P.Print(); }
        private void AnotherMethod(int x, MyDelegateInt y)
        {
            P.Print($"AnotherMethod = {x}");
            y.Invoke(x);          //  y.DynamicInvoke(x);
        }
    }
}
