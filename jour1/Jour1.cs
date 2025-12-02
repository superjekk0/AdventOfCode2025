using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.jour1
{
    internal class Jour1 : Solver
    {
        public Jour1(bool isTraining) : base(isTraining)
        {
        }

        public override void SolvePart1()
        {
            int position = 50;
            int nbZeros = 0;

            foreach (string ligne in _inputLines)
            {
                char direction = ligne[0];
                int nbDeplacement = int.Parse(ligne.Substring(1));
                if (direction == 'L')
                {
                    position -= nbDeplacement;
                }
                else if (direction == 'R')
                {
                    position += nbDeplacement;
                }

                position = ModuloPositif(position);
                if (position == 0)
                {
                    ++nbZeros;
                }
            }

            Console.WriteLine("Nb de 0: {0}", nbZeros);
        }

        private int ModuloPositif(int anciennePosition)
        {
            int nouvellePosition = anciennePosition % 100;
            if (nouvellePosition < 0)
            {
                nouvellePosition += 100;
            }

            return nouvellePosition;
        }

        public override void SolvePart2()
        {
            int position = 50;
            int nbPassageAutourZero = 0;

            foreach (string ligne in _inputLines)
            {
                char direction = ligne[0];
                int nbDeplacement = int.Parse(ligne.Substring(1));
                if (direction == 'L')
                {
                    position -= nbDeplacement;
                }
                else if (direction == 'R')
                {
                    position += nbDeplacement;
                }

                int nouvellePosition = ModuloPositif(position);
                if (position != nouvellePosition)
                {
                    nbPassageAutourZero += Math.Abs(position / 100);
                }

                position = nouvellePosition;
            }

            Console.WriteLine("Nb de passage à 0: {0}", nbPassageAutourZero);
        }

        protected override void InitializeRealData()
        {
            using StreamReader stream = new("jour1/donneesJour1.txt");

            while (! stream.EndOfStream)
            {
                _inputLines.Add(stream.ReadLine());
            }
        }

        protected override void InitializeTraining()
        {
            _inputLines = new List<string>
            {
                "L68",
                "L30",
                "R48",
                "L5",
                "R60",
                "L55",
                "L1",
                "L99",
                "R14",
                "L82"
            };
        }
    }
}
