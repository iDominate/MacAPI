using MacAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacAPI.Repository
{
    public interface IMacAddressRepository
    {

        List<MacAddressInfo> GetAllMacAddresses();
        MacAddressInfo? GetByMacAddress(string macAddress);
        void AddMacAddress(MacAddressInfo macAddressInfo);
        bool DeleteMacAddress(string macAddressId);
        bool UpdateMacAddress(MacAddressInfo macAddressInfo);

    }
}
