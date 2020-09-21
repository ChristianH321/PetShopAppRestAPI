using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
    public interface ITypeRepository
    {
        Entities.Type Create(Entities.Type ty);
        Entities.Type Delete(int id);
        void IntialiseData();
        IEnumerable<Entities.Type> ReadTypes();
        Entities.Type FindTypebyId(int id);
        IEnumerable<Entities.Type> ReadType();
    }
}
