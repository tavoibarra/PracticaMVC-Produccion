//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaMVC.EN
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios_Permisos
    {
        public int IdUsuarioPermiso { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdPermiso { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual Permisos Permisos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}