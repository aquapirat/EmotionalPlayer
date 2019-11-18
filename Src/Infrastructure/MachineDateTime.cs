using System;
using Player.Common;

namespace Player.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
