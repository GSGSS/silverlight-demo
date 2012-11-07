
namespace ria_association_domain_service.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the LibraryEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class LibraryService : LinqToEntitiesDomainService<LibraryEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Books' query.
        public IQueryable<Book> GetBooks()
        {
            return this.ObjectContext.Books;
        }

        public void InsertBook(Book book)
        {
            if ((book.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(book, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Books.AddObject(book);
            }
        }

        public void UpdateBook(Book currentBook)
        {
            this.ObjectContext.Books.AttachAsModified(currentBook, this.ChangeSet.GetOriginal(currentBook));
        }

        public void DeleteBook(Book book)
        {
            if ((book.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(book, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Books.Attach(book);
                this.ObjectContext.Books.DeleteObject(book);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Records' query.
        public IQueryable<Record> GetRecords()
        {
            return this.ObjectContext.Records.Include("Book");
        }

        public void InsertRecord(Record record)
        {
            if ((record.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(record, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Records.AddObject(record);
            }
        }

        public void UpdateRecord(Record currentRecord)
        {
            this.ObjectContext.Records.AttachAsModified(currentRecord, this.ChangeSet.GetOriginal(currentRecord));
        }

        public void DeleteRecord(Record record)
        {
            if ((record.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(record, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Records.Attach(record);
                this.ObjectContext.Records.DeleteObject(record);
            }
        }
    }
}


