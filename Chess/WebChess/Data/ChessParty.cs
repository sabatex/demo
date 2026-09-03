using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Data
{
    public class ChessParty
    {
        public int Id { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string WhiteUser { get; set; }
        public DateTime StartDate { get; set; }
        public int? LastParty { get; set; }

    }
}
