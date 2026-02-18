using System.ComponentModel.DataAnnotations;

namespace ActionHistoryApp.Shared
{
    public class ActionItemDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Выбирите название базы")]
        public string DataBaseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Выбирите имя исполнителя")]
        public string WhoDid { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите описание")]
        public string WhatDid { get; set; } = string.Empty;
        public DateTime WhenDid { get; set; }
    }
}
