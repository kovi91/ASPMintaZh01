using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Models
{
    public class FightViewModel
    {
        public SuperHeroModel Player { get; set; }
        public SuperHeroModel Computer { get; set; }

        public string Winner { get; set; }

    }
}
