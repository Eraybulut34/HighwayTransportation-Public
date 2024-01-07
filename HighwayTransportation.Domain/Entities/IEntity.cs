using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HighwayTransportation.Domain.Entities
{
    public class AppSettings
    {
        public string? Secret { get; set; }

        public string? TopSecret { get; set; }
    }
    public class DbResponse<TEntity>
    {
        public DbResponse()
        {
            this.Data = new List<TEntity>();
        }
        public List<TEntity> Data { get; set; }
        public long Count { get; set; } = 0;
        public decimal Sum { get; set; }
    }
    public class IEntity : IEntity<StatusTypeEnum>
    {
        public IEntity()
        {
            Status=StatusTypeEnum.Active;
        }
    }

    public class IEntity<T> where T : Enum
    {
        [NotMapped]
        [JsonIgnore]
        public bool WithCache { get; set; } = false;
        [Key]
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = new DateTime();
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int? DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; } = new DateTime();
        public bool NoneDeleted { get; set; } = false;
        public T? Status { get; set; }
        public string? ExternalCode { get; set; }
    }

}