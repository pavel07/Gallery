//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gallery
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Galeria = new HashSet<Galeria>();
        }
    
        
        public string NOMBRE { get; set; }
        public string CORREO { get; set; }
        public string CONTRASENA { get; set; }
    
        public virtual ICollection<Galeria> Galeria { get; set; }
    }
}
