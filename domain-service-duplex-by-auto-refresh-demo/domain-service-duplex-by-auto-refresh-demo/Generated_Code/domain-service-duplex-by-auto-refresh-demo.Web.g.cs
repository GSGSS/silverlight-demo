//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace domain_service_duplex_by_auto_refresh_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    
    
    /// <summary>
    /// Context for the RIA application.
    /// </summary>
    /// <remarks>
    /// This context extends the base to make application services and types available
    /// for consumption from code and xaml.
    /// </remarks>
    public sealed partial class WebContext : WebContextBase
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the WebContext class.
        /// </summary>
        public WebContext()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the context that is registered as a lifetime object with the current application.
        /// </summary>
        /// <exception cref="InvalidOperationException"> is thrown if there is no current application,
        /// no contexts have been added, or more than one context has been added.
        /// </exception>
        /// <seealso cref="System.Windows.Application.ApplicationLifetimeObjects"/>
        public new static WebContext Current
        {
            get
            {
                return ((WebContext)(WebContextBase.Current));
            }
        }
    }
}
namespace domain_service_duplex_by_auto_refresh_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.ServiceModel.Web;
    
    
    /// <summary>
    /// The 'Register' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/domain_service_duplex_by_auto_refresh_dem" +
        "o.Web")]
    public sealed partial class Register : Entity
    {
        
        private int _id;
        
        private string _name;
        
        private string _status;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstatusChanging(string value);
        partial void OnstatusChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        public Register()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the 'id' value.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
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
                    this.ValidateProperty("id", value);
                    this._id = value;
                    this.RaisePropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'name' value.
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.RaiseDataMemberChanging("name");
                    this.ValidateProperty("name", value);
                    this._name = value;
                    this.RaiseDataMemberChanged("name");
                    this.OnnameChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'status' value.
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string status
        {
            get
            {
                return this._status;
            }
            set
            {
                if ((this._status != value))
                {
                    this.OnstatusChanging(value);
                    this.RaiseDataMemberChanging("status");
                    this.ValidateProperty("status", value);
                    this._status = value;
                    this.RaiseDataMemberChanged("status");
                    this.OnstatusChanged();
                }
            }
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._id;
        }
    }
    
    /// <summary>
    /// The DomainContext corresponding to the 'RegisterDomainService' DomainService.
    /// </summary>
    public sealed partial class RegisterDomainContext : DomainContext
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterDomainContext"/> class.
        /// </summary>
        public RegisterDomainContext() : 
                this(new WebDomainClient<IRegisterDomainServiceContract>(new Uri("domain_service_duplex_by_auto_refresh_demo-Web-RegisterDomainService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterDomainContext"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The RegisterDomainService service URI.</param>
        public RegisterDomainContext(Uri serviceUri) : 
                this(new WebDomainClient<IRegisterDomainServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterDomainContext"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public RegisterDomainContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="Register"/> entity instances that have been loaded into this <see cref="RegisterDomainContext"/> instance.
        /// </summary>
        public EntitySet<Register> Registers
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Register>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Register"/> entity instances using the 'GetRegisters' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Register"/> entity instances.</returns>
        public EntityQuery<Register> GetRegistersQuery()
        {
            this.ValidateMethod("GetRegistersQuery", null);
            return base.CreateQuery<Register>("GetRegisters", null, false, true);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new RegisterDomainContextEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'RegisterDomainService' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface IRegisterDomainServiceContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetRegisters' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/RegisterDomainService/GetRegistersDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/RegisterDomainService/GetRegisters", ReplyAction="http://tempuri.org/RegisterDomainService/GetRegistersResponse")]
            [WebGet()]
            IAsyncResult BeginGetRegisters(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetRegisters'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetRegisters'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetRegisters' operation.</returns>
            QueryResult<Register> EndGetRegisters(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'SubmitChanges' operation.
            /// </summary>
            /// <param name="changeSet">The change-set to submit.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/RegisterDomainService/SubmitChangesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/RegisterDomainService/SubmitChanges", ReplyAction="http://tempuri.org/RegisterDomainService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginSubmitChanges'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginSubmitChanges'.</param>
            /// <returns>The collection of change-set entry elements returned from 'SubmitChanges'.</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class RegisterDomainContextEntityContainer : EntityContainer
        {
            
            public RegisterDomainContextEntityContainer()
            {
                this.CreateEntitySet<Register>(EntitySetOperations.All);
            }
        }
    }
}
