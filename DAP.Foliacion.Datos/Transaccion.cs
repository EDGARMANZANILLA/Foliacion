using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAP.Foliacion.Datos
{
    public class Transaccion : IDisposable
    {
        private FoliacionEntities _contexto;
        public Transaccion()
        {
            _contexto = new FoliacionEntities();
        }
        internal FoliacionEntities Contexto
        {
            get
            {
                return _contexto;
            }
        }
        public void GuardarCambios()
        {
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
