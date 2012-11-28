
namespace domain_service_duplex_by_auto_refresh_demo.Web
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


    // Implements application logic using the ChatEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class RegisterDomainService : LinqToEntitiesDomainService<ChatEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Registers' query.
        public IQueryable<Register> GetRegisters()
        {
            return this.ObjectContext.Registers;
        }

        public void InsertRegister(Register register)
        {
            if ((register.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(register, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Registers.AddObject(register);
            }
        }

        public void UpdateRegister(Register currentRegister)
        {
            this.ObjectContext.Registers.AttachAsModified(currentRegister, this.ChangeSet.GetOriginal(currentRegister));
        }

        public void DeleteRegister(Register register)
        {
            if ((register.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(register, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Registers.Attach(register);
                this.ObjectContext.Registers.DeleteObject(register);
            }
        }
    }
}


