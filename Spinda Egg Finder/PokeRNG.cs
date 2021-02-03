using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spinda_Egg_Finder
{
    internal class PokeRNG
    {
        public uint seed;

        public PokeRNG(uint seed)
        {
            this.seed = seed;
        }

        public uint nextUInt()
        {
            seed = seed * 0x41c64e6d + 0x6073;
            return seed;
        }
        public uint nextUShort()
        {
            return nextUInt() >> 16;
        }
    }
}
