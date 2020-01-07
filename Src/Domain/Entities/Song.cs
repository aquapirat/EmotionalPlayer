using System;
using Player.Domain.Common;

namespace Player.Domain.Entities
{
    public class Song : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? Length { get; set; }
        public string BlobReference { get; set; }
    }
}
