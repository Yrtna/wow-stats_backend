using System.Collections.Generic;

namespace Stats_Repository.DTO
{
    public class Talent
    {
        public string Name { get; set; }
        public int? Id { get; set; }
        public string Icon { get; set; }
    }

    public class Gear
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public int? Id { get; set; }
        public string Icon { get; set; }
        public string ItemLevel { get; set; }
        public string PermanentEnchant { get; set; }
        public string TemporaryEnchant { get; set; }
        public string OnUseEnchant { get; set; }
        public List<object> BonusIDs { get; set; }
        public List<object> Gems { get; set; }
        public Slot? Slot { get; set; }
    }

    public class WorldBuff
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Icon { get; set; }
    }

    public class Ranking
    {
        public string Name { get; set; }
        public int Class { get; set; }
        public int Spec { get; set; }
        public double Total { get; set; }
        public int Duration { get; set; }
        public object StartTime { get; set; }
        public int FightId { get; set; }
        public string ReportId { get; set; }
        public string GuildName { get; set; }
        public string ServerName { get; set; }
        public string RegionName { get; set; }
        public bool Hidden { get; set; }
        public int ItemLevel { get; set; }
        public int Exploit { get; set; }
        public List<Talent> Talents { get; set; }
        public List<Gear> Gear { get; set; }
        public List<WorldBuff> WorldBuffs { get; set; }
        public int Size { get; set; }
    }

    public enum Slot
    {
        Head = 0,
        Neck = 1,
        Shoulder = 2,
        Shirt = 3,
        Chest = 4,
        Waist = 5,
        Legs = 6,
        Feet = 7,
        Wrist = 8,
        Hand = 9,
        RingA = 10,
        RingB = 11,
        TrinketA = 12,
        TrinketB = 13,
        Back = 14,
        Weapon = 15,
        Offhand = 16,
        Ranged = 17
    }

    public class RootRanking
    {
        public int Page { get; set; }
        public bool HasMorePages { get; set; }
        public int Count { get; set; }
        public List<Ranking> Rankings { get; set; }
    }
}