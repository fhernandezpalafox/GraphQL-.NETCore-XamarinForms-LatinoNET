using System;
using DemoGraphQL.Models;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Types
{
    public class LugaresType: ObjectGraphType<Lugares>
    {
        public LugaresType()
        {
            Name = "Lugar";
            Field(x => x.id).Description("Id del lugar");
            Field(x => x.nombre).Description("Nombre del lugar");
            Field(x => x.descripcion);
            Field(x => x.direccion);
            Field(x => x.telefono);
            Field(x => x.website);
        }
    }
}
