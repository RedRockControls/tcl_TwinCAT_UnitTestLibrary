/*
 * Created by SharpDevelop.
 * User: Roger Christopher
 * Date: 09/12/2010
 * Time: 17:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using AdsInterface;

namespace GapControllerHmi
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        private TAds Ads;
        private T_TestRunner TestRunner;

        public MainForm()
        {
            InitializeComponent();
            Ads = new TAds(851);
            //Ads = new TAds("192.168.0.150.1.1", 851);
            TestRunner = new T_TestRunner(Ads, "PB_UnitTests.TestRunner", dataGrid_TestList);

            dataGrid_TestList.DataSource = TestRunner.testStatusList;
            dataGrid_TestList.Columns[0].ReadOnly = true;
            dataGrid_TestList.Columns[1].ReadOnly = true;

            dataGrid_TestList.Columns[0].Width = 600;
            dataGrid_TestList.Columns[1].Width = 75;
            dataGrid_TestList.Columns[2].Width = 75;

        }

        // Operator Event handling...
        private void btnRetest_Click(object sender, EventArgs e)
        {
            TestRunner.RunTests.Value = true;
            TestRunner.RunTests.WriteToPLC();
        }

        //private void EnterDoubleValue(T_LREAL PlcValue, string CurrentValue)
        //{
        //    Keypad.TfrmTextPad kp = new Keypad.TfrmTextPad();

        //    kp.EnteredText = CurrentValue;
        //    if (kp.ShowDialog(this) == DialogResult.OK)
        //    {
        //        double result;
        //        if (double.TryParse(kp.EnteredText, out result))
        //            PlcValue.Value = result;
        //    }
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Ads.Dispose();
            this.Close();
        }

        private void btnLoadTests_Click(object sender, EventArgs e)
        {
            TestRunner.InitialiseTestStatusFromPlc(Ads);
        }

        private void dataGrid_TestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TestRunner.ToggleTestEnabled(e.RowIndex);
            }
        }

        private void btnEnableAllTests_MouseDown(object sender, MouseEventArgs e)
        {
            TestRunner.EnableAllTests.Value = true;
            TestRunner.EnableAllTests.WriteToPLC();
        }

        private void btnEnableAllTests_MouseUp(object sender, MouseEventArgs e)
        {
            TestRunner.InitialiseTestStatusFromPlc(Ads);
        }

        private void btnDisableAllTests_MouseDown(object sender, MouseEventArgs e)
        {
            TestRunner.DisableAllTests.Value = true;
            TestRunner.DisableAllTests.WriteToPLC();
        }

        private void btnDisableAllTests_MouseUp(object sender, MouseEventArgs e)
        {
            TestRunner.InitialiseTestStatusFromPlc(Ads);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            TestRunner.Abort.Value = true;
            TestRunner.Abort.WriteToPLC();
        }
    }
}

