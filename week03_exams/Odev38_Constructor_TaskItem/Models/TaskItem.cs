using System;

namespace Odev38_Constructor_TaskItem.Models
{
    public class TaskItem
    {
        // Auto-property'ler
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // 1. Constructor: Başlık, Atanan Kişi ve Son Tarih zorunlu. Öncelik varsayılan "Normal"
        public TaskItem(string title, string assignedTo, DateTime dueDate)
        {
            Title = title;
            AssignedTo = assignedTo;
            DueDate = dueDate;
            Priority = "Normal"; // Varsayılan öncelik
        }

        // 2. Constructor Overloading: Tüm parametreler (Öncelik dahil) birlikte alınır
        public TaskItem(string title, string assignedTo, DateTime dueDate, string priority)
        {
            Title = title;
            AssignedTo = assignedTo;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}