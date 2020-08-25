using System.Collections.Generic;
using System.Linq;
using Stats_Api.DTO;
using WCL_Api_Library.DTO;

namespace Stats_Api.Extensions
{
    public static class DTOExtensions
    {
        public static List<GearCount> GetGearSummary(this IEnumerable<Gear> gearList)
        {
            var groupedGearList = gearList.GroupBy(s => s.Id)
                .Select(t => new GearCount
                {
                    Id = t.Key,
                    Quantity = t.Select(u => u.Id).Count(),
                    Name = t.FirstOrDefault(s => s.Id == t.Key)?.Name,
                    Slot = t.FirstOrDefault(s => s.Id == t.Key)?.Slot.ToString()
                }).OrderByDescending(u => u.Quantity).ToList();
            
            // // "Hack" to replace NULL id's in gear to an "Unknown Item Reward" Link, for wowhead href + icon
            // foreach (var gearCount in groupedGearList.Where(s=>s.Id == null))
            // {
            //     gearCount.Id = 1217;
            // }
            
            // Remove sets which contain NULL gear id's
            groupedGearList.RemoveAll(s => s.Id == null);
            
            return groupedGearList;
        }

        public static List<Gear> GetGear(this IEnumerable<List<Gear>> gears, Slot slot)
        {
            return gears.Select(s => s.ElementAtOrDefault((int) slot)).ToList();
        }
    }
}