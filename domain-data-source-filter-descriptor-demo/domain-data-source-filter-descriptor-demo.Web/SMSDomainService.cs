
namespace domain_data_source_filter_descriptor_demo.Web
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


    // Implements application logic using the MobileEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class SMSDomainService : LinqToEntitiesDomainService<MobileEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SMS' query.
        public IQueryable<SM> GetSMS()
        {
            return this.ObjectContext.SMS;
        }

        public void InsertSM(SM sM)
        {
            if ((sM.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sM, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SMS.AddObject(sM);
            }
        }

        public void UpdateSM(SM currentSM)
        {
            this.ObjectContext.SMS.AttachAsModified(currentSM, this.ChangeSet.GetOriginal(currentSM));
        }

        public void DeleteSM(SM sM)
        {
            if ((sM.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sM, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SMS.Attach(sM);
                this.ObjectContext.SMS.DeleteObject(sM);
            }
        }
    }
}


