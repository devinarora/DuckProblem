using System;
using System.Collections.Generic;
using System.Text;

namespace DuckProblem
{
    class Rock
    {

        private int x;
        private int y;
        public List<Rock> adjacent;

        public int Get_x()
        {
            return x;
        }

        public int Get_y()
        {
            return y;
        }

        public Rock(int x_val, int y_val, List<Rock> adj)
        {
            x = x_val;
            y = y_val;
            adjacent = adj;
        }
    }
}
