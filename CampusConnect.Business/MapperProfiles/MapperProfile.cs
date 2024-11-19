using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Business.MapperProfiles
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateBusinessUnitMapping();
        }

        private void CreateBusinessUnitMapping()
        {
            CreateMap<DataAccess.DataModels.CampusConnect.DataAccess.DataModels.User, Entities.UserModel>();
        }

    }
}
