//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecreationСenter.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            this.ResidenceClients = new HashSet<ResidenceClients>();
        }
    
        public int roomID { get; set; }
        public Nullable<int> numberRoom { get; set; }
        public Nullable<decimal> price { get; set; }
        public int amountPlaces { get; set; }
        public Nullable<int> amountFreePlaces { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResidenceClients> ResidenceClients { get; set; }
    }
}
