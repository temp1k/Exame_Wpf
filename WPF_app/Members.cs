//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class Members
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
    
        public virtual Genders Genders { get; set; }
    }
}
