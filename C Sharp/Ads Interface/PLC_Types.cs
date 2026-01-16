using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using TwinCAT.Ads;
using System.ComponentModel;

namespace AdsInterface
{

    public abstract class TPLC_Type : TObservableObject
    {
        protected TAds Ads;
        public string SymbolName;
        public int Length;
		public int ConnectionHandle;
		protected AdsStream stream = null;
		protected AdsBinaryReader reader = null;
		protected AdsBinaryWriter writer = null;

		public void Connect()
		{
			Ads.AddConnection(this);
		}
		public void Disconnect()
		{
			Ads.DeleteConnection(this);
		}
	}



    // Boolean Type 
    //=====================================================================================

	public class T_BOOL : TPLC_Type
	{
		private Boolean currentValue;

		public T_BOOL(TAds Ads, string SymbolName)
		{

			this.Ads = Ads;
			this.SymbolName = SymbolName;
			this.Length = 1;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);

		}

		public void SetValue(bool newValue) // set current value without triggering a write to the plc
		{
			currentValue = newValue;
		}

		public bool Value
		{
			get
			{
				return currentValue;
			}
			set
			{
				this.currentValue = value;
				WriteToPLC();
			}
		}

		public void ReadFromPlc()
		{
			int cb = 0;
			stream.Position = 0;
			cb = Ads.Read(SymbolName, stream);

			if ((cb == Length))
			{
				currentValue = reader.ReadBoolean();
			}
			else
			{
				currentValue = false;
			}
		}

		public void WriteToPLC()
		{
			stream.Position = 0;
			writer.Write(currentValue);
			Ads.Write(SymbolName, stream);
		}
	}



    // Byte Type 
    //=====================================================================================
    public class T_BYTE : TPLC_Type
    {

        private Byte currentValue;

        public T_BYTE(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 1;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
        }


        public T_BYTE()
        {
            this.Length = 1;
        }

        public void SetValue(Byte newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public byte Value
        {
            get
            {
                return currentValue;
            }

            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

		public void ReadFromPlc()
		{
			int cb = 0;
			stream.Position = 0;
			cb = Ads.Read(SymbolName, stream);

			if ((cb == Length))
			{
				currentValue = reader.ReadByte();
			}
			else
			{
				currentValue = 0;
			}
		}

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // INT Type 
    //=====================================================================================
    public class T_INT : TPLC_Type
    {
        private Int16 currentValue;

        public T_INT(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 2;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_INT()
            : base()
        {
            this.Length = 2;
        }

        public void SetValue(Int16 newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public Int16 Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadInt16();
            }
            else
            {
                currentValue = 0;
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // UINT Type 
    //=====================================================================================
    public class T_UINT : TPLC_Type
    {
        private UInt16 currentValue;

        public T_UINT(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 2;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_UINT()
            : base()
        {
            this.Length = 2;
        }

        public void SetValue(UInt16 newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public UInt16 Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadUInt16();
            }
            else
            {
                currentValue = 0;
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // DINT Type 
    //=====================================================================================
    public class T_DINT : TPLC_Type
    {
        private Int32 currentValue;

        public T_DINT(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 4;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_DINT()
            : base()
        {
            this.Length = 4;
        }

        public void SetValue(Int32 newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public Int32 Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadInt32();
            }
            else
            {
                currentValue = 0;
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // UDINT Type 
    //=====================================================================================
    public class T_UDINT : TPLC_Type
    {
        private UInt32 currentValue;

        public T_UDINT(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 4;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_UDINT()
            : base()
        {
            this.Length = 4;
        }

        public void SetValue(UInt32 newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public UInt32 Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }


        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadUInt32();
            }
            else
            {
                currentValue = 0;
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
            writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // DT Type 
    //=====================================================================================
    public class T_DT : TPLC_Type
    {
        private DateTime currentValue;

        public T_DT(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 4;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_DT()
            : base()
        {
            this.Length = 4;
        }

        public void SetValue(DateTime newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public DateTime Value
        {
            get
            {
                if (currentValue == null)
                {
                    return default(DateTime);
                }
                else
                {
                    return currentValue;
                }
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadPlcDATE();
            }
            else
            {
                currentValue = default(DateTime);
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.WritePlcType(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }




    // LREAL Type 
    //=====================================================================================
    public class T_LREAL : TPLC_Type
    {

        private Double currentValue;


        public T_LREAL(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 8;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public void SetValue(double newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public double Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadDouble();
            }
            else
            {
                currentValue = 0;
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.Write(currentValue);
            Ads.Write(SymbolName, stream);
        }

    }



    // STRING Type 
    //=====================================================================================
    public class T_STRING : TPLC_Type
    {
        private String currentValue;

        public T_STRING(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 81;//TODO - read this length from export file

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_STRING()
            : base()
        {
            this.Length = 81;
        }

        public void SetValue(string newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public string Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }

        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadPlcAnsiString(81);
            }
            else
            {
                currentValue = "";
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.WritePlcAnsiString(currentValue, currentValue.Length + 1);
            Ads.Write(SymbolName, stream);
        }

    }



    // MAX_STRING Type 
    //=====================================================================================
    public class T_MAXSTRING : TPLC_Type
    {
        private String currentValue;

        public T_MAXSTRING(TAds Ads, string SymbolName)
        {
            this.Ads = Ads;
            this.SymbolName = SymbolName;
            this.Length = 256;

			stream = new AdsStream(Length);
			reader = new AdsBinaryReader(stream);
			writer = new AdsBinaryWriter(stream);
		}

        public T_MAXSTRING()
            : base()
        {
            this.Length = 256;
        }

        public void SetValue(string newValue) // set current value without triggering a write to the plc
        {
            currentValue = newValue;
        }

        public string Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                WriteToPLC();
            }
        }


        public void ReadFromPlc()
        {
            int cb = 0;
			stream.Position = 0;
            cb = Ads.Read(SymbolName, stream);

            if ((cb == Length))
            {
                currentValue = reader.ReadPlcAnsiString(Length);
            }
            else
            {
                currentValue = "";
            }
        }

        public void WriteToPLC()
        {
			stream.Position = 0;
			writer.WritePlcAnsiString(currentValue, currentValue.Length + 1);
            Ads.Write(SymbolName, stream);
        }

    }


}
