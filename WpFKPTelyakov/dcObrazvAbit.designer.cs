﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpFKPTelyakov
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="telyakovKP")]
	public partial class dcObrazvAbitDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertObrazovanie_Abityr(Obrazovanie_Abityr instance);
    partial void UpdateObrazovanie_Abityr(Obrazovanie_Abityr instance);
    partial void DeleteObrazovanie_Abityr(Obrazovanie_Abityr instance);
    #endregion
		
		public dcObrazvAbitDataContext() : 
				base(global::WpFKPTelyakov.Properties.Settings.Default.db, mappingSource)
		{
			OnCreated();
		}
		
		public dcObrazvAbitDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcObrazvAbitDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcObrazvAbitDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcObrazvAbitDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Obrazovanie_Abityr> Obrazovanie_Abityr
		{
			get
			{
				return this.GetTable<Obrazovanie_Abityr>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Obrazovanie_Abityr")]
	public partial class Obrazovanie_Abityr : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_abit_ych_zav;
		
		private string _Kod_LD;
		
		private string _Tip_YZ;
		
		private string _Name_YZ;
		
		private string _Region;
		
		private string _Izych_yazik;
		
		private string _Vid_docum_obr;
		
		private string _Seriy_num_doc_obr;
		
		private string _Data_vidachi_obr;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_abit_ych_zavChanging(int value);
    partial void OnID_abit_ych_zavChanged();
    partial void OnKod_LDChanging(string value);
    partial void OnKod_LDChanged();
    partial void OnTip_YZChanging(string value);
    partial void OnTip_YZChanged();
    partial void OnName_YZChanging(string value);
    partial void OnName_YZChanged();
    partial void OnRegionChanging(string value);
    partial void OnRegionChanged();
    partial void OnIzych_yazikChanging(string value);
    partial void OnIzych_yazikChanged();
    partial void OnVid_docum_obrChanging(string value);
    partial void OnVid_docum_obrChanged();
    partial void OnSeriy_num_doc_obrChanging(string value);
    partial void OnSeriy_num_doc_obrChanged();
    partial void OnData_vidachi_obrChanging(string value);
    partial void OnData_vidachi_obrChanged();
    #endregion
		
		public Obrazovanie_Abityr()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID abit ych zav]", Storage="_ID_abit_ych_zav", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID_abit_ych_zav
		{
			get
			{
				return this._ID_abit_ych_zav;
			}
			set
			{
				if ((this._ID_abit_ych_zav != value))
				{
					this.OnID_abit_ych_zavChanging(value);
					this.SendPropertyChanging();
					this._ID_abit_ych_zav = value;
					this.SendPropertyChanged("ID_abit_ych_zav");
					this.OnID_abit_ych_zavChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Kod LD]", Storage="_Kod_LD", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Kod_LD
		{
			get
			{
				return this._Kod_LD;
			}
			set
			{
				if ((this._Kod_LD != value))
				{
					this.OnKod_LDChanging(value);
					this.SendPropertyChanging();
					this._Kod_LD = value;
					this.SendPropertyChanged("Kod_LD");
					this.OnKod_LDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Tip YZ]", Storage="_Tip_YZ", DbType="NVarChar(255)")]
		public string Tip_YZ
		{
			get
			{
				return this._Tip_YZ;
			}
			set
			{
				if ((this._Tip_YZ != value))
				{
					this.OnTip_YZChanging(value);
					this.SendPropertyChanging();
					this._Tip_YZ = value;
					this.SendPropertyChanged("Tip_YZ");
					this.OnTip_YZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Name YZ]", Storage="_Name_YZ", DbType="NVarChar(255)")]
		public string Name_YZ
		{
			get
			{
				return this._Name_YZ;
			}
			set
			{
				if ((this._Name_YZ != value))
				{
					this.OnName_YZChanging(value);
					this.SendPropertyChanging();
					this._Name_YZ = value;
					this.SendPropertyChanged("Name_YZ");
					this.OnName_YZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Region", DbType="NVarChar(255)")]
		public string Region
		{
			get
			{
				return this._Region;
			}
			set
			{
				if ((this._Region != value))
				{
					this.OnRegionChanging(value);
					this.SendPropertyChanging();
					this._Region = value;
					this.SendPropertyChanged("Region");
					this.OnRegionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Izych yazik]", Storage="_Izych_yazik", DbType="NVarChar(255)")]
		public string Izych_yazik
		{
			get
			{
				return this._Izych_yazik;
			}
			set
			{
				if ((this._Izych_yazik != value))
				{
					this.OnIzych_yazikChanging(value);
					this.SendPropertyChanging();
					this._Izych_yazik = value;
					this.SendPropertyChanged("Izych_yazik");
					this.OnIzych_yazikChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Vid docum obr]", Storage="_Vid_docum_obr", DbType="NVarChar(255)")]
		public string Vid_docum_obr
		{
			get
			{
				return this._Vid_docum_obr;
			}
			set
			{
				if ((this._Vid_docum_obr != value))
				{
					this.OnVid_docum_obrChanging(value);
					this.SendPropertyChanging();
					this._Vid_docum_obr = value;
					this.SendPropertyChanged("Vid_docum_obr");
					this.OnVid_docum_obrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Seriy num doc obr]", Storage="_Seriy_num_doc_obr", DbType="NVarChar(255)")]
		public string Seriy_num_doc_obr
		{
			get
			{
				return this._Seriy_num_doc_obr;
			}
			set
			{
				if ((this._Seriy_num_doc_obr != value))
				{
					this.OnSeriy_num_doc_obrChanging(value);
					this.SendPropertyChanging();
					this._Seriy_num_doc_obr = value;
					this.SendPropertyChanged("Seriy_num_doc_obr");
					this.OnSeriy_num_doc_obrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Data vidachi obr]", Storage="_Data_vidachi_obr", DbType="NVarChar(255)")]
		public string Data_vidachi_obr
		{
			get
			{
				return this._Data_vidachi_obr;
			}
			set
			{
				if ((this._Data_vidachi_obr != value))
				{
					this.OnData_vidachi_obrChanging(value);
					this.SendPropertyChanging();
					this._Data_vidachi_obr = value;
					this.SendPropertyChanged("Data_vidachi_obr");
					this.OnData_vidachi_obrChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
