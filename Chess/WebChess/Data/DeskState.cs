using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebChess.Models;

namespace WebChess.Data
{
    public class DeskState
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string UserMove { get; set; }
        public string Step { get; set; }
        public string Desk { get; set; }

        public int ChessPartyId { get; set; }
        public ChessParty ChessParty { get; set; }
        [NotMapped]
        public ChessDesk ChessDesk 
        {
            get=>System.Text.Json.JsonSerializer.Deserialize<ChessDesk>(Desk);
            set=>Desk = System.Text.Json.JsonSerializer.Serialize(value);
        }

    }
}
