using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using System.Linq;

namespace Quantum.SuperpositionArray
{
    class Driver
    {
        /**
         * Driver method to run the program.
         * This calls the methods in QS file. 
         */
        static void Main(string[] args)
        {
            var simulator = new QuantumSimulator();

            var nElements = 4;
            QArray<bool> A = new QArray<bool>(nElements)
            {
                [0] = false,
                [1] = false,
                [2] = false,
                [3] = true,
            };
        QArray<bool> B = new QArray<bool>(nElements)
        {
            [0] = true,
            [1] = true,
            [2] = true,
            [3] = false,
            };

            foreach (var count in Enumerable.Range(0, 50))
            {
                var res = DoSuperPosTest.Run(simulator, A, B).Result;
                System.Console.WriteLine(res);
            }

            System.Console.ReadKey();

        }
    }
}