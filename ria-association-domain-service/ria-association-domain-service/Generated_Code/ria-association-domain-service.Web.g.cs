//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ria_association_domain_service
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
namespace ria_association_domain_service.Web
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
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// The 'Book' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ria_association_domain_service.Web")]
    public sealed partial class Book : Entity
    {
        
        private int _id;
        
        private string _isbn;
        
        private string _name;
        
        private EntityCollection<Record> _records;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnIsbnChanging(string value);
        partial void OnIsbnChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the 'Id' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnIdChanging(value);
                    this.ValidateProperty("Id", value);
                    this._id = value;
                    this.RaisePropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Isbn' value.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(25)]
        public string Isbn
        {
            get
            {
                return this._isbn;
            }
            set
            {
                if ((this._isbn != value))
                {
                    this.OnIsbnChanging(value);
                    this.RaiseDataMemberChanging("Isbn");
                    this.ValidateProperty("Isbn", value);
                    this._isbn = value;
                    this.RaiseDataMemberChanged("Isbn");
                    this.OnIsbnChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Name' value.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(50)]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnNameChanging(value);
                    this.RaiseDataMemberChanging("Name");
                    this.ValidateProperty("Name", value);
                    this._name = value;
                    this.RaiseDataMemberChanged("Name");
                    this.OnNameChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets the collection of associated <see cref="Record"/> entity instances.
        /// </summary>
        [Association("Book_Record", "Id", "bookId")]
        [XmlIgnore()]
        public EntityCollection<Record> Records
        {
            get
            {
                if ((this._records == null))
                {
                    this._records = new EntityCollection<Record>(this, "Records", this.FilterRecords, this.AttachRecords, this.DetachRecords);
                }
                return this._records;
            }
        }
        
        private void AttachRecords(Record entity)
        {
            entity.Book = this;
        }
        
        private void DetachRecords(Record entity)
        {
            entity.Book = null;
        }
        
        private bool FilterRecords(Record entity)
        {
            return (entity.bookId == this.Id);
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
    /// The DomainContext corresponding to the 'LibraryService' DomainService.
    /// </summary>
    public sealed partial class LibraryContext : DomainContext
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryContext"/> class.
        /// </summary>
        public LibraryContext() : 
                this(new WebDomainClient<ILibraryServiceContract>(new Uri("ria_association_domain_service-Web-LibraryService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryContext"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The LibraryService service URI.</param>
        public LibraryContext(Uri serviceUri) : 
                this(new WebDomainClient<ILibraryServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryContext"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public LibraryContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="Book"/> entity instances that have been loaded into this <see cref="LibraryContext"/> instance.
        /// </summary>
        public EntitySet<Book> Books
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Book>();
            }
        }
        
        /// <summary>
        /// Gets the set of <see cref="Record"/> entity instances that have been loaded into this <see cref="LibraryContext"/> instance.
        /// </summary>
        public EntitySet<Record> Records
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Record>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Book"/> entity instances using the 'GetBooks' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Book"/> entity instances.</returns>
        public EntityQuery<Book> GetBooksQuery()
        {
            this.ValidateMethod("GetBooksQuery", null);
            return base.CreateQuery<Book>("GetBooks", null, false, true);
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Record"/> entity instances using the 'GetRecords' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Record"/> entity instances.</returns>
        public EntityQuery<Record> GetRecordsQuery()
        {
            this.ValidateMethod("GetRecordsQuery", null);
            return base.CreateQuery<Record>("GetRecords", null, false, true);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new LibraryContextEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'LibraryService' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface ILibraryServiceContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetBooks' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/LibraryService/GetBooksDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/LibraryService/GetBooks", ReplyAction="http://tempuri.org/LibraryService/GetBooksResponse")]
            [WebGet()]
            IAsyncResult BeginGetBooks(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetBooks'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetBooks'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetBooks' operation.</returns>
            QueryResult<Book> EndGetBooks(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'GetRecords' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/LibraryService/GetRecordsDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/LibraryService/GetRecords", ReplyAction="http://tempuri.org/LibraryService/GetRecordsResponse")]
            [WebGet()]
            IAsyncResult BeginGetRecords(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetRecords'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetRecords'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetRecords' operation.</returns>
            QueryResult<Record> EndGetRecords(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'SubmitChanges' operation.
            /// </summary>
            /// <param name="changeSet">The change-set to submit.</param>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/LibraryService/SubmitChangesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/LibraryService/SubmitChanges", ReplyAction="http://tempuri.org/LibraryService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginSubmitChanges'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginSubmitChanges'.</param>
            /// <returns>The collection of change-set entry elements returned from 'SubmitChanges'.</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class LibraryContextEntityContainer : EntityContainer
        {
            
            public LibraryContextEntityContainer()
            {
                this.CreateEntitySet<Book>(EntitySetOperations.All);
                this.CreateEntitySet<Record>(EntitySetOperations.All);
            }
        }
    }
    
    /// <summary>
    /// The 'Record' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ria_association_domain_service.Web")]
    public sealed partial class Record : Entity
    {
        
        private EntityRef<Book> _book;
        
        private int _bookId;
        
        private DateTime _endTime;
        
        private int _id;
        
        private DateTime _startTime;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnbookIdChanging(int value);
        partial void OnbookIdChanged();
        partial void OnendTimeChanging(DateTime value);
        partial void OnendTimeChanged();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnstartTimeChanging(DateTime value);
        partial void OnstartTimeChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class.
        /// </summary>
        public Record()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the associated <see cref="Book"/> entity.
        /// </summary>
        [Association("Book_Record", "bookId", "Id", IsForeignKey=true)]
        [XmlIgnore()]
        public Book Book
        {
            get
            {
                if ((this._book == null))
                {
                    this._book = new EntityRef<Book>(this, "Book", this.FilterBook);
                }
                return this._book.Entity;
            }
            set
            {
                Book previous = this.Book;
                if ((previous != value))
                {
                    this.ValidateProperty("Book", value);
                    if ((previous != null))
                    {
                        this._book.Entity = null;
                        previous.Records.Remove(this);
                    }
                    if ((value != null))
                    {
                        this.bookId = value.Id;
                    }
                    else
                    {
                        this.bookId = default(int);
                    }
                    this._book.Entity = value;
                    if ((value != null))
                    {
                        value.Records.Add(this);
                    }
                    this.RaisePropertyChanged("Book");
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'bookId' value.
        /// </summary>
        [DataMember()]
        [RoundtripOriginal()]
        public int bookId
        {
            get
            {
                return this._bookId;
            }
            set
            {
                if ((this._bookId != value))
                {
                    this.OnbookIdChanging(value);
                    this.RaiseDataMemberChanging("bookId");
                    this.ValidateProperty("bookId", value);
                    this._bookId = value;
                    this.RaiseDataMemberChanged("bookId");
                    this.OnbookIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'endTime' value.
        /// </summary>
        [DataMember()]
        public DateTime endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                if ((this._endTime != value))
                {
                    this.OnendTimeChanging(value);
                    this.RaiseDataMemberChanging("endTime");
                    this.ValidateProperty("endTime", value);
                    this._endTime = value;
                    this.RaiseDataMemberChanged("endTime");
                    this.OnendTimeChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'id' value.
        /// </summary>
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
        /// Gets or sets the 'startTime' value.
        /// </summary>
        [DataMember()]
        public DateTime startTime
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
                    this.RaiseDataMemberChanging("startTime");
                    this.ValidateProperty("startTime", value);
                    this._startTime = value;
                    this.RaiseDataMemberChanged("startTime");
                    this.OnstartTimeChanged();
                }
            }
        }
        
        private bool FilterBook(Book entity)
        {
            return (entity.Id == this.bookId);
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
}