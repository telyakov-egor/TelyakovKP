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
	public partial class dcSpecialDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertSpecialnocti(Specialnocti instance);
    partial void UpdateSpecialnocti(Specialnocti instance);
    partial void DeleteSpecialnocti(Specialnocti instance);
    #endregion
		
		public dcSpecialDataContext() : 
				base(global::WpFKPTelyakov.Properties.Settings.Default.db, mappingSource)
		{
			OnCreated();
		}
		
		public dcSpecialDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcSpecialDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcSpecialDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcSpecialDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Specialnocti> Specialnocti
		{
			get
			{
				return this.GetTable<Specialnocti>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Specialnocti")]
	public partial class Specialnocti : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_spec;
		
		private string _Kod_specialnosti;
		
		private string _Name_special;
		
		private string _Opisanie_special;
		
		private string _Abbrev_spec;
		
		private System.Nullable<int> _kolvo_zauav;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_specChanging(int value);
    partial void OnId_specChanged();
    partial void OnKod_specialnostiChanging(string value);
    partial void OnKod_specialnostiChanged();
    partial void OnName_specialChanging(string value);
    partial void OnName_specialChanged();
    partial void OnOpisanie_specialChanging(string value);
    partial void OnOpisanie_specialChanged();
    partial void OnAbbrev_specChanging(string value);
    partial void OnAbbrev_specChanged();
    partial void Onkolvo_zauavChanging(System.Nullable<int> value);
    partial void Onkolvo_zauavChanged();
    #endregion
		
		public Specialnocti()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Id spec]", Storage="_Id_spec", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id_spec
		{
			get
			{
				return this._Id_spec;
			}
			set
			{
				if ((this._Id_spec != value))
				{
					this.OnId_specChanging(value);
					this.SendPropertyChanging();
					this._Id_spec = value;
					this.SendPropertyChanged("Id_spec");
					this.OnId_specChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Kod specialnosti]", Storage="_Kod_specialnosti", DbType="NVarChar(255)")]
		public string Kod_specialnosti
		{
			get
			{
				return this._Kod_specialnosti;
			}
			set
			{
				if ((this._Kod_specialnosti != value))
				{
					this.OnKod_specialnostiChanging(value);
					this.SendPropertyChanging();
					this._Kod_specialnosti = value;
					this.SendPropertyChanged("Kod_specialnosti");
					this.OnKod_specialnostiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Name special]", Storage="_Name_special", DbType="NVarChar(255)")]
		public string Name_special
		{
			get
			{
				return this._Name_special;
			}
			set
			{
				if ((this._Name_special != value))
				{
					this.OnName_specialChanging(value);
					this.SendPropertyChanging();
					this._Name_special = value;
					this.SendPropertyChanged("Name_special");
					this.OnName_specialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Opisanie special]", Storage="_Opisanie_special", DbType="NVarChar(255)")]
		public string Opisanie_special
		{
			get
			{
				return this._Opisanie_special;
			}
			set
			{
				if ((this._Opisanie_special != value))
				{
					this.OnOpisanie_specialChanging(value);
					this.SendPropertyChanging();
					this._Opisanie_special = value;
					this.SendPropertyChanged("Opisanie_special");
					this.OnOpisanie_specialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Abbrev spec]", Storage="_Abbrev_spec", DbType="NVarChar(255)")]
		public string Abbrev_spec
		{
			get
			{
				return this._Abbrev_spec;
			}
			set
			{
				if ((this._Abbrev_spec != value))
				{
					this.OnAbbrev_specChanging(value);
					this.SendPropertyChanging();
					this._Abbrev_spec = value;
					this.SendPropertyChanged("Abbrev_spec");
					this.OnAbbrev_specChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[kolvo zauav]", Storage="_kolvo_zauav", DbType="Int")]
		public System.Nullable<int> kolvo_zauav
		{
			get
			{
				return this._kolvo_zauav;
			}
			set
			{
				if ((this._kolvo_zauav != value))
				{
					this.Onkolvo_zauavChanging(value);
					this.SendPropertyChanging();
					this._kolvo_zauav = value;
					this.SendPropertyChanged("kolvo_zauav");
					this.Onkolvo_zauavChanged();
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
