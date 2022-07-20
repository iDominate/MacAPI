using MacAPI.Context;
using MacAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacAPI.Repository
{
    public class MacAddressRespository : IMacAddressRepository
    {
        private MacDbContext context;
        public MacAddressRespository(MacDbContext context)
        {
            this.context = context;
        }

        public void AddMacAddress(MacAddressInfo macAddressInfo)
        {
            context.MacAddresses.Add(macAddressInfo);
            context.SaveChanges();
        }

        public bool DeleteMacAddress(string macAddress)
        {
            var existingMac = context.MacAddresses.Where(m=> m.MacAddress == macAddress).FirstOrDefault();
            if (existingMac == null)
            {
                return false;
            }
            context.MacAddresses.Remove(existingMac);
            context.SaveChanges();
            return true;
        }

        public List<MacAddressInfo> GetAllMacAddresses()
        {
            return context.MacAddresses.ToList();
        }

        public MacAddressInfo? GetByMacAddress(string macAddress)
        {
            var existingMac = context.MacAddresses.Where(m => m.MacAddress == macAddress).FirstOrDefault();
            if (existingMac != null)
            {
                return existingMac;
            }
            return null;
        }

        public bool UpdateMacAddress(MacAddressInfo macAddressInfo)
        {
            var existingMac = context.MacAddresses.Find(macAddressInfo.Id);
            if(existingMac != null)
            {
                existingMac.MacAddress = macAddressInfo.MacAddress;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

