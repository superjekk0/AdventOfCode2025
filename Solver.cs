using AdventOfCode2025.jour1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025
{
    public abstract class Solver
    {
        protected List<string> _inputLines = new();

        protected abstract void InitializeTraining();
        protected abstract void InitializeRealData();

        public abstract void SolvePart1();
        public abstract void SolvePart2();

        public Solver(bool isTraining)
        {
            if (isTraining)
            {
                InitializeTraining();
            }
            else
            {
                InitializeRealData();
            }
        }

        public static Solver CreateSolver(int day, bool isTraining)
        {
            switch (day)
            {
                case 1:
                    return new Jour1(isTraining);
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
