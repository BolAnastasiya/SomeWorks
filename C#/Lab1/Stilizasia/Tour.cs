//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stilizasia
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        public int id { get; set; }
        public Nullable<int> Ticket_count { get; set; }
        public string Name_tour { get; set; }
        public string Description_tour { get; set; }
        public byte[] Image_preview { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<bool> Is_Actual { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual Type_Hotel Type_Hotel { get; set; }
    }
}