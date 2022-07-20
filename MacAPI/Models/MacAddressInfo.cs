using Microsoft.EntityFrameworkCore;

namespace MacAPI.Models
{
    public class MacAddressInfo
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
