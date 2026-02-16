using System.ComponentModel.DataAnnotations;

namespace ActionHistoryApp.Client.Models
{
    public class ActionItem
    {
        public int Id { get; set; }
        public string DataBaseName { get; set; } = string.Empty;
        public string WhoDid { get; set; } = string.Empty;
        public string WhatDid { get; set; } = string.Empty;
        public DateTime WhenDid { get; set; }
    }
}
