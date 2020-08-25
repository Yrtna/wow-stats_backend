using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stats_Api.DTO;
using Stats_Api.Extensions;
using WCL_Api_Library;
using WCL_Api_Library.DTO;
using Slot = WCL_Api_Library.DTO.Slot;

namespace Stats_Api.Controllers
{
    [Route("wclapi/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        static WCL_Api _wclClient = new WCL_Api();

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return
                "{\"Head\":[{\"id\":12640,\"quantity\":73,\"name\":\"Lionheart Helm\",\"slot\":\"Head\"},{\"id\":16542,\"quantity\":9,\"name\":\"Warlord's Plate Headpiece\",\"slot\":\"Head\"},{\"id\":23244,\"quantity\":5,\"name\":\"Champion's Plate Helm\",\"slot\":\"Head\"},{\"id\":19372,\"quantity\":4,\"name\":\"Helm of Endless Rage\",\"slot\":\"Head\"},{\"id\":16478,\"quantity\":3,\"name\":\"Field Marshal's Plate Helm\",\"slot\":\"Head\"},{\"id\":23314,\"quantity\":3,\"name\":\"Lieutenant Commander's Plate Helmet\",\"slot\":\"Head\"},{\"id\":16963,\"quantity\":1,\"name\":\"Helm of Wrath\",\"slot\":\"Head\"}],\"Neck\":[{\"id\":19856,\"quantity\":66,\"name\":\"The Eye of Hakkar\",\"slot\":\"Neck\"},{\"id\":18404,\"quantity\":32,\"name\":\"Onyxia Tooth Pendant\",\"slot\":\"Neck\"}],\"Shoulder\":[{\"id\":19394,\"quantity\":44,\"name\":\"Drake Talon Pauldrons\",\"slot\":\"Shoulder\"},{\"id\":23315,\"quantity\":15,\"name\":\"Lieutenant Commander's Plate Shoulders\",\"slot\":\"Shoulder\"},{\"id\":23243,\"quantity\":13,\"name\":\"Champion's Plate Shoulders\",\"slot\":\"Shoulder\"},{\"id\":16544,\"quantity\":9,\"name\":\"Warlord's Plate Shoulders\",\"slot\":\"Shoulder\"},{\"id\":16480,\"quantity\":7,\"name\":\"Field Marshal's Plate Shoulderguards\",\"slot\":\"Shoulder\"},{\"id\":19878,\"quantity\":4,\"name\":\"Bloodsoaked Pauldrons\",\"slot\":\"Shoulder\"},{\"id\":20683,\"quantity\":4,\"name\":\"Abyssal Plate Epaulets\",\"slot\":\"Shoulder\"},{\"id\":12927,\"quantity\":2,\"name\":\"Truestrike Shoulders\",\"slot\":\"Shoulder\"}],\"Chest\":[{\"id\":11726,\"quantity\":77,\"name\":\"Savage Gladiator Chain\",\"slot\":\"Chest\"},{\"id\":16541,\"quantity\":9,\"name\":\"Warlord's Plate Armor\",\"slot\":\"Chest\"},{\"id\":19405,\"quantity\":5,\"name\":\"Malfurion's Blessed Bulwark\",\"slot\":\"Chest\"},{\"id\":22872,\"quantity\":4,\"name\":\"Legionnaire's Plate Hauberk\",\"slot\":\"Chest\"},{\"id\":16477,\"quantity\":3,\"name\":\"Field Marshal's Plate Armor\",\"slot\":\"Chest\"}],\"Waist\":[{\"id\":19137,\"quantity\":93,\"name\":\"Onslaught Girdle\",\"slot\":\"Waist\"},{\"id\":19823,\"quantity\":4,\"name\":\"Zandalar Vindicator's Belt\",\"slot\":\"Waist\"},{\"id\":20216,\"quantity\":1,\"name\":\"Belt of Preserved Heads\",\"slot\":\"Waist\"}],\"Legs\":[{\"id\":19402,\"quantity\":20,\"name\":\"Legguards of the Fallen Crusader\",\"slot\":\"Legs\"},{\"id\":19855,\"quantity\":16,\"name\":\"Bloodsoaked Legplates\",\"slot\":\"Legs\"},{\"id\":16543,\"quantity\":14,\"name\":\"General's Plate Leggings\",\"slot\":\"Legs\"},{\"id\":23301,\"quantity\":12,\"name\":\"Knight-Captain's Plate Leggings\",\"slot\":\"Legs\"},{\"id\":16479,\"quantity\":12,\"name\":\"Marshal's Plate Legguards\",\"slot\":\"Legs\"},{\"id\":22873,\"quantity\":10,\"name\":\"Legionnaire's Plate Leggings\",\"slot\":\"Legs\"},{\"id\":14554,\"quantity\":9,\"name\":\"Cloudkeeper Legplates\",\"slot\":\"Legs\"},{\"id\":20671,\"quantity\":3,\"name\":\"Abyssal Plate Legguards\",\"slot\":\"Legs\"},{\"id\":18380,\"quantity\":1,\"name\":\"Eldritch Reinforced Legplates\",\"slot\":\"Legs\"},{\"id\":16962,\"quantity\":1,\"name\":\"Legplates of Wrath\",\"slot\":\"Legs\"}],\"Feet\":[{\"id\":19387,\"quantity\":53,\"name\":\"Chromatic Boots\",\"slot\":\"Feet\"},{\"id\":16545,\"quantity\":13,\"name\":\"General's Plate Boots\",\"slot\":\"Feet\"},{\"id\":14616,\"quantity\":11,\"name\":\"Bloodmail Boots\",\"slot\":\"Feet\"},{\"id\":16483,\"quantity\":11,\"name\":\"Marshal's Plate Boots\",\"slot\":\"Feet\"},{\"id\":12555,\"quantity\":2,\"name\":\"Battlechaser's Greaves\",\"slot\":\"Feet\"},{\"id\":19381,\"quantity\":2,\"name\":\"Boots of the Shadow Flame\",\"slot\":\"Feet\"},{\"id\":13070,\"quantity\":1,\"name\":\"Sapphiron's Scale Boots\",\"slot\":\"Feet\"},{\"id\":16984,\"quantity\":1,\"name\":\"Black Dragonscale Boots\",\"slot\":\"Feet\"},{\"id\":20048,\"quantity\":1,\"name\":\"Highlander's Plate Greaves\",\"slot\":\"Feet\"},{\"id\":16965,\"quantity\":1,\"name\":\"Sabatons of Wrath\",\"slot\":\"Feet\"},{\"id\":23287,\"quantity\":1,\"name\":\"Knight-Lieutenant's Plate Greaves\",\"slot\":\"Feet\"},{\"id\":13967,\"quantity\":1,\"name\":\"Windreaver Greaves\",\"slot\":\"Feet\"}],\"Wrist\":[{\"id\":19146,\"quantity\":57,\"name\":\"Wristguards of Stability\",\"slot\":\"Wrist\"},{\"id\":19578,\"quantity\":25,\"name\":\"Berserker Bracers\",\"slot\":\"Wrist\"},{\"id\":19824,\"quantity\":15,\"name\":\"Zandalar Vindicator's Armguards\",\"slot\":\"Wrist\"},{\"id\":13400,\"quantity\":1,\"name\":\"Vambraces of the Sadist\",\"slot\":\"Wrist\"}],\"Hand\":[{\"id\":19143,\"quantity\":33,\"name\":\"Flameguard Gauntlets\",\"slot\":\"Hand\"},{\"id\":22714,\"quantity\":25,\"name\":\"Sacrificial Gauntlets\",\"slot\":\"Hand\"},{\"id\":14551,\"quantity\":25,\"name\":\"Edgemaster's Handguards\",\"slot\":\"Hand\"},{\"id\":16548,\"quantity\":11,\"name\":\"General's Plate Gauntlets\",\"slot\":\"Hand\"},{\"id\":16484,\"quantity\":3,\"name\":\"Marshal's Plate Gauntlets\",\"slot\":\"Hand\"},{\"id\":18823,\"quantity\":1,\"name\":\"Aged Core Leather Gloves\",\"slot\":\"Hand\"}],\"Back\":[{\"id\":19436,\"quantity\":35,\"name\":\"Cloak of Draconic Might\",\"slot\":\"Back\"},{\"id\":13340,\"quantity\":23,\"name\":\"Cape of the Black Baron\",\"slot\":\"Back\"},{\"id\":19398,\"quantity\":18,\"name\":\"Cloak of Firemaw\",\"slot\":\"Back\"},{\"id\":15138,\"quantity\":13,\"name\":\"Onyxia Scale Cloak\",\"slot\":\"Back\"},{\"id\":18541,\"quantity\":2,\"name\":\"Puissant Cape\",\"slot\":\"Back\"},{\"id\":20073,\"quantity\":2,\"name\":\"Cloak of the Honor Guard\",\"slot\":\"Back\"},{\"id\":20068,\"quantity\":2,\"name\":\"Deathguard's Cloak\",\"slot\":\"Back\"},{\"id\":13397,\"quantity\":1,\"name\":\"Stoneskin Gargoyle Cape\",\"slot\":\"Back\"},{\"id\":19907,\"quantity\":1,\"name\":\"Zulian Tigerhide Cloak\",\"slot\":\"Back\"},{\"id\":11626,\"quantity\":1,\"name\":\"Blackveil Cape\",\"slot\":\"Back\"}],\"Weapon\":[{\"id\":19352,\"quantity\":26,\"name\":\"Chromatically Tempered Sword\",\"slot\":\"Weapon\"},{\"id\":17068,\"quantity\":26,\"name\":\"Deathbringer\",\"slot\":\"Weapon\"},{\"id\":19363,\"quantity\":10,\"name\":\"Crul'shorukh, Edge of Chaos\",\"slot\":\"Weapon\"},{\"id\":12584,\"quantity\":9,\"name\":\"Grand Marshal's Longsword\",\"slot\":\"Weapon\"},{\"id\":17112,\"quantity\":9,\"name\":\"Empyrean Demolisher\",\"slot\":\"Weapon\"},{\"id\":18828,\"quantity\":8,\"name\":\"High Warlord's Cleaver\",\"slot\":\"Weapon\"},{\"id\":19019,\"quantity\":3,\"name\":\"Thunderfury, Blessed Blade of the Windseeker\",\"slot\":\"Weapon\"},{\"id\":12798,\"quantity\":2,\"name\":\"Annihilator\",\"slot\":\"Weapon\"},{\"id\":19335,\"quantity\":2,\"name\":\"Spineshatter\",\"slot\":\"Weapon\"},{\"id\":18832,\"quantity\":2,\"name\":\"Brutality Blade\",\"slot\":\"Weapon\"},{\"id\":17075,\"quantity\":1,\"name\":\"Vis'kag the Bloodletter\",\"slot\":\"Weapon\"}],\"Offhand\":[{\"id\":18832,\"quantity\":22,\"name\":\"Brutality Blade\",\"slot\":\"Offhand\"},{\"id\":19363,\"quantity\":18,\"name\":\"Crul'shorukh, Edge of Chaos\",\"slot\":\"Offhand\"},{\"id\":19351,\"quantity\":13,\"name\":\"Maladath, Runed Blade of the Black Flight\",\"slot\":\"Offhand\"},{\"id\":23456,\"quantity\":10,\"name\":\"Grand Marshal's Swiftblade\",\"slot\":\"Offhand\"},{\"id\":18828,\"quantity\":9,\"name\":\"High Warlord's Cleaver\",\"slot\":\"Offhand\"},{\"id\":19362,\"quantity\":7,\"name\":\"Doom's Edge\",\"slot\":\"Offhand\"},{\"id\":18805,\"quantity\":4,\"name\":\"Core Hound Tooth\",\"slot\":\"Offhand\"},{\"id\":19103,\"quantity\":4,\"name\":\"Frostbite\",\"slot\":\"Offhand\"},{\"id\":17075,\"quantity\":3,\"name\":\"Vis'kag the Bloodletter\",\"slot\":\"Offhand\"},{\"id\":19921,\"quantity\":2,\"name\":\"Zulian Hacker\",\"slot\":\"Offhand\"},{\"id\":19866,\"quantity\":2,\"name\":\"Warblade of the Hakkari\",\"slot\":\"Offhand\"},{\"id\":19352,\"quantity\":2,\"name\":\"Chromatically Tempered Sword\",\"slot\":\"Offhand\"},{\"id\":17068,\"quantity\":1,\"name\":\"Deathbringer\",\"slot\":\"Offhand\"},{\"id\":17067,\"quantity\":1,\"name\":\"Ancient Cornerstone Grimoire\",\"slot\":\"Offhand\"}],\"Ranged\":[{\"id\":17069,\"quantity\":67,\"name\":\"Striker's Mark\",\"slot\":\"Ranged\"},{\"id\":17072,\"quantity\":15,\"name\":\"Blastershot Launcher\",\"slot\":\"Ranged\"},{\"id\":19853,\"quantity\":11,\"name\":\"Gurubashi Dwarf Destroyer\",\"slot\":\"Ranged\"},{\"id\":19107,\"quantity\":3,\"name\":\"Bloodseeker\",\"slot\":\"Ranged\"},{\"id\":12651,\"quantity\":2,\"name\":\"Blackcrow\",\"slot\":\"Ranged\"}],\"Rings\":[{\"id\":18821,\"quantity\":85,\"name\":\"Quick Strike Ring\",\"slot\":\"RingA\"},{\"id\":19384,\"quantity\":61,\"name\":\"Master Dragonslayer's Ring\",\"slot\":\"RingA\"},{\"id\":19432,\"quantity\":25,\"name\":\"Circle of Applied Force\",\"slot\":\"RingA\"},{\"id\":19325,\"quantity\":25,\"name\":\"Don Julio's Band\",\"slot\":\"RingA\"}],\"Trinkets\":[{\"id\":20130,\"quantity\":67,\"name\":\"Diamond Flask\",\"slot\":\"TrinketA\"},{\"id\":11815,\"quantity\":60,\"name\":\"Hand of Justice\",\"slot\":\"TrinketA\"},{\"id\":19406,\"quantity\":43,\"name\":\"Drake Fang Talisman\",\"slot\":\"TrinketA\"},{\"id\":13965,\"quantity\":25,\"name\":\"Blackhand's Breadth\",\"slot\":\"TrinketA\"},{\"id\":2802,\"quantity\":1,\"name\":\"Blazing Emblem\",\"slot\":\"TrinketB\"}]}"
                ;
        }
        
        [HttpGet("encounter/{encounterId}")]
        public async Task<ActionResult<List<Ranking>>> Get(int encounterId)
        {
            var rankings = await _wclClient.GetRankingsAsync(encounterId);
            if (rankings != null)
                return Ok(rankings);
            return NotFound();
        }

        [HttpGet("encounter/{encounterId}/{classId}/{graphType}")]
        public async Task<ActionResult<Dictionary<string, List<GearCount>>>> Get(int encounterId, int classId,
            string graphType)
        {
            var rankings = await _wclClient.GetRankingsAsync(encounterId, classId);
            Dictionary<string, List<GearCount>> gearRanks = null;
            if (graphType == "gear")
            {
                gearRanks = new Dictionary<string, List<GearCount>>();
                var gear = rankings.Select(s => s.Gear).ToList();
                foreach (Slot slot in Enum.GetValues(typeof(Slot)))
                {
                    if (slot == Slot.Shirt ||
                        slot == Slot.RingA || slot == Slot.RingB ||
                        slot == Slot.TrinketA || slot == Slot.TrinketB) continue;
                    var tmpGearSlot = gear.Select(s => s.ElementAtOrDefault((int) slot)).ToList();
                    var sortedGearSummary = tmpGearSlot.GetGearSummary();
                    gearRanks.Add(slot.ToString(), sortedGearSummary);
                }
                
                var rings = gear.GetGear(Slot.RingA);
                rings.AddRange(gear.GetGear(Slot.RingB));
                gearRanks.Add("Rings", rings.GetGearSummary());

                var trinkets = gear.GetGear(Slot.TrinketA);
                trinkets.AddRange(gear.GetGear(Slot.TrinketB));
                gearRanks.Add("Trinkets", trinkets.GetGearSummary());

                var tmp = 0;
            }


            if (gearRanks != null)
                return Ok(gearRanks);
            return NotFound();
        }

        [HttpGet("encounter/{encounterId}/{classId}")]
        public async Task<ActionResult<List<Ranking>>> Get(int encounterId, int classId)
        {
            var rankings = await _wclClient.GetRankingsAsync(encounterId, classId);
            if (rankings != null)
                return Ok(rankings);
            return NotFound();
        }
    }
}