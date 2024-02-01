using Microsoft.AspNetCore.Mvc;

namespace APIEntryDtls.Services
{
    public interface IEntry
    {
        public Task<List<EntryDetailsClass>> GetEntryDetailsClass();
        public Task<EntryDetailsClass> GetEntryDetailsByID(int id);
        public Task<List<EntryDetailsClass>> CreateEntryDetails(EntryDetailsClass entryDetailsClass);
        public Task<string> DeleteEntryDetailsClass(int id);
    }
}
