using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAP.Foliacion.Datos
{
    public class Transaccion : IDisposable
    {
        private FoliacionEntities2 _contexto;
        public Transaccion()
        {
            _contexto = new FoliacionEntities2();
        }
        internal FoliacionEntities2 Contexto
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
