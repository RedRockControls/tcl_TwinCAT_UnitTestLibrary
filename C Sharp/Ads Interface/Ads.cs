using System;
using System.Collections.Generic;
using TwinCAT.Ads;

namespace AdsInterface
{

	public class TAds : IDisposable
	{
		private TcAdsClient adsClient;
		private AdsStream adsStream;
		private AdsBinaryReader adsReader;
		Dictionary<int, string> ConnectionList;

		public bool Connected = true;

		public TAds(int Port) // Connects to local target
		{
			adsClient = new TcAdsClient();
			adsStream = new AdsStream(1024);
			adsReader = new AdsBinaryReader(adsStream);
			adsClient.Connect("", Port);
			adsClient.Timeout = 200;
			ConnectionList = new Dictionary<int, string>();
			adsClient.AdsNotification += new AdsNotificationEventHandler(adsClient_AdsNotification);
		}

		public TAds(string AmsNetId, int Port) // Connects to target specified by static property
		{
			adsClient = new TcAdsClient();
			adsStream = new AdsStream(1024);
			adsReader = new AdsBinaryReader(adsStream);
			adsClient.Connect(AmsNetId, Port);
			adsClient.Timeout = 200;
			ConnectionList = new Dictionary<int, string>();
			adsClient.AdsNotification += new AdsNotificationEventHandler(adsClient_AdsNotification);
		}

		public void ChangeServer(string NewAmsNetId, int NewPort) 
		{
			if (NewAmsNetId != adsClient.Address.NetId.ToString()) // different to current connection
			{
				DisconnectFromPlc();//clear current connections
				adsClient.Connect(NewAmsNetId, NewPort);//make new connection
			}
		}

		public void Dispose()
		{

			try
			{
				DisconnectFromPlc();
			}
			finally
			{
				adsClient.Dispose();
			}
		}

		public void AddConnection(TPLC_Type PLC_Value)
		{
			try
			{
				PLC_Value.ConnectionHandle = adsClient.AddDeviceNotification(PLC_Value.SymbolName, adsStream, AdsTransMode.OnChange, 220, 0, PLC_Value);
				ConnectionList.Add(PLC_Value.ConnectionHandle, PLC_Value.SymbolName);
			}
			catch (Exception ex)
			{
				LogMessage(ex.Message + " adding connection to " + PLC_Value.SymbolName);
			}
		}

		public void DeleteConnection(TPLC_Type PLC_Value)
		{
			try
			{
				adsClient.DeleteDeviceNotification(PLC_Value.ConnectionHandle);
				ConnectionList.Remove(PLC_Value.ConnectionHandle);
			}
			catch (Exception ex)
			{
				LogMessage(ex.Message + " deleting connection to " + PLC_Value.SymbolName);
			}
		}

		public void DisconnectFromPlc()
		{
			foreach (int entry in ConnectionList.Keys)
			{
				try
				{
					adsClient.DeleteDeviceNotification(entry);
				}
				catch (Exception ex)
				{
					LogMessage(ex.Message + " disconnecting from " + ConnectionList[entry]);
				}
			}
			ConnectionList.Clear();
		}

		private void adsClient_AdsNotification(object sender, AdsNotificationEventArgs e)
		{

			TPLC_Type plcValue = e.UserData as TPLC_Type;
			if (plcValue is T_BOOL)
			{
				(plcValue as T_BOOL).SetValue(adsReader.ReadBoolean());
			}
			if (plcValue is T_BYTE)
			{
				(plcValue as T_BYTE).SetValue(adsReader.ReadByte());
			}

			if (plcValue is T_INT)
			{
				(plcValue as T_INT).SetValue(adsReader.ReadInt16());
			}

			if (plcValue is T_UINT)
			{
				(plcValue as T_UINT).SetValue(adsReader.ReadUInt16());
			}

			if (plcValue is T_DINT)
			{
				(plcValue as T_DINT).SetValue(adsReader.ReadInt32());
			}
			if (plcValue is T_UDINT)
			{
				(plcValue as T_UDINT).SetValue(adsReader.ReadUInt32());
			}

			if (plcValue is T_DT)
			{
				(plcValue as T_DT).SetValue(adsReader.ReadPlcDATE());
			}

			if (plcValue is T_LREAL)
			{
				(plcValue as T_LREAL).SetValue(adsReader.ReadDouble());
			}

			if (plcValue is T_STRING)
			{
				(plcValue as T_STRING).SetValue(adsReader.ReadPlcAnsiString(81));
			}

			if (plcValue is T_MAXSTRING)
			{
				(plcValue as T_MAXSTRING).SetValue(adsReader.ReadPlcAnsiString(256));
			}

			plcValue.RaisePropertyChanged("Value");
		}


		public int Read(string SymbolName, AdsStream dataStream)
		{
			int cb = 0;
			if (Connected)
			{
				try
				{
					int handle = adsClient.CreateVariableHandle(SymbolName);
					cb = adsClient.Read(handle, dataStream);
					adsClient.DeleteVariableHandle(handle);
				}
				catch (Exception ex)
				{
					LogMessage(ex.Message + "reading " + SymbolName);
					Connected = false;
				}
			}
			else
			{
				cb = 0;
			}
			return cb;
		}

		public void Write(string SymbolName, AdsStream Stream)
		{
			if (Connected || true)
			{
				try
				{
					int handle = adsClient.CreateVariableHandle(SymbolName);
					adsClient.Write(handle, Stream);
					adsClient.DeleteVariableHandle(handle);

				}
				catch (Exception ex)
				{
					LogMessage(ex.Message + "Writing to " + SymbolName);
					Connected = false;
				}
			}
		}


		public void LogMessage(string Message)
		{
			string LogFilename = "C:\\TwinCAT\\Boot\\Hmi\\ErrorLog_" + DateTime.Now.DayOfWeek.ToString() + ".txt";
			string dir = System.IO.Path.GetDirectoryName(LogFilename);
			if (!System.IO.Directory.Exists(dir))
			{
				System.IO.Directory.CreateDirectory(dir);
			}
			System.IO.StreamWriter Writer = new System.IO.StreamWriter(LogFilename, true);
			Writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + " : " + Message);
			Writer.Close();
		}
	}

}


