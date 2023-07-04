using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeModel
{
    public class Hero
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Ability ability { get; set; }
        public DateTime  StartTrain { get; set; }
        public string SuitColor { get; set; } = string.Empty;
        public decimal StartingPower { get; set; } = 0;
        public decimal CurrentPower { get; set; }=0 ;

        public Guid Trainer { get; set; }
    }
    public enum Ability { attacker, defender }
}

