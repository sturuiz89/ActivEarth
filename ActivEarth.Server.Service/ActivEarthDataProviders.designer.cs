﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActivEarth.Server.Service
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ActivEarth_Dev")]
	public partial class ActivEarthDataProvidersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProfileDataProvider(ProfileDataProvider instance);
    partial void UpdateProfileDataProvider(ProfileDataProvider instance);
    partial void DeleteProfileDataProvider(ProfileDataProvider instance);
    partial void InsertUserDataProvider(UserDataProvider instance);
    partial void UpdateUserDataProvider(UserDataProvider instance);
    partial void DeleteUserDataProvider(UserDataProvider instance);
    #endregion
		
		public ActivEarthDataProvidersDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ActivEarth_DevConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ActivEarthDataProvidersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ActivEarthDataProvidersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ActivEarthDataProvidersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ActivEarthDataProvidersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ProfileDataProvider> ProfileDataProviders
		{
			get
			{
				return this.GetTable<ProfileDataProvider>();
			}
		}
		
		public System.Data.Linq.Table<UserDataProvider> UserDataProviders
		{
			get
			{
				return this.GetTable<UserDataProvider>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.profile")]
	public partial class ProfileDataProvider : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _user_id;
		
		private string _first_name;
		
		private string _last_name;
		
		private string _email;
		
		private char _gender;
		
		private string _city;
		
		private string _state;
		
		private EntityRef<UserDataProvider> _UserDataProvider;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onfirst_nameChanging(string value);
    partial void Onfirst_nameChanged();
    partial void Onlast_nameChanging(string value);
    partial void Onlast_nameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OngenderChanging(char value);
    partial void OngenderChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OnstateChanging(string value);
    partial void OnstateChanged();
    #endregion
		
		public ProfileDataProvider()
		{
			this._UserDataProvider = default(EntityRef<UserDataProvider>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._UserDataProvider.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_first_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string first_name
		{
			get
			{
				return this._first_name;
			}
			set
			{
				if ((this._first_name != value))
				{
					this.Onfirst_nameChanging(value);
					this.SendPropertyChanging();
					this._first_name = value;
					this.SendPropertyChanged("first_name");
					this.Onfirst_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_last_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string last_name
		{
			get
			{
				return this._last_name;
			}
			set
			{
				if ((this._last_name != value))
				{
					this.Onlast_nameChanging(value);
					this.SendPropertyChanging();
					this._last_name = value;
					this.SendPropertyChanged("last_name");
					this.Onlast_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="Char(1) NOT NULL")]
		public char gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="VarChar(50)")]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state", DbType="Char(2)")]
		public string state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this.OnstateChanging(value);
					this.SendPropertyChanging();
					this._state = value;
					this.SendPropertyChanged("state");
					this.OnstateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_profile", Storage="_UserDataProvider", ThisKey="user_id", OtherKey="id", IsForeignKey=true)]
		public UserDataProvider UserDataProvider
		{
			get
			{
				return this._UserDataProvider.Entity;
			}
			set
			{
				UserDataProvider previousValue = this._UserDataProvider.Entity;
				if (((previousValue != value) 
							|| (this._UserDataProvider.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserDataProvider.Entity = null;
						previousValue.ProfileDataProviders.Remove(this);
					}
					this._UserDataProvider.Entity = value;
					if ((value != null))
					{
						value.ProfileDataProviders.Add(this);
						this._user_id = value.id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("UserDataProvider");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class UserDataProvider : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _user_name;
		
		private string _password;
		
		private EntitySet<ProfileDataProvider> _ProfileDataProviders;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onuser_nameChanging(string value);
    partial void Onuser_nameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    #endregion
		
		public UserDataProvider()
		{
			this._ProfileDataProviders = new EntitySet<ProfileDataProvider>(new Action<ProfileDataProvider>(this.attach_ProfileDataProviders), new Action<ProfileDataProvider>(this.detach_ProfileDataProviders));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string user_name
		{
			get
			{
				return this._user_name;
			}
			set
			{
				if ((this._user_name != value))
				{
					this.Onuser_nameChanging(value);
					this.SendPropertyChanging();
					this._user_name = value;
					this.SendPropertyChanged("user_name");
					this.Onuser_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(20)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_profile", Storage="_ProfileDataProviders", ThisKey="id", OtherKey="user_id")]
		public EntitySet<ProfileDataProvider> ProfileDataProviders
		{
			get
			{
				return this._ProfileDataProviders;
			}
			set
			{
				this._ProfileDataProviders.Assign(value);
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
		
		private void attach_ProfileDataProviders(ProfileDataProvider entity)
		{
			this.SendPropertyChanging();
			entity.UserDataProvider = this;
		}
		
		private void detach_ProfileDataProviders(ProfileDataProvider entity)
		{
			this.SendPropertyChanging();
			entity.UserDataProvider = null;
		}
	}
}
#pragma warning restore 1591
