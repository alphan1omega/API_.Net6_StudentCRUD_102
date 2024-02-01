using APIEntryDtls.AppData;
using AutoMapper;

namespace APIEntryDtls.Helper
{
    public class AutoMapperProf : Profile
    {
        public AutoMapperProf()
        {
            CreateMap<EntryDetail, EntryDetailsClass>();
            CreateMap<EntryDetailsClass, EntryDetail>();
        }
    }
}
