//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRAKTIKA2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        public int TicketId { get; set; }
        public Nullable<int> PassengerId { get; set; }
        public string SeatNumber { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }
    
        public virtual Passengers Passengers { get; set; }
    }
}
