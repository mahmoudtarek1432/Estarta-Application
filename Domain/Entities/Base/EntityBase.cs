using Shared_Kernal.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstraction
{
     public abstract class EntityBase <T> 
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public Guid? CreatedBy { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public Guid? ModifiedBy { get; private set; }

        public List<Event> DomainEvents = new(); //so far no data manipulation so no use for it


        public void SetCreatedBy(Guid? id)
        {
            if (id == null)
            {
                return;
            }

            CreatedAt = DateTime.Now;
            CreatedBy = id;
        }

        public void SetModifiedBy(Guid? id)
        {
            if (id == null)
            {
                return;
            }

            ModifiedAt = DateTime.Now;
            ModifiedBy = id;
        }

        public void AddDomainEvent(Event eventItem)
        {
            DomainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            DomainEvents.Clear();
        }
    }
}
}
