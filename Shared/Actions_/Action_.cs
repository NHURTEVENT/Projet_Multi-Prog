﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Action_ : IAction
    {

        public string Name { get; set; }
        public int Duration { get; set; }
        public int ID { get; set; }
        public IUstensil Ustensil { get; set; }

        public Action_(string Name, int Duration, IUstensil ustensil = null)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.Ustensil = ustensil;
        }

    }
}
