﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsApiexamen
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BdiExamenEntities : DbContext
    {
        public BdiExamenEntities()
            : base("name=BdiExamenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblExamen> tblExamen { get; set; }
    
        public virtual int sp_DeleteExamen(Nullable<int> idExamen, ObjectParameter codigoRetorno, ObjectParameter descripcionRetorno)
        {
            var idExamenParameter = idExamen.HasValue ?
                new ObjectParameter("idExamen", idExamen) :
                new ObjectParameter("idExamen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteExamen", idExamenParameter, codigoRetorno, descripcionRetorno);
        }
    
        public virtual ObjectResult<sp_GetExamen_Result> sp_GetExamen(Nullable<int> idExamen)
        {
            var idExamenParameter = idExamen.HasValue ?
                new ObjectParameter("idExamen", idExamen) :
                new ObjectParameter("idExamen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetExamen_Result>("sp_GetExamen", idExamenParameter);
        }
    
        public virtual int sp_InsertExamen(string nombre, string descripcion, ObjectParameter codigoRetorno, ObjectParameter descripcionRetorno, ObjectParameter idExamen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertExamen", nombreParameter, descripcionParameter, codigoRetorno, descripcionRetorno, idExamen);
        }
    
        public virtual int sp_UpdateExamen(Nullable<int> idExamen, string nombre, string descripcion, ObjectParameter codigoRetorno, ObjectParameter descripcionRetorno)
        {
            var idExamenParameter = idExamen.HasValue ?
                new ObjectParameter("idExamen", idExamen) :
                new ObjectParameter("idExamen", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateExamen", idExamenParameter, nombreParameter, descripcionParameter, codigoRetorno, descripcionRetorno);
        }
    }
}
