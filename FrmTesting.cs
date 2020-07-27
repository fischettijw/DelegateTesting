using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTesting
{
    public partial class FrmTesting : Form
    {
        delegate void MyDelegateInt(int t);

        public FrmTesting() { InitializeComponent(); }

        private void MyFirstMethod(int w) { LbxOutput.Items.Add($"My First Method = {w * 2}"); }
        private void MySecondMethod(int w) { LbxOutput.Items.Add($"My Second Method = {w * 4}"); }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            MyDelegateInt delOne = MyFirstMethod;
            MyDelegateInt delTwo = MySecondMethod;

            int a = 5;
            delOne.Invoke(a); LbxOutput.Items.Add("");

            int b = 9;
            delTwo.Invoke(b); LbxOutput.Items.Add("");

            int x = 8;
            AnotherMethod(x, delOne); LbxOutput.Items.Add("");

            int y = 16;
            AnotherMethod(y, delTwo); LbxOutput.Items.Add("");
        }

        private void AnotherMethod(int x, Delegate y)
        {
            LbxOutput.Items.Add($"AnotherMethod = {x}");
            y.DynamicInvoke(x);
        }
    }






}
