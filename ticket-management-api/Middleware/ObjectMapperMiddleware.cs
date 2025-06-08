using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ticket_management_api.Data.Entities;
using ticket_management_api.Data.Objects;


namespace rafi_mfi_contact_center_api.Middlewares
{
    public class ObjectMapperMiddleware : Profile
    {
        public ObjectMapperMiddleware()
        {
            CreateMap<Account, AccountDto>().AfterMap((src, dest) =>
            {
                dest.Id = src.Id.Value.ToString();
                dest.CoordinatorId = src.CoordinatorId != null ? src.CoordinatorId.Value.ToString() : "";
            }).ReverseMap();
        }
    }
}