using System;
using System.Collections.Generic;
using System.Linq;
using DemoGraphQL.AccesoDatos;
using DemoGraphQL.Models;

namespace DemoGraphQL.GraphQL.Repositories
{
    public class LugarRepository
    {
        private IEnumerable<Lugares> lugares = new List<Lugares>();
        private LugaresOperaciones lugaresOperaciones = new LugaresOperaciones();

        public LugarRepository()
        {
            lugares = lugaresOperaciones.getLugares();
        }

        public IEnumerable<Lugares> GetAllLugares()
        {
            return lugares;
        }

        public Lugares GetLugarById(int id)
        {
            return lugares.Where(lug => lug.id == id).FirstOrDefault();
        }

        public Lugares AddLugar(Lugares lugar) {
           /* lugares.Add( new Lugares {
                id = lugar.id,
                nombre = lugar.nombre,
                descripcion = lugar.descripcion,
                direccion = lugar.direccion,
                telefono = lugar.telefono,
                website = lugar.website
            });*/

            
            _ = lugaresOperaciones.insertLugar(lugar);

            return lugar;
        }
    }
}
