//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace domain_service_auto_refresh_demo
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
namespace domain_service_auto_refresh_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.ServiceModel.Web;
    
    
    /// <summary>
    /// The 'Count' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/domain_service_auto_refresh_demo.Web")]
    public sealed partial class Count : Entity
    {
        
        private string _message;
        
        private int _value;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnmessageChanging(string value);
        partial void OnmessageChanged();
        partial void OnvalueChanging(int value);
        partial void OnvalueChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Count"/> class.
        /// </summary>
        public Count()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the 'message' value.
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string message
        {
            get
            {
                return this._message;
            }
            set
            {
                if ((this._message != value))
                {
                    this.OnmessageChanging(value);
                    this.RaiseDataMemberChanging("message");
                    this.ValidateProperty("message", value);
                    this._message = value;
                    this.RaiseDataMemberChanged("message");
                    this.OnmessageChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'value' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public int value
        {
            get
            {
                return this._value;
            }
            set
            {
                if ((this._value != value))
                {
                    this.OnvalueChanging(value);
                    this.ValidateProperty("value", value);
                    this._value = value;
                    this.RaisePropertyChanged("value");
                    this.OnvalueChanged();
                }
            }
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._value;
        }
    }
    
    /// <summary>
    /// The DomainContext corresponding to the 'CountDomainService' DomainService.
    /// </summary>
    public sealed partial class CountDomainContext : DomainContext
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountDomainContext"/> class.
        /// </summary>
        public CountDomainContext() : 
                this(new WebDomainClient<ICountDomainServiceContract>(new Uri("domain_service_auto_refresh_demo-Web-CountDomainService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountDomainContext"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The CountDomainService service URI.</param>
        public CountDomainContext(Uri serviceUri) : 
                this(new WebDomainClient<ICountDomainServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountDomainContext"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public CountDomainContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="Count"/> entity instances that have been loaded into this <see cref="CountDomainContext"/> instance.
        /// </summary>
        public EntitySet<Count> Counts
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Count>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Count"/> entity instances using the 'GetCounts' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Count"/> entity instances.</returns>
        public EntityQuery<Count> GetCountsQuery()
        {
            this.ValidateMethod("GetCountsQuery", null);
            return base.CreateQuery<Count>("GetCounts", null, false, true);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new CountDomainContextEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'CountDomainService' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface ICountDomainServiceContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetCounts' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/CountDomainService/GetCountsDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/CountDomainService/GetCounts", ReplyAction="http://tempuri.org/CountDomainService/GetCountsResponse")]
            [WebGet()]
            IAsyncResult BeginGetCounts(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetCounts'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetCounts'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetCounts' operation.</returns>
            QueryResult<Count> EndGetCounts(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'SubmitChanges' operation.
            /// </summary>
            /// <param name="changeSet">The change-set to submit.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/CountDomainService/SubmitChangesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/CountDomainService/SubmitChanges", ReplyAction="http://tempuri.org/CountDomainService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginSubmitChanges'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginSubmitChanges'.</param>
            /// <returns>The collection of change-set entry elements returned from 'SubmitChanges'.</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class CountDomainContextEntityContainer : EntityContainer
        {
            
            public CountDomainContextEntityContainer()
            {
                this.CreateEntitySet<Count>(EntitySetOperations.All);
            }
        }
    }
}
