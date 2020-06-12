﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kampusGymTeretana
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="kampusgym")]
	public partial class DataClasses4DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblZaposlenici(tblZaposlenici instance);
    partial void UpdatetblZaposlenici(tblZaposlenici instance);
    partial void DeletetblZaposlenici(tblZaposlenici instance);
    #endregion
		
		public DataClasses4DataContext() : 
				base(global::kampusGymTeretana.Properties.Settings.Default.kampusgymConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses4DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses4DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses4DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses4DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblZaposlenici> tblZaposlenicis
		{
			get
			{
				return this.GetTable<tblZaposlenici>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblZaposlenici")]
	public partial class tblZaposlenici : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _ime;
		
		private string _prezime;
		
		private string _email;
		
		private System.Nullable<int> _mobitel;
		
		private string _datum_rodenja;
		
		private System.Data.Linq.Binary _slika;
		
		private int _id_zaposlenika;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnimeChanging(string value);
    partial void OnimeChanged();
    partial void OnprezimeChanging(string value);
    partial void OnprezimeChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnmobitelChanging(System.Nullable<int> value);
    partial void OnmobitelChanged();
    partial void Ondatum_rodenjaChanging(string value);
    partial void Ondatum_rodenjaChanged();
    partial void OnslikaChanging(System.Data.Linq.Binary value);
    partial void OnslikaChanged();
    partial void Onid_zaposlenikaChanging(int value);
    partial void Onid_zaposlenikaChanged();
    #endregion
		
		public tblZaposlenici()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string ime
		{
			get
			{
				return this._ime;
			}
			set
			{
				if ((this._ime != value))
				{
					this.OnimeChanging(value);
					this.SendPropertyChanging();
					this._ime = value;
					this.SendPropertyChanged("ime");
					this.OnimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_prezime", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string prezime
		{
			get
			{
				return this._prezime;
			}
			set
			{
				if ((this._prezime != value))
				{
					this.OnprezimeChanging(value);
					this.SendPropertyChanging();
					this._prezime = value;
					this.SendPropertyChanged("prezime");
					this.OnprezimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mobitel", DbType="Int")]
		public System.Nullable<int> mobitel
		{
			get
			{
				return this._mobitel;
			}
			set
			{
				if ((this._mobitel != value))
				{
					this.OnmobitelChanging(value);
					this.SendPropertyChanging();
					this._mobitel = value;
					this.SendPropertyChanged("mobitel");
					this.OnmobitelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datum_rodenja", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string datum_rodenja
		{
			get
			{
				return this._datum_rodenja;
			}
			set
			{
				if ((this._datum_rodenja != value))
				{
					this.Ondatum_rodenjaChanging(value);
					this.SendPropertyChanging();
					this._datum_rodenja = value;
					this.SendPropertyChanged("datum_rodenja");
					this.Ondatum_rodenjaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slika", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary slika
		{
			get
			{
				return this._slika;
			}
			set
			{
				if ((this._slika != value))
				{
					this.OnslikaChanging(value);
					this.SendPropertyChanging();
					this._slika = value;
					this.SendPropertyChanged("slika");
					this.OnslikaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_zaposlenika", DbType="Int NOT NULL")]
		public int id_zaposlenika
		{
			get
			{
				return this._id_zaposlenika;
			}
			set
			{
				if ((this._id_zaposlenika != value))
				{
					this.Onid_zaposlenikaChanging(value);
					this.SendPropertyChanging();
					this._id_zaposlenika = value;
					this.SendPropertyChanged("id_zaposlenika");
					this.Onid_zaposlenikaChanged();
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