//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events_history
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public System.DateTime date { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public Nullable<int> object_id { get; set; }
    
        public virtual User User { get; set; }
    }
}