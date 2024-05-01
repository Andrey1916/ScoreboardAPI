using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreboardAPI.Models
{
    public class Players
    {
        public int PlayerId { get; set; } 
        public string PlayerName { get; set; }
        //public int TeamId { get; set; }// Пока не добавлять возможность добавить игрока в команду 
    }
}

