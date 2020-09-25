using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repository
{
    public class TypeRepository: ITypeRepository
    {
        static int id = 1;
        private static List<Core.Entities.Type> _types = new List<Core.Entities.Type>();

        public Core.Entities.Type Create(Core.Entities.Type ty)
        {
            ty.ID = id++;
            _types.Add(ty);
            return ty;
        }

        public Core.Entities.Type Delete(int id)
        {
            var typeFound = this.FindTypebyId(id);
            if (typeFound != null)
            {
                _types.Remove(typeFound);
                return typeFound;
            }
            return null;
        }

        public Core.Entities.Type FindTypebyId(int id)
        {
            foreach (var type in _types)
            {
                if (type.ID == id)
                {
                    return type;
                }
            }

            return null;
        }

        public void IntialiseData()
        {
            _types = FakeDB.InitDataTypes();
            IDAfterInit();
        }


        public object ReadType()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Entities.Type> ReadTypes()
        {
            return _types;
        }

        private void IDAfterInit()
        {
            id = FakeDB.getID();
        }

        IEnumerable<Core.Entities.Type> ITypeRepository.ReadType()
        {
            throw new NotImplementedException();
        }
    }
}
