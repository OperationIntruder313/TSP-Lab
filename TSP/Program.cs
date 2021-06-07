using System;
using System.Collections.Generic;

namespace TravellingSalesmanProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] distMatrix = {
                { 0, 33, 12, 37, 61 },
                { 32, 0, 54, 64, 12 },
                { 80, 32, 0, 72, 17 },
                { 96, 87, 15, 0, 31 },
                { 42, 76, 88, 94, 0 }
            };
            var salesman = new TSP(5, distMatrix);

            Console.WriteLine(salesman.getCityCount());
            Console.WriteLine(salesman.getMinWay());
        }
    }

    public class TSP
    {
        private int[,] distMatrix;

        private int[] cities;

        public List<List<int>> allPermutations;

        private int start;

        public TSP(int countCity, int[,] distMatrix, int start = -1)
        {
            if (start != -1 && countCity < start || start != -1 && start < 0)
            {
                throw new Exception("Incorrect start!");
            }

            this.distMatrix = (int[,])distMatrix.Clone();
            var cities = new int[countCity];

            for (int i = 0; i < cities.Length; i++)
            {
                cities[i] = i;
            }

            this.cities = cities;
            allPermutations = GetAllCombinations(cities);
            this.start = start;

            if (distMatrix.Length != countCity * countCity)
            {
                throw new Exception("Count cities or graph incorrect!");
            }
                
        }

        public int getMinWay()
        {
            var minWay = int.MaxValue;

            foreach(var permutation in allPermutations)
            {
                if (start != -1 && permutation[0] != start) continue;

                var tempWay = 0;

                for (int i = 0; i < permutation.Count; i++)
                {
                    if(i + 1 == permutation.Count)
                    {
                        tempWay += distMatrix[permutation[0], permutation[i]];
                        continue;
                    }
                    tempWay += distMatrix[permutation[i + 1], permutation[i]];
                }
                if (tempWay < minWay)
                {
                    minWay = tempWay;
                }
            }

            if(minWay == int.MaxValue)
            {
                throw new Exception("Incorrect start!");
            }

            return minWay;
        }

        public static List<List<T>> GetAllCombinations<T>(IList<T> arr, List<List<T>> list = null, List<T> current = null)
        {
            if (list == null)
            {
                list = new List<List<T>>();
            }

            if (current == null)
            {
                current = new List<T>();
            }

            if (arr.Count == 0)
            {
                list.Add(current);
                return list;
            }

            for (int i = 0; i < arr.Count; i++)
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                var newlst = new List<T>(current);
                newlst.Add(arr[i]);
                GetAllCombinations(lst, list, newlst);
            }

            return list;
        }

        public int getCityCount()
        {
            return cities.Length;
        }
    }
}

