﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonAppliWeb.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bddPandami")]
	public partial class DataClasses2DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertserviceRequest(serviceRequest instance);
    partial void UpdateserviceRequest(serviceRequest instance);
    partial void DeleteserviceRequest(serviceRequest instance);
    partial void Insertmember(member instance);
    partial void Updatemember(member instance);
    partial void Deletemember(member instance);
    partial void InsertserviceName(serviceName instance);
    partial void UpdateserviceName(serviceName instance);
    partial void DeleteserviceName(serviceName instance);
    partial void Insertanswer(answer instance);
    partial void Updateanswer(answer instance);
    partial void Deleteanswer(answer instance);
    #endregion
		
		public DataClasses2DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["bddPandamiConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses2DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<serviceRequest> serviceRequest
		{
			get
			{
				return this.GetTable<serviceRequest>();
			}
		}
		
		public System.Data.Linq.Table<member> member
		{
			get
			{
				return this.GetTable<member>();
			}
		}
		
		public System.Data.Linq.Table<serviceName> serviceName
		{
			get
			{
				return this.GetTable<serviceName>();
			}
		}
		
		public System.Data.Linq.Table<requestAnswer> requestAnswer
		{
			get
			{
				return this.GetTable<requestAnswer>();
			}
		}
		
		public System.Data.Linq.Table<answer> answer
		{
			get
			{
				return this.GetTable<answer>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.serviceRequest")]
	public partial class serviceRequest : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _serviceRequestID;
		
		private System.DateTime _serviceStartDate;
		
		private System.Nullable<System.DateTime> _serviceEndDate;
		
		private string _serviceAddress;
		
		private System.Nullable<bool> _priority;
		
		private System.DateTime _creationDate;
		
		private System.Nullable<System.DateTime> _cancelDate;
		
		private System.Nullable<System.TimeSpan> _startTime;
		
		private int _serviceFK;
		
		private System.Nullable<int> _serviceCityFK;
		
		private int _memberFK;
		
		private System.Nullable<int> _voluntaryMemberFK;
		
		private EntityRef<member> _member;
		
		private EntityRef<member> _member1;
		
		private EntityRef<serviceName> _serviceName;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnserviceRequestIDChanging(int value);
    partial void OnserviceRequestIDChanged();
    partial void OnserviceStartDateChanging(System.DateTime value);
    partial void OnserviceStartDateChanged();
    partial void OnserviceEndDateChanging(System.Nullable<System.DateTime> value);
    partial void OnserviceEndDateChanged();
    partial void OnserviceAddressChanging(string value);
    partial void OnserviceAddressChanged();
    partial void OnpriorityChanging(System.Nullable<bool> value);
    partial void OnpriorityChanged();
    partial void OncreationDateChanging(System.DateTime value);
    partial void OncreationDateChanged();
    partial void OncancelDateChanging(System.Nullable<System.DateTime> value);
    partial void OncancelDateChanged();
    partial void OnstartTimeChanging(System.Nullable<System.TimeSpan> value);
    partial void OnstartTimeChanged();
    partial void OnserviceFKChanging(int value);
    partial void OnserviceFKChanged();
    partial void OnserviceCityFKChanging(System.Nullable<int> value);
    partial void OnserviceCityFKChanged();
    partial void OnmemberFKChanging(int value);
    partial void OnmemberFKChanged();
    partial void OnvoluntaryMemberFKChanging(System.Nullable<int> value);
    partial void OnvoluntaryMemberFKChanged();
    #endregion
		
		public serviceRequest()
		{
			this._member = default(EntityRef<member>);
			this._member1 = default(EntityRef<member>);
			this._serviceName = default(EntityRef<serviceName>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceRequestID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int serviceRequestID
		{
			get
			{
				return this._serviceRequestID;
			}
			set
			{
				if ((this._serviceRequestID != value))
				{
					this.OnserviceRequestIDChanging(value);
					this.SendPropertyChanging();
					this._serviceRequestID = value;
					this.SendPropertyChanged("serviceRequestID");
					this.OnserviceRequestIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceStartDate", DbType="Date NOT NULL")]
		public System.DateTime serviceStartDate
		{
			get
			{
				return this._serviceStartDate;
			}
			set
			{
				if ((this._serviceStartDate != value))
				{
					this.OnserviceStartDateChanging(value);
					this.SendPropertyChanging();
					this._serviceStartDate = value;
					this.SendPropertyChanged("serviceStartDate");
					this.OnserviceStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceEndDate", DbType="Date")]
		public System.Nullable<System.DateTime> serviceEndDate
		{
			get
			{
				return this._serviceEndDate;
			}
			set
			{
				if ((this._serviceEndDate != value))
				{
					this.OnserviceEndDateChanging(value);
					this.SendPropertyChanging();
					this._serviceEndDate = value;
					this.SendPropertyChanged("serviceEndDate");
					this.OnserviceEndDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceAddress", DbType="NVarChar(120)")]
		public string serviceAddress
		{
			get
			{
				return this._serviceAddress;
			}
			set
			{
				if ((this._serviceAddress != value))
				{
					this.OnserviceAddressChanging(value);
					this.SendPropertyChanging();
					this._serviceAddress = value;
					this.SendPropertyChanged("serviceAddress");
					this.OnserviceAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_priority", DbType="Bit")]
		public System.Nullable<bool> priority
		{
			get
			{
				return this._priority;
			}
			set
			{
				if ((this._priority != value))
				{
					this.OnpriorityChanging(value);
					this.SendPropertyChanging();
					this._priority = value;
					this.SendPropertyChanged("priority");
					this.OnpriorityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creationDate", DbType="Date NOT NULL")]
		public System.DateTime creationDate
		{
			get
			{
				return this._creationDate;
			}
			set
			{
				if ((this._creationDate != value))
				{
					this.OncreationDateChanging(value);
					this.SendPropertyChanging();
					this._creationDate = value;
					this.SendPropertyChanged("creationDate");
					this.OncreationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cancelDate", DbType="Date")]
		public System.Nullable<System.DateTime> cancelDate
		{
			get
			{
				return this._cancelDate;
			}
			set
			{
				if ((this._cancelDate != value))
				{
					this.OncancelDateChanging(value);
					this.SendPropertyChanging();
					this._cancelDate = value;
					this.SendPropertyChanged("cancelDate");
					this.OncancelDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_startTime", DbType="Time")]
		public System.Nullable<System.TimeSpan> startTime
		{
			get
			{
				return this._startTime;
			}
			set
			{
				if ((this._startTime != value))
				{
					this.OnstartTimeChanging(value);
					this.SendPropertyChanging();
					this._startTime = value;
					this.SendPropertyChanged("startTime");
					this.OnstartTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceFK", DbType="Int NOT NULL")]
		public int serviceFK
		{
			get
			{
				return this._serviceFK;
			}
			set
			{
				if ((this._serviceFK != value))
				{
					if (this._serviceName.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnserviceFKChanging(value);
					this.SendPropertyChanging();
					this._serviceFK = value;
					this.SendPropertyChanged("serviceFK");
					this.OnserviceFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceCityFK", DbType="Int")]
		public System.Nullable<int> serviceCityFK
		{
			get
			{
				return this._serviceCityFK;
			}
			set
			{
				if ((this._serviceCityFK != value))
				{
					this.OnserviceCityFKChanging(value);
					this.SendPropertyChanging();
					this._serviceCityFK = value;
					this.SendPropertyChanged("serviceCityFK");
					this.OnserviceCityFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_memberFK", DbType="Int NOT NULL")]
		public int memberFK
		{
			get
			{
				return this._memberFK;
			}
			set
			{
				if ((this._memberFK != value))
				{
					if (this._member.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmemberFKChanging(value);
					this.SendPropertyChanging();
					this._memberFK = value;
					this.SendPropertyChanged("memberFK");
					this.OnmemberFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_voluntaryMemberFK", DbType="Int")]
		public System.Nullable<int> voluntaryMemberFK
		{
			get
			{
				return this._voluntaryMemberFK;
			}
			set
			{
				if ((this._voluntaryMemberFK != value))
				{
					if (this._member1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnvoluntaryMemberFKChanging(value);
					this.SendPropertyChanging();
					this._voluntaryMemberFK = value;
					this.SendPropertyChanged("voluntaryMemberFK");
					this.OnvoluntaryMemberFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_serviceRequest", Storage="_member", ThisKey="memberFK", OtherKey="memberID", IsForeignKey=true)]
		public member member
		{
			get
			{
				return this._member.Entity;
			}
			set
			{
				member previousValue = this._member.Entity;
				if (((previousValue != value) 
							|| (this._member.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._member.Entity = null;
						previousValue.serviceRequest.Remove(this);
					}
					this._member.Entity = value;
					if ((value != null))
					{
						value.serviceRequest.Add(this);
						this._memberFK = value.memberID;
					}
					else
					{
						this._memberFK = default(int);
					}
					this.SendPropertyChanged("member");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_serviceRequest1", Storage="_member1", ThisKey="voluntaryMemberFK", OtherKey="memberID", IsForeignKey=true)]
		public member member1
		{
			get
			{
				return this._member1.Entity;
			}
			set
			{
				member previousValue = this._member1.Entity;
				if (((previousValue != value) 
							|| (this._member1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._member1.Entity = null;
						previousValue.serviceRequest1.Remove(this);
					}
					this._member1.Entity = value;
					if ((value != null))
					{
						value.serviceRequest1.Add(this);
						this._voluntaryMemberFK = value.memberID;
					}
					else
					{
						this._voluntaryMemberFK = default(Nullable<int>);
					}
					this.SendPropertyChanged("member1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="serviceName_serviceRequest", Storage="_serviceName", ThisKey="serviceFK", OtherKey="serviceID", IsForeignKey=true)]
		public serviceName serviceName
		{
			get
			{
				return this._serviceName.Entity;
			}
			set
			{
				serviceName previousValue = this._serviceName.Entity;
				if (((previousValue != value) 
							|| (this._serviceName.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._serviceName.Entity = null;
						previousValue.serviceRequest.Remove(this);
					}
					this._serviceName.Entity = value;
					if ((value != null))
					{
						value.serviceRequest.Add(this);
						this._serviceFK = value.serviceID;
					}
					else
					{
						this._serviceFK = default(int);
					}
					this.SendPropertyChanged("serviceName");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.member")]
	public partial class member : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _memberID;
		
		private string _firstName;
		
		private string _lastName;
		
		private System.DateTime _birthdate;
		
		private string _email;
		
		private int _phone;
		
		private string _address;
		
		private string _login;
		
		private int _cityFK;
		
		private string _password;
		
		private System.Nullable<int> _serviceRequestFK;
		
		private System.Nullable<int> _dailyPrefFK;
		
		private System.Nullable<int> _servicePrefFK;
		
		private EntitySet<serviceRequest> _serviceRequest;
		
		private EntitySet<serviceRequest> _serviceRequest1;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmemberIDChanging(int value);
    partial void OnmemberIDChanged();
    partial void OnfirstNameChanging(string value);
    partial void OnfirstNameChanged();
    partial void OnlastNameChanging(string value);
    partial void OnlastNameChanged();
    partial void OnbirthdateChanging(System.DateTime value);
    partial void OnbirthdateChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnphoneChanging(int value);
    partial void OnphoneChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnloginChanging(string value);
    partial void OnloginChanged();
    partial void OncityFKChanging(int value);
    partial void OncityFKChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnserviceRequestFKChanging(System.Nullable<int> value);
    partial void OnserviceRequestFKChanged();
    partial void OndailyPrefFKChanging(System.Nullable<int> value);
    partial void OndailyPrefFKChanged();
    partial void OnservicePrefFKChanging(System.Nullable<int> value);
    partial void OnservicePrefFKChanged();
    #endregion
		
		public member()
		{
			this._serviceRequest = new EntitySet<serviceRequest>(new Action<serviceRequest>(this.attach_serviceRequest), new Action<serviceRequest>(this.detach_serviceRequest));
			this._serviceRequest1 = new EntitySet<serviceRequest>(new Action<serviceRequest>(this.attach_serviceRequest1), new Action<serviceRequest>(this.detach_serviceRequest1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_memberID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int memberID
		{
			get
			{
				return this._memberID;
			}
			set
			{
				if ((this._memberID != value))
				{
					this.OnmemberIDChanging(value);
					this.SendPropertyChanging();
					this._memberID = value;
					this.SendPropertyChanged("memberID");
					this.OnmemberIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string firstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if ((this._firstName != value))
				{
					this.OnfirstNameChanging(value);
					this.SendPropertyChanging();
					this._firstName = value;
					this.SendPropertyChanged("firstName");
					this.OnfirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string lastName
		{
			get
			{
				return this._lastName;
			}
			set
			{
				if ((this._lastName != value))
				{
					this.OnlastNameChanging(value);
					this.SendPropertyChanging();
					this._lastName = value;
					this.SendPropertyChanged("lastName");
					this.OnlastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_birthdate", DbType="DateTime2 NOT NULL")]
		public System.DateTime birthdate
		{
			get
			{
				return this._birthdate;
			}
			set
			{
				if ((this._birthdate != value))
				{
					this.OnbirthdateChanging(value);
					this.SendPropertyChanging();
					this._birthdate = value;
					this.SendPropertyChanged("birthdate");
					this.OnbirthdateChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="Int NOT NULL")]
		public int phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(120) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this.OnloginChanging(value);
					this.SendPropertyChanging();
					this._login = value;
					this.SendPropertyChanged("login");
					this.OnloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cityFK", DbType="Int NOT NULL")]
		public int cityFK
		{
			get
			{
				return this._cityFK;
			}
			set
			{
				if ((this._cityFK != value))
				{
					this.OncityFKChanging(value);
					this.SendPropertyChanging();
					this._cityFK = value;
					this.SendPropertyChanged("cityFK");
					this.OncityFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceRequestFK", DbType="Int")]
		public System.Nullable<int> serviceRequestFK
		{
			get
			{
				return this._serviceRequestFK;
			}
			set
			{
				if ((this._serviceRequestFK != value))
				{
					this.OnserviceRequestFKChanging(value);
					this.SendPropertyChanging();
					this._serviceRequestFK = value;
					this.SendPropertyChanged("serviceRequestFK");
					this.OnserviceRequestFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dailyPrefFK", DbType="Int")]
		public System.Nullable<int> dailyPrefFK
		{
			get
			{
				return this._dailyPrefFK;
			}
			set
			{
				if ((this._dailyPrefFK != value))
				{
					this.OndailyPrefFKChanging(value);
					this.SendPropertyChanging();
					this._dailyPrefFK = value;
					this.SendPropertyChanged("dailyPrefFK");
					this.OndailyPrefFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_servicePrefFK", DbType="Int")]
		public System.Nullable<int> servicePrefFK
		{
			get
			{
				return this._servicePrefFK;
			}
			set
			{
				if ((this._servicePrefFK != value))
				{
					this.OnservicePrefFKChanging(value);
					this.SendPropertyChanging();
					this._servicePrefFK = value;
					this.SendPropertyChanged("servicePrefFK");
					this.OnservicePrefFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_serviceRequest", Storage="_serviceRequest", ThisKey="memberID", OtherKey="memberFK")]
		public EntitySet<serviceRequest> serviceRequest
		{
			get
			{
				return this._serviceRequest;
			}
			set
			{
				this._serviceRequest.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="member_serviceRequest1", Storage="_serviceRequest1", ThisKey="memberID", OtherKey="voluntaryMemberFK")]
		public EntitySet<serviceRequest> serviceRequest1
		{
			get
			{
				return this._serviceRequest1;
			}
			set
			{
				this._serviceRequest1.Assign(value);
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
		
		private void attach_serviceRequest(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.member = this;
		}
		
		private void detach_serviceRequest(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.member = null;
		}
		
		private void attach_serviceRequest1(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.member1 = this;
		}
		
		private void detach_serviceRequest1(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.member1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.serviceName")]
	public partial class serviceName : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _serviceID;
		
		private string _serviceName1;
		
		private int _serviceCategoryFK;
		
		private EntitySet<serviceRequest> _serviceRequest;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnserviceIDChanging(int value);
    partial void OnserviceIDChanged();
    partial void OnserviceName1Changing(string value);
    partial void OnserviceName1Changed();
    partial void OnserviceCategoryFKChanging(int value);
    partial void OnserviceCategoryFKChanged();
    #endregion
		
		public serviceName()
		{
			this._serviceRequest = new EntitySet<serviceRequest>(new Action<serviceRequest>(this.attach_serviceRequest), new Action<serviceRequest>(this.detach_serviceRequest));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int serviceID
		{
			get
			{
				return this._serviceID;
			}
			set
			{
				if ((this._serviceID != value))
				{
					this.OnserviceIDChanging(value);
					this.SendPropertyChanging();
					this._serviceID = value;
					this.SendPropertyChanged("serviceID");
					this.OnserviceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="serviceName", Storage="_serviceName1", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string serviceName1
		{
			get
			{
				return this._serviceName1;
			}
			set
			{
				if ((this._serviceName1 != value))
				{
					this.OnserviceName1Changing(value);
					this.SendPropertyChanging();
					this._serviceName1 = value;
					this.SendPropertyChanged("serviceName1");
					this.OnserviceName1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceCategoryFK", DbType="Int NOT NULL")]
		public int serviceCategoryFK
		{
			get
			{
				return this._serviceCategoryFK;
			}
			set
			{
				if ((this._serviceCategoryFK != value))
				{
					this.OnserviceCategoryFKChanging(value);
					this.SendPropertyChanging();
					this._serviceCategoryFK = value;
					this.SendPropertyChanged("serviceCategoryFK");
					this.OnserviceCategoryFKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="serviceName_serviceRequest", Storage="_serviceRequest", ThisKey="serviceID", OtherKey="serviceFK")]
		public EntitySet<serviceRequest> serviceRequest
		{
			get
			{
				return this._serviceRequest;
			}
			set
			{
				this._serviceRequest.Assign(value);
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
		
		private void attach_serviceRequest(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.serviceName = this;
		}
		
		private void detach_serviceRequest(serviceRequest entity)
		{
			this.SendPropertyChanging();
			entity.serviceName = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.requestAnswer")]
	public partial class requestAnswer
	{
		
		private System.Nullable<System.DateTime> _refusalDate;
		
		private System.Nullable<System.DateTime> _acceptanceDate;
		
		private System.Nullable<System.DateTime> _cancelDate;
		
		private System.DateTime _answerDate;
		
		private int _serviceRFK;
		
		private string _answerFK;
		
		public requestAnswer()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_refusalDate", DbType="Date")]
		public System.Nullable<System.DateTime> refusalDate
		{
			get
			{
				return this._refusalDate;
			}
			set
			{
				if ((this._refusalDate != value))
				{
					this._refusalDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_acceptanceDate", DbType="Date")]
		public System.Nullable<System.DateTime> acceptanceDate
		{
			get
			{
				return this._acceptanceDate;
			}
			set
			{
				if ((this._acceptanceDate != value))
				{
					this._acceptanceDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cancelDate", DbType="Date")]
		public System.Nullable<System.DateTime> cancelDate
		{
			get
			{
				return this._cancelDate;
			}
			set
			{
				if ((this._cancelDate != value))
				{
					this._cancelDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_answerDate", DbType="Date NOT NULL")]
		public System.DateTime answerDate
		{
			get
			{
				return this._answerDate;
			}
			set
			{
				if ((this._answerDate != value))
				{
					this._answerDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_serviceRFK", DbType="Int NOT NULL")]
		public int serviceRFK
		{
			get
			{
				return this._serviceRFK;
			}
			set
			{
				if ((this._serviceRFK != value))
				{
					this._serviceRFK = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_answerFK", DbType="NChar(10)")]
		public string answerFK
		{
			get
			{
				return this._answerFK;
			}
			set
			{
				if ((this._answerFK != value))
				{
					this._answerFK = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.answer")]
	public partial class answer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _answerID;
		
		private string _answer1;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnanswerIDChanging(string value);
    partial void OnanswerIDChanged();
    partial void Onanswer1Changing(string value);
    partial void Onanswer1Changed();
    #endregion
		
		public answer()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_answerID", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string answerID
		{
			get
			{
				return this._answerID;
			}
			set
			{
				if ((this._answerID != value))
				{
					this.OnanswerIDChanging(value);
					this.SendPropertyChanging();
					this._answerID = value;
					this.SendPropertyChanged("answerID");
					this.OnanswerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="answer", Storage="_answer1", DbType="NVarChar(3)")]
		public string answer1
		{
			get
			{
				return this._answer1;
			}
			set
			{
				if ((this._answer1 != value))
				{
					this.Onanswer1Changing(value);
					this.SendPropertyChanging();
					this._answer1 = value;
					this.SendPropertyChanged("answer1");
					this.Onanswer1Changed();
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
