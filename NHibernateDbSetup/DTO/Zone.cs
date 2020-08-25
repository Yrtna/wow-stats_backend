using System.Collections.Generic;
using System.Linq;

namespace NHibernateDbSetup.DTO
{
    public static partial class DTOExtensions
    {
        public static Zone ToNZone(this WCL_Api_Library.DTO.Zone zone)
        {
            var newZone = new Zone
            {
                Brackets = new Brackets
                {
                    Bucket = zone.Brackets.Bucket,
                    Max = zone.Brackets.Max,
                    Min = zone.Brackets.Min,
                    Type = zone.Brackets.Type
                },
                Frozen = zone.Frozen,
                ZoneId = zone.Id,
                Name = zone.Name
            };
            newZone.Encounters = zone.Encounters.ToNEncounter(newZone);
            newZone.Partitions = zone.Partitions.ToNPartition(newZone);
        
            
            return newZone;
        }
        
        public static ICollection<Encounter> ToNEncounter(this ICollection<WCL_Api_Library.DTO.Encounter> encounters,
            Zone zone)
        {
            return encounters.Select(s => new Encounter {EncounterId = s.Id, Name = s.Name, Zone = zone}).ToList();
        }
        
        public static ICollection<Partition> ToNPartition(this ICollection<WCL_Api_Library.DTO.Partition> partitions,
            Zone zone)
        {
            return partitions.Select(s => new Partition {Name = s.Name, Compact = s.Compact, Zone = zone}).ToList();
        }
        // public static Zone ToNZone(this WCL_Api_Library.DTO.Zone zone)
        // {
        //     return new Zone
        //     {
        //         Brackets = new Brackets
        //         {
        //             Bucket = zone.Brackets.Bucket,
        //             Max = zone.Brackets.Max,
        //             Min = zone.Brackets.Min,
        //             Type = zone.Brackets.Type
        //         },
        //         Frozen = zone.Frozen,
        //         ZoneId = zone.Id,
        //         Name = zone.Name,
        //         Encounters = zone.Encounters.ToNEncounter(),
        //         Partitions = zone.Partitions.ToNPartition()
        //     };
        // }
        //
        // public static ICollection<Encounter> ToNEncounter(this ICollection<WCL_Api_Library.DTO.Encounter> encounters)
        // {
        //     return encounters.Select(s => new Encounter {Id = s.Id, Name = s.Name}).ToList();
        // }
        // public static ICollection<Partition> ToNPartition(this ICollection<WCL_Api_Library.DTO.Partition> partitions)
        // {
        //     return partitions.Select(s => new Partition {Name = s.Name,Compact = s.Compact}).ToList();
        // }
        //

        public static Stats_Repository.DTO.Zone ToZone(this WCL_Api_Library.DTO.Zone zone)
        {
            var newZone = new Stats_Repository.DTO.Zone
            {
                Brackets = new Stats_Repository.DTO.Brackets
                {
                    Bucket = zone.Brackets.Bucket,
                    Max = zone.Brackets.Max,
                    Min = zone.Brackets.Min,
                    Type = zone.Brackets.Type
                },
                Frozen = zone.Frozen,
                ZoneId = zone.Id,
                Name = zone.Name
            };
            newZone.Encounters = zone.Encounters.ToNEncounter(newZone);
            newZone.Partitions = zone.Partitions.ToNPartition(newZone);
        
            
            return newZone;
        }
        
        public static ICollection<Stats_Repository.DTO.Encounter> ToNEncounter(this ICollection<WCL_Api_Library.DTO.Encounter> encounters,
            Stats_Repository.DTO.Zone zone)
        {
            return encounters.Select(s => new Stats_Repository.DTO.Encounter {EncounterId = s.Id, Name = s.Name, Zone = zone}).ToList();
        }
        
        public static ICollection<Stats_Repository.DTO.Partition> ToNPartition(this ICollection<WCL_Api_Library.DTO.Partition> partitions,
            Stats_Repository.DTO.Zone zone)
        {
            return partitions.Select(s => new Stats_Repository.DTO.Partition {Name = s.Name, Compact = s.Compact, Zone = zone}).ToList();
        }

    }


    public class Zone
    {
        public virtual int Id { get; set; }
        public virtual int ZoneId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Frozen { get; set; }
        public virtual ICollection<Encounter> Encounters { get; set; }
        public virtual Brackets Brackets { get; set; }
        public virtual ICollection<Partition> Partitions { get; set; }
    }

    public class Encounter
    {
        public virtual int Id { get; set; }
        public virtual int EncounterId { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual string Name { get; set; }
    }

    public class Brackets
    {
        public virtual int Min { get; set; }
        public virtual int Max { get; set; }
        public virtual int Bucket { get; set; }
        public virtual string Type { get; set; }
    }

    public class Partition
    {
        public virtual int Id { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual string Name { get; set; }
        public virtual string Compact { get; set; }
    }
}