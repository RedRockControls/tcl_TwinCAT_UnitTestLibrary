/*
 * Created by SharpDevelop.
 * User: Roger Christopher
 * Date: 09/12/2010
 * Time: 17:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GapControllerHmi
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnRetest = new System.Windows.Forms.Button();
            this.dataGrid_TestList = new System.Windows.Forms.DataGridView();
            this.btnLoadTests = new System.Windows.Forms.Button();
            this.btnEnableAllTests = new System.Windows.Forms.Button();
            this.btnDisableAllTests = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblAmsNetId = new System.Windows.Forms.Label();
            this.txtAmsNetId = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPortNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_TestList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetest
            // 
            this.btnRetest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetest.Location = new System.Drawing.Point(1316, 859);
            this.btnRetest.Margin = new System.Windows.Forms.Padding(6);
            this.btnRetest.Name = "btnRetest";
            this.btnRetest.Size = new System.Drawing.Size(198, 81);
            this.btnRetest.TabIndex = 9;
            this.btnRetest.Text = "Retest";
            this.btnRetest.UseVisualStyleBackColor = true;
            this.btnRetest.Click += new System.EventHandler(this.btnRetest_Click);
            // 
            // dataGrid_TestList
            // 
            this.dataGrid_TestList.AllowUserToAddRows = false;
            this.dataGrid_TestList.AllowUserToDeleteRows = false;
            this.dataGrid_TestList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid_TestList.Location = new System.Drawing.Point(37, 48);
            this.dataGrid_TestList.Margin = new System.Windows.Forms.Padding(6);
            this.dataGrid_TestList.Name = "dataGrid_TestList";
            this.dataGrid_TestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid_TestList.Size = new System.Drawing.Size(1687, 803);
            this.dataGrid_TestList.TabIndex = 11;
            this.dataGrid_TestList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_TestList_CellClick);
            // 
            // btnLoadTests
            // 
            this.btnLoadTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadTests.Location = new System.Drawing.Point(213, 859);
            this.btnLoadTests.Margin = new System.Windows.Forms.Padding(6);
            this.btnLoadTests.Name = "btnLoadTests";
            this.btnLoadTests.Size = new System.Drawing.Size(164, 77);
            this.btnLoadTests.TabIndex = 13;
            this.btnLoadTests.Text = "Load Tests";
            this.btnLoadTests.UseVisualStyleBackColor = true;
            this.btnLoadTests.Click += new System.EventHandler(this.btnLoadTests_Click);
            // 
            // btnEnableAllTests
            // 
            this.btnEnableAllTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnableAllTests.Location = new System.Drawing.Point(389, 859);
            this.btnEnableAllTests.Margin = new System.Windows.Forms.Padding(6);
            this.btnEnableAllTests.Name = "btnEnableAllTests";
            this.btnEnableAllTests.Size = new System.Drawing.Size(164, 77);
            this.btnEnableAllTests.TabIndex = 14;
            this.btnEnableAllTests.Text = "Enable All";
            this.btnEnableAllTests.UseVisualStyleBackColor = true;
            this.btnEnableAllTests.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEnableAllTests_MouseDown);
            this.btnEnableAllTests.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEnableAllTests_MouseUp);
            // 
            // btnDisableAllTests
            // 
            this.btnDisableAllTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDisableAllTests.Location = new System.Drawing.Point(565, 861);
            this.btnDisableAllTests.Margin = new System.Windows.Forms.Padding(6);
            this.btnDisableAllTests.Name = "btnDisableAllTests";
            this.btnDisableAllTests.Size = new System.Drawing.Size(164, 77);
            this.btnDisableAllTests.TabIndex = 15;
            this.btnDisableAllTests.Text = "Disable All";
            this.btnDisableAllTests.UseVisualStyleBackColor = true;
            this.btnDisableAllTests.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDisableAllTests_MouseDown);
            this.btnDisableAllTests.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDisableAllTests_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1526, 859);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(198, 81);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Location = new System.Drawing.Point(1106, 859);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(6);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(198, 81);
            this.btnAbort.TabIndex = 17;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAbort_MouseDown);
            this.btnAbort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAbort_MouseUp);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnect.Location = new System.Drawing.Point(37, 861);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(164, 77);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // lblAmsNetId
            // 
            this.lblAmsNetId.AutoSize = true;
            this.lblAmsNetId.Location = new System.Drawing.Point(37, 12);
            this.lblAmsNetId.Name = "lblAmsNetId";
            this.lblAmsNetId.Size = new System.Drawing.Size(104, 25);
            this.lblAmsNetId.TabIndex = 19;
            this.lblAmsNetId.Text = "AmsNetId";
            // 
            // txtAmsNetId
            // 
            this.txtAmsNetId.Location = new System.Drawing.Point(151, 6);
            this.txtAmsNetId.Name = "txtAmsNetId";
            this.txtAmsNetId.Size = new System.Drawing.Size(313, 31);
            this.txtAmsNetId.TabIndex = 20;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(560, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(62, 31);
            this.txtPort.TabIndex = 22;
            this.txtPort.Text = "851";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.AutoSize = true;
            this.lblPortNumber.Location = new System.Drawing.Point(500, 12);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(51, 25);
            this.lblPortNumber.TabIndex = 21;
            this.lblPortNumber.Text = "Port";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1754, 955);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPortNumber);
            this.Controls.Add(this.txtAmsNetId);
            this.Controls.Add(this.lblAmsNetId);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDisableAllTests);
            this.Controls.Add(this.btnEnableAllTests);
            this.Controls.Add(this.btnLoadTests);
            this.Controls.Add(this.dataGrid_TestList);
            this.Controls.Add(this.btnRetest);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Test Runner V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_TestList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnRetest;
        private System.Windows.Forms.DataGridView dataGrid_TestList;
        private System.Windows.Forms.Button btnLoadTests;
        private System.Windows.Forms.Button btnEnableAllTests;
        private System.Windows.Forms.Button btnDisableAllTests;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblAmsNetId;
        private System.Windows.Forms.TextBox txtAmsNetId;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPortNumber;
    }
}
