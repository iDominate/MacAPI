using MacAPI.Models;
using MacAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MacAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MacAddressInfoController : ControllerBase
    {
        private IMacAddressRepository repo;
        public MacAddressInfoController(IMacAddressRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public List<MacAddressInfo> GetAllMacAddresses()
        {
            return repo.GetAllMacAddresses();
        }

        [HttpPost]
        public ActionResult AddMacAddress(MacAddressInfo info)
        {
            if(info.MacAddress.Trim().Length < 12)
            {
                return NotFound();
            }
            repo.AddMacAddress(info);
            return Ok(info);
        }

        [HttpGet("{mac}")]
        public ActionResult GetInfoByMac(string mac)
        {
           var MacInfo = repo.GetByMacAddress(mac);
            return MacInfo != null ? Ok(MacInfo) : NotFound();

        }
       
        [HttpDelete]
        public ActionResult DeleteMac(string macAddress)
        {
           var existingMac = repo.DeleteMacAddress(macAddress);
            return existingMac ? Ok(existingMac) : NotFound();
        }

        [HttpPatch]
        public ActionResult UpdateMac(MacAddressInfo info)
        {
            var existingMac = repo.UpdateMacAddress(info);
            return existingMac ? Ok(existingMac) : NotFound();
        }
    }
}
