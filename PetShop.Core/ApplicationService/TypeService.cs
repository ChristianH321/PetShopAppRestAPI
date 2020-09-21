using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public class TypeService: ITypeService
    {

        private ITypeRepository _typeRepo;

        public TypeService(ITypeRepository perReposit)
        {
            _typeRepo = perReposit;
        }


        public void InitDatabaseDataType()
        {
            _typeRepo.IntialiseData();
        }

        public Entities.Type FindTypeById(int id)
        {
            return _typeRepo.FindTypebyId(id);
        }


        public Entities.Type CreateType(Entities.Type ty)
        {
            return _typeRepo.Create(ty);
        }

        public Entities.Type DeleteType(int id)
        {
            return _typeRepo.Delete(id);
        }

        public List<Entities.Type> GetType()
        {
            return _typeRepo.ReadTypes().ToList();
        }

        public List<Entities.Type> getAllByType(string chosenType)
        {
            var allTypes = GetTypes();
            List<Entities.Type> searchedListOfTypes = new List<Entities.Type>();
            foreach (var type in allTypes)
            {
                if (type.TypeType.Contains(chosenType))
                {
                    searchedListOfTypes.Add(type);
                }
            }

            return searchedListOfTypes;
        }

        public List<Entities.Type> GetTypes()
        {
            return _typeRepo.ReadTypes().ToList();
        }

        public Entities.Type NewType(string typetype)
        {
            var ty = new Entities.Type()
            {
                TypeType = typetype,
            };

            return ty;
        }

        public Entities.Type UpdateType(Entities.Type typeUpdate)
        {
            var type = FindTypeById(typeUpdate.ID);
            type.TypeType = typeUpdate.TypeType;

            return type;
        }
    }
}
