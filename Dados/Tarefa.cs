//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dados
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarefa
    {
        public int codtodo { get; set; }
        public string titulo { get; set; }
        public Nullable<System.DateTime> validade { get; set; }
        public int codarea { get; set; }
        public string obs { get; set; }
    
        public virtual Area Area { get; set; }
    }
}
