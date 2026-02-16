using System;
using System.Collections.Generic;
using System.Text;

namespace ActionHistoryApp.Shared
{
    public class ActionItemDto
    {
        public int Id { get; set; }
        public string DataBaseName { get; set; } = string.Empty;
        public string WhoDid { get; set; } = string.Empty;
        public string WhatDid { get; set; } = string.Empty;
        public DateTime WhenDid { get; set; }
    }
}
