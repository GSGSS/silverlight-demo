
using System.Data.Objects;

namespace domain_service_auto_refresh_demo.Web
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


    // Implements application logic using the CountEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class CountDomainService : LinqToEntitiesDomainService<CountEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Counts' query.
        public IQueryable<Count> GetCounts()
        {
            return this.ObjectContext.Counts;
        }

        public void InsertCount(Count count)
        {
            if ((count.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(count, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Counts.AddObject(count);
            }
        }

        public void UpdateCount(Count currentCount)
        {
            this.ObjectContext.Counts.AttachAsModified(currentCount, this.ChangeSet.GetOriginal(currentCount));
        }

        public void DeleteCount(Count count)
        {
            if ((count.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(count, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Counts.Attach(count);
                this.ObjectContext.Counts.DeleteObject(count);
            }
        }
    }
}


