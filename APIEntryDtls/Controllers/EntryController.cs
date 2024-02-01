using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEntryDtls;
using APIEntryDtls.AppData;
using APIEntryDtls.Services;

namespace APIEntryDtls.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly DummyContext _context;
        public IEntry _entry;

        public EntryController(DummyContext context, IEntry entry)
        {
            _context = context;
            _entry = entry;
        }

        // GET: Entry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryDetailsClass>>> Get()
        {
            var entryList = await _entry.GetEntryDetailsClass();
            if (entryList == null)
            {
                return Problem("Error while fetching the data");
            }
            return Ok(entryList);
        }

        // GET: Entry/5
        [HttpGet("{Pid}")]
        public async Task<ActionResult<EntryDetailsClass>> Get(int Pid)
        {
            if (Pid == 0)
            {
                return Problem("Entered id is Zero.");
            }
            var entryDetailsClass = await _entry.GetEntryDetailsByID(Pid);
            if (entryDetailsClass == null)
            {
                return Problem("Not Exist.");
            }
            return entryDetailsClass;
        }

        // POST: Entry
        [HttpPost]
        public async Task<ActionResult<IEnumerable<EntryDetailsClass>>> Post(EntryDetailsClass entryDetailsClass)
        {
            if (entryDetailsClass == null)
            {
                return Problem("Your Input is Null.");
            }
            var entryList = await _entry.CreateEntryDetails(entryDetailsClass);
            if(entryList == null) 
            {
                return Problem("Error while adding");
            }
            return Ok(entryList);
        }

        // DELETE: Entry/5
        [HttpDelete("{Pid}")]
        public async Task<IActionResult> Delete(int Pid)
        {
            if (Pid == 0)
            {
                return Problem("Can't proceed for execution,as Pid value is Zero");
            }
            var msg = await _entry.DeleteEntryDetailsClass(Pid);
            if(msg != "Removed")
            {
                return Problem(msg);
            }
            return Ok("Deleted Successfully");
        }
    }
}
