﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gallery
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class GalleryContainer : DbContext
    {
        public GalleryContainer()
            : base("name=GalleryContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Galeria> Galeria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    
        public virtual int SP_INSERT_FOTO(byte[] iMAGEN, Nullable<int> iD_GALERIA)
        {
            var iMAGENParameter = iMAGEN != null ?
                new ObjectParameter("IMAGEN", iMAGEN) :
                new ObjectParameter("IMAGEN", typeof(byte[]));
    
            var iD_GALERIAParameter = iD_GALERIA.HasValue ?
                new ObjectParameter("ID_GALERIA", iD_GALERIA) :
                new ObjectParameter("ID_GALERIA", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_FOTO", iMAGENParameter, iD_GALERIAParameter);
        }
    
        public virtual int SP_INSERT_GALERIA(string nombre, string cORREO)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_GALERIA", nombreParameter, cORREOParameter);
        }
    
        public virtual int SP_INSERT_USUARIO(string nombre, string cORREO, string cONTRASENA)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var cONTRASENAParameter = cONTRASENA != null ?
                new ObjectParameter("CONTRASENA", cONTRASENA) :
                new ObjectParameter("CONTRASENA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_INSERT_USUARIO", nombreParameter, cORREOParameter, cONTRASENAParameter);
        }
    
        public virtual ObjectResult<byte[]> SP_SELECT_FOTO(Nullable<int> iD_GALERIA)
        {
            var iD_GALERIAParameter = iD_GALERIA.HasValue ?
                new ObjectParameter("ID_GALERIA", iD_GALERIA) :
                new ObjectParameter("ID_GALERIA", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("SP_SELECT_FOTO", iD_GALERIAParameter);
        }
    
        public virtual ObjectResult<string> SP_SELECT_GALERIA(Nullable<int> iD_USUARIO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_SELECT_GALERIA", iD_USUARIOParameter);
        }
    
        public virtual ObjectResult<SP_SELECT_USUARIOS_Result> SP_SELECT_USUARIOS(string cORREO)
        {
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_USUARIOS_Result>("SP_SELECT_USUARIOS", cORREOParameter);
        }
    }
}
