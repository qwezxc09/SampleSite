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
    
    public partial class IusTags
    {
        public string TagName { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public string Algorithm { get; set; }
        public string InputSystem { get; set; }
        public string InputSource { get; set; }
        public string st108_InputSource { get; set; }
        public string st110_InputSource { get; set; }
        public string st111_InputSource { get; set; }
        public string st112_InputSource { get; set; }
        public string State_InputSource { get; set; }
        public string Value_Open_InputSource { get; set; }
        public string Value_Close_InputSource { get; set; }
        public string Value_HiHi_Limit { get; set; }
        public string Value_Hi_Limit { get; set; }
        public string Value_LoLo_Limit { get; set; }
        public string Value_Lo_Limit { get; set; }
        public string IsConvert { get; set; }
        public string IsHand { get; set; }
        public string Template { get; set; }
        public string Area { get; set; }
        public string Container { get; set; }
        public string ContainedName { get; set; }
        public string MinEU { get; set; }
        public string MaxEU { get; set; }
        public string MinRaw { get; set; }
        public string MaxRaw { get; set; }
        public string EngUnits { get; set; }
        public string Scale { get; set; }
        public Nullable<int> id_telemehanica_types { get; set; }
        public Nullable<int> id_telemehanica_levels { get; set; }
        public Nullable<int> kodLpu { get; set; }
        public Nullable<int> kodKs { get; set; }
        public Nullable<int> kodKc { get; set; }
        public Nullable<int> kodAgr { get; set; }
        public string IDObj { get; set; }
        public string IDType { get; set; }
    
        public virtual Telemehanica_levels Telemehanica_levels { get; set; }
    }
}
