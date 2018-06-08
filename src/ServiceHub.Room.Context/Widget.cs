using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceHub.Room.Context
{
    [DataContract]
    public class Widget
    {
        [BsonId]
        [DataMember(Name = "widgetId")]
        [Required]
        public Guid WidgetId { get; set; }
        [DataMember(Name = "widgetGender")]
        public GenderEnum WidgetGender;
    }

    [DataContract(Name ="Gender")]
    public enum GenderEnum
    {
        [EnumMember]
        Male,
        [EnumMember]
        Female,
        [EnumMember]
        Unassigned,
        AttackHelicopter
    }
}
