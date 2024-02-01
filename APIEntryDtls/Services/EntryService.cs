using APIEntryDtls.AppData;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace APIEntryDtls.Services
{
    public class EntryService : IEntry
    {
        private readonly DummyContext _context;
        private readonly IMapper _mapper;
        public EntryService(DummyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EntryDetailsClass>> GetEntryDetailsClass()
        {
            try 
            {
                var listformDB = await _context.EntryDetails.ToListAsync();
                return _mapper.Map<List<EntryDetailsClass>>(listformDB);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<EntryDetailsClass> GetEntryDetailsByID(int Pid)
        {
            if (Pid == 0)
            {
                return null;
            }
            var entryDetailsFind = await _context.EntryDetails.Where(x => x.Pid == Pid).FirstOrDefaultAsync();

            if (entryDetailsFind == null)
            {
                return null;
            }
            return _mapper.Map<EntryDetailsClass>(entryDetailsFind);
        }

        private List<EntryDetail> ReturnEntryDetailsList()
        {
            var listformDB = _context.EntryDetails.ToList();
            return listformDB;
        }

        public async Task<List<EntryDetailsClass>> CreateEntryDetails(EntryDetailsClass entryDetailsClass)
        {
            var listformDB = new List<EntryDetailsClass>();
            if (entryDetailsClass == null)
            {
                return null;
            }
            try
            {
                var list = _mapper.Map<List<EntryDetailsClass>>(ReturnEntryDetailsList());
                var entryDetailsFind = list.Where(x => x.PId == entryDetailsClass.PId).FirstOrDefault();

                if (entryDetailsFind != null)
                {
                    return null;
                }

                var entryDetail = _mapper.Map<EntryDetail>(entryDetailsClass);
                _context.EntryDetails.Add(entryDetail);
                await _context.SaveChangesAsync();

                listformDB = _mapper.Map<List<EntryDetailsClass>>(ReturnEntryDetailsList());
            }
            catch (Exception)
            {
                return null;
            }
            return listformDB;
        }
        public async Task<string> DeleteEntryDetailsClass(int Pid)
        {
            if (Pid == 0)
            {
                return "Can't proceed for execution,as Pid value is Zero";
            }
            try
            {
                var entryDetailsFind = await _context.EntryDetails.Where(x => x.Pid == Pid).FirstOrDefaultAsync();
                if (entryDetailsFind == null)
                {
                    return "Unable to remove.This Pid is not available in our record";
                }
                var entryDetail = _mapper.Map<EntryDetail>(entryDetailsFind);

                _context.EntryDetails.Remove(entryDetail);
                await _context.SaveChangesAsync();

                return "Removed";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "Unable to remove";
        }

    }
}
