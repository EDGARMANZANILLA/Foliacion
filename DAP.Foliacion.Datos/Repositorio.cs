using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DAP.Foliacion.Entidades;

namespace DAP.Foliacion.Datos
{
    public class Repositorio<TEntity> : IDisposable where TEntity : class
    {
        private FoliacionEntities2 _contexto;

        public Repositorio(Transaccion transaccion)
        {
            _contexto = transaccion.Contexto;
        }

        private DbSet<TEntity> ConjuntoEntidades
        {
            get
            {
                /*
                var conjunto = _contexto.Set<TEntity>();
                ObjectQuery<TEntity> query = conjunto as ObjectQuery<TEntity>;
                query.MergeOption = MergeOption.AppendOnly;
                return conjunto;
                 */
                return _contexto.Set<TEntity>();
            }
        }

        public IQueryable<TEntity> ObtenerTodos()
        {
            return ConjuntoEntidades;
        }

        public TEntity Obtener(System.Linq.Expressions.Expression<Func<TEntity, bool>> criterio)
        {
            return ConjuntoEntidades.FirstOrDefault(criterio);
        }

        public IQueryable<TEntity> ObtenerPorFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> criterio)
        {
            return ConjuntoEntidades.Where(criterio);
        }

        public TEntity Agregar(TEntity EntidadAAgregar)
        {
            try
            {
                ConjuntoEntidades.Add(EntidadAAgregar);
                _contexto.SaveChanges();
                return EntidadAAgregar;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public TEntity Modificar(TEntity EntidadAModificar)
        {
            try
            {
                _contexto.Entry(EntidadAModificar).State = System.Data.EntityState.Modified;
                //_contexto.Entry<TEntity>(EntidadAModificar).State = System.Data.EntityState.Modified;
                _contexto.SaveChanges();
                return EntidadAModificar;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar", ex);
            }
        }

        public bool Eliminar(TEntity EntidadABorrar)
        {
            ConjuntoEntidades.Attach(EntidadABorrar);
            ConjuntoEntidades.Remove(EntidadABorrar);
            _contexto.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            //if (_contexto.Connection.State != System.Data.ConnectionState.Closed)
            //    _contexto.Connection.Close();
            //_contexto.Connection.Dispose();
            //_contexto.Dispose();
        }
    }
}
