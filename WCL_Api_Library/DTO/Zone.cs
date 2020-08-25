using System.Collections.Generic;

namespace WCL_Api_Library.DTO
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Frozen { get; set; }
        public ICollection<Encounter> Encounters { get; set; }
        public Brackets Brackets { get; set; }
        public ICollection<Partition> Partitions { get; set; }
    }

    public class Encounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Brackets
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Bucket { get; set; }
        public string Type { get; set; }
    }

    public class Partition
    {
        public string Name { get; set; }
        public string Compact { get; set; }
        public bool? Default { get; set; }
    }
}