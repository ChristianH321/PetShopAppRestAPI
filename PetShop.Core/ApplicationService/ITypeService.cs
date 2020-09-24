using System;
using PetShop.Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface ITypeService
    {

        Entities.Type CreateType(Entities.Type ty);
        Entities.Type DeleteType(int id);
        List<Entities.Type> GetType();
        void InitDatabaseDataType();
        List<Entities.Type> getAllByType(string chosenType);
        List<Entities.Type> GetTypes();
        Entities.Type NewType(string typetype);
        Entities.Type UpdateType(Entities.Type typeUpdate);
        Entities.Type FindTypeById(int id);




    }
}
