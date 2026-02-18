using System;
using System.ComponentModel;
using AdsInterface;
using System.Windows.Forms;

public enum E_TestStatus : Int16
{
    Init,
    Running,
    Passed,
    Failed,
    Aborted
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
    public T_STRING TestName { get; set; }
    public T_INT TestStatus { get; set; }
    public T_BOOL TestEnabled { get; set; }
    public BindingList<T_TestStatus> testStatusList = new BindingList<T_TestStatus>();
    public int Length;
	public string SymbolName;
    private DataGridView dataGridView;


	public T_TestRunner(TAds Ads, string SymbolName, DataGridView TestDataGridView)
	{
        dataGridView = TestDataGridView;

        this.SymbolName = SymbolName;
		this.Ads = Ads;
        RunTests = new T_BOOL(Ads, SymbolName + ".RunTests");
        Abort = new T_BOOL(Ads, SymbolName + ".Abort");
        EnableAllTests = new T_BOOL(Ads, SymbolName + ".EnableAllTests");
        DisableAllTests = new T_BOOL(Ads, SymbolName + ".DisableAllTests");
        TestCount = new T_UINT(Ads, SymbolName + ".TestCount");
        CurrentTestNumber = new T_INT(Ads, SymbolName + ".CurrentTestNumber");
        TestName = new T_STRING(Ads, SymbolName + ".Tests[0].Name", 256);
        TestStatus = new T_INT(Ads, SymbolName + ".Tests[0].TestStatus");
        TestEnabled = new T_BOOL(Ads, SymbolName + ".Tests[0].Enabled");

        //Ads.AddConnection(CurrentTestNumber);

        //CurrentTestNumber.PropertyChanged += CurrentTestNumber_PropertyChanged; 
    }

    public void Connect(string AmsNetId, int Port)
    {
        Ads.Disconnect();
        Ads.Connect(AmsNetId, Port);
        CurrentTestNumber.Connect();
        CurrentTestNumber.PropertyChanged += CurrentTestNumber_PropertyChanged; 
    }

    private void CurrentTestNumber_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        ReadTestStatusFromPlc(Ads);
    }

    public void ToggleTestEnabled(int TestNumber)
    {
        TestEnabled.SymbolName = $"PB_UnitTests.TestRunner.Tests[{TestNumber}].Enabled";
        TestEnabled.ReadFromPlc();
        TestEnabled.Value = !TestEnabled.Value;
        TestEnabled.WriteToPLC();
    }

    private void ClearDataGridView()
    {
        dataGridView.Invoke(new Action(() => testStatusList.Clear()));
    }

    private void AddToDataGridView(T_TestStatus ts)
    {
        dataGridView.Invoke(new Action(() => testStatusList.Add(ts)));
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

        if (Ads.Connected)
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

                        TestName.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].Name";
                        TestName.ReadFromPlc();
                        ts.Name = TestName.Value;

                        TestStatus.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].TestStatus";
                        TestStatus.ReadFromPlc();
                        ts.Status = (E_TestStatus)TestStatus.Value; // int is read so cast to enum type

                        TestEnabled.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].Enabled";
                        TestEnabled.ReadFromPlc();
                        ts.Enabled = TestEnabled.Value;

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

        if (Ads.Connected)
        {
            try
            {
                TestCount.ReadFromPlc();
                if ((TestCount.Value > 0) && (testStatusList.Count > 0))
                {
                    for (int i = 0; i < TestCount.Value; i++)
                    {

                        ts = testStatusList[i];

                        TestName.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].Name";
                        TestName.ReadFromPlc();
                        ts.Name = TestName.Value;

                        TestStatus.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].TestStatus";
                        TestStatus.ReadFromPlc();
                        ts.Status = (E_TestStatus)TestStatus.Value; // int is read so cast to enum type

                        TestEnabled.SymbolName = $"PB_UnitTests.TestRunner.Tests[{i}].Enabled";
                        TestEnabled.ReadFromPlc();
                        ts.Enabled = TestEnabled.Value;

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


