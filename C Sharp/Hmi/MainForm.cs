using System;
using System.Windows.Forms;
using AdsInterface;

namespace GapControllerHmi
{
    public partial class MainForm : Form
    {
        private TAds Ads;
        private T_TestRunner TestRunner;

        public MainForm()
        {
            InitializeComponent();
            Ads = new TAds();
            TestRunner = new T_TestRunner(Ads, "PB_UnitTests.TestRunner", dataGrid_TestList);
            TestRunner.Connect(txtAmsNetId.Text, Convert.ToInt32(txtPort.Text));

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

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            TestRunner.Connect(txtAmsNetId.Text,Convert.ToInt32(txtPort.Text));
        }

        private void btnAbort_MouseDown(object sender, MouseEventArgs e)
        {
            TestRunner.Abort.Value = true;
            TestRunner.Abort.WriteToPLC();
        }

        private void btnAbort_MouseUp(object sender, MouseEventArgs e)
        {
            TestRunner.Abort.Value = false;
            TestRunner.Abort.WriteToPLC();
        }
    }
}

