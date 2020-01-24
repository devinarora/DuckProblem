using System;
using System.Collections.Generic;
using System.Text;

namespace DuckProblem
{
    class Duck
    {
        private readonly Random rand;
        public Rock rock;

        public Duck(Rock r)
        {
            rock = r;
            rand = new Random();
        }

        public void Move()
        {
            int index = rand.Next(rock.adjacent.Count);
            rock = rock.adjacent[index];
        }

    }
}
