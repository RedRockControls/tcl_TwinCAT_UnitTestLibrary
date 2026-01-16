using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using AdsInterface;
using TwinCAT.Ads;
using System.Windows.Forms;

public enum E_TestStatus : Int16
{
    Init,
    Running,
    Passed,
    Failed
};

public class T_TestStatus : INotifyPropertyChanged
{
    private String name;
    private E_TestStatus status;
    private Boolean enabled;

    public String Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

        public E_TestStatus Status
    {
        get => status;
        set
        {
            if (status != value)
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }

    public Boolean Enabled
    {
        get => enabled;
        set
        {
            if (enabled != value)
            {
                enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}


public class T_TestRunner
{

    public TAds Ads;
    public T_BOOL RunTests { get; set; }
    public T_BOOL Abort { get; set; }
    public T_BOOL EnableAllTests { get; set; }
    public T_BOOL DisableAllTests { get; set; }
    public T_UINT TestCount { get; set; }
    public T_INT CurrentTestNumber { get; set; }
    public BindingList<T_TestStatus> testStatusList = new BindingList<T_TestStatus>();
    public int Length;
	public string SymbolName;

    private TcAdsClient adsClient;
    private AdsStream dataStream;
    private AdsBinaryReader adsBinaryReader;
    private DataGridView dataGridView;


	public T_TestRunner(TAds Ads, string SymbolName, DataGridView TestDataGridView)
	{
        adsClient = new TcAdsClient();
        dataStream = new AdsStream(4096);
        adsBinaryReader = new AdsBinaryReader(dataStream);
        adsClient.Connect(851);
        //adsClient.Connect("192.168.0.150.1.1", 851);
        adsClient.Timeout = 200;
        dataGridView = TestDataGridView;

        this.SymbolName = SymbolName;
		this.Ads = Ads;
        RunTests = new T_BOOL(Ads, SymbolName + ".RunTests");
        Abort = new T_BOOL(Ads, SymbolName + ".Abort");
        EnableAllTests = new T_BOOL(Ads, SymbolName + ".EnableAllTests");
        DisableAllTests = new T_BOOL(Ads, SymbolName + ".DisableAllTests");
        TestCount = new T_UINT(Ads, SymbolName + ".TestCount");
        CurrentTestNumber = new T_INT(Ads, SymbolName + ".CurrentTestNumber");

        Ads.AddConnection(Abort);
        Ads.AddConnection(CurrentTestNumber);

        CurrentTestNumber.PropertyChanged += CurrentTestNumber_PropertyChanged; 
    }

    private void CurrentTestNumber_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        ReadTestStatusFromPlc(Ads);
    }

    public void ToggleTestEnabled(int TestNumber)
    {
        T_BOOL TestEnabled = new T_BOOL(Ads, $"PB_UnitTests.TestRunner.Tests[{TestNumber}].Enabled");
        TestEnabled.ReadFromPlc();
        TestEnabled.Value = !TestEnabled.Value;
        TestEnabled.WriteToPLC();
    }

    public void Connect()
	{
        RunTests.Connect();
        Abort.Connect();
        TestCount.Connect();
        CurrentTestNumber.Connect(); // Monitor plc value to trigger refresh of dataGridView
    }

    private void ClearDataGridView()
    {
        dataGridView.Invoke(new Action(() => testStatusList.Clear()));
    }

    private void AddToDataGridView(T_TestStatus ts)
    {
        dataGridView.Invoke(new Action(() => testStatusList.Add(ts)));
    }

	public void Disconnect()
	{
        RunTests.Disconnect();
        Abort.Disconnect();
        TestCount.Disconnect();
        CurrentTestNumber.Disconnect();
    }

    public void ReadFromPlc()
	{
        RunTests.ReadFromPlc();
        Abort.ReadFromPlc();
        TestCount.ReadFromPlc();
    }


    public void InitialiseTestStatusFromPlc(TAds Ads)
    {
        T_TestStatus ts;

        if (adsClient.IsConnected)
        {
            try
            {
                ClearDataGridView();
                TestCount.ReadFromPlc();
                if (TestCount.Value > 0)
                {
                    for (int i = 0; i < TestCount.Value; i++)
                    {
                        ts = new T_TestStatus();
                        int handle;
                        int byteCount;

                        dataStream.Position = 0;
                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].Name");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Name = adsBinaryReader.ReadPlcAnsiString(256);

                        dataStream.Position = 0;
                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].TestStatus");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Status = (E_TestStatus)adsBinaryReader.ReadInt16();
                        dataStream.Position = 0;

                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].Enabled");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Enabled = adsBinaryReader.ReadBoolean();

                        AddToDataGridView(ts);
                    }
                }
            }
            catch (Exception ex)
            {
                Ads.LogMessage(ex.Message + "reading " + SymbolName);
            }
        }

    }

    public void ReadTestStatusFromPlc(TAds Ads)
    {
        T_TestStatus ts;

        if (adsClient.IsConnected)
        {
            try
            {
                TestCount.ReadFromPlc();
                if (TestCount.Value > 0)
                {
                    for (int i = 0; i < TestCount.Value; i++)
                    {

                        ts = testStatusList[i];
                        int handle;
                        int byteCount;

                        dataStream.Position = 0;
                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].Name");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Name = adsBinaryReader.ReadPlcAnsiString(256);

                        dataStream.Position = 0;
                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].TestStatus");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Status = (E_TestStatus)adsBinaryReader.ReadInt16();
                        dataStream.Position = 0;

                        handle = adsClient.CreateVariableHandle($"PB_UnitTests.TestRunner.Tests[{i}].Enabled");
                        byteCount = adsClient.Read(handle, dataStream);
                        adsClient.DeleteVariableHandle(handle);
                        ts.Enabled = adsBinaryReader.ReadBoolean();

                    }
                }
            }
            catch (Exception ex)
            {
                Ads.LogMessage(ex.Message + "reading " + SymbolName);
            }
        }

    }


}


