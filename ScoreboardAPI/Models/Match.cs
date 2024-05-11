using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreboardAPI.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public int SportId { get; set; }
        public DateTime Date { get; set; }
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
    }
}
