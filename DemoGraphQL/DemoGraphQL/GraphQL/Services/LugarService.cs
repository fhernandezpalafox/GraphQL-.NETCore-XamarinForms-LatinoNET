using System;
using System.Collections.Generic;
using DemoGraphQL.GraphQL.Repositories;
using DemoGraphQL.Models;

namespace DemoGraphQL.GraphQL.Services
{
    public class LugarService
    {
        private readonly LugarRepository _lugarRepository;

        public LugarService(LugarRepository lugarRepository)
        {
           _lugarRepository = lugarRepository;   
        }

        public IEnumerable<Lugares> GetAllLugares()
        {
            return _lugarRepository.GetAllLugares();
        }

        public Lugares GetLugarById(int id)
        {
            return _lugarRepository.GetLugarById(id);
        }

        public Lugares AddLugar(Lugares lugar)
        {
            return _lugarRepository.AddLugar(lugar);
        }
    }
}
