using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TravellingSalesmanProblem;

namespace TravellingSalesmanProblemTests
{
    class TestsTSP
    {
        [TestFixture]
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public static void testEmptyGraph()
            {

                int[,] graph = {};
                var way = new TSP(0, graph);
                Assert.AreEqual(way.getMinWay(), 0);
            }

            [Test]
            public static void testRegularWay()
            {

                int[,] graph = {
                { 0, 33, 12, 37, 61 },
                { 32, 0, 54, 64, 12 },
                { 80, 32, 0, 72, 17 },
                { 96, 87, 15, 0, 31 },
                { 42, 76, 88, 94, 0 }
            };
                var way = new TSP(5, graph);

                foreach (var item in way.allPermutations)
                {
                    foreach (var n in item)
                    {
                        Console.Write(n + ", ");

                    }
                    Console.WriteLine("");
                }
                Assert.AreEqual(way.getMinWay(), 138);
            }

            [Test]
            public static void testFewCitiesAndShortDestinations()
            {

                int[,] graph = {
                { 0, 7, 12 },
                { 13, 0, 9 },
                { 6, 21, 0 }
            };
                var way = new TSP(3, graph);

                foreach (var item in way.allPermutations)
                {
                    foreach (var n in item)
                    {
                        Console.Write(n + ", ");

                    }
                    Console.WriteLine("");
                }
                Assert.AreEqual(way.getMinWay(), 22);
            }

            [Test]
            public static void testMoreCitiesAndShortDestinations()
            {

                int[,] graph = {
                { 0, 55, 35, 45, 77, 19, 24, 21, 23 },
                { 46, 0, 52, 45, 77, 19, 14, 21, 23 },
                { 36, 12, 0, 45, 77, 39, 34, 24, 28 },
                { 36, 12, 10, 0, 77, 19, 24, 21, 89 },
                { 5, 12, 22, 45, 0, 19, 24, 67, 23 },
                { 23, 12, 10, 45, 77, 0, 24, 21, 23 },
                { 16, 12, 30, 45, 77, 19, 0, 21, 23 },
                { 56, 12, 50, 45, 77, 19, 24, 0, 23 },
                { 36, 12, 60, 45, 77, 19, 24, 21, 0 },
            };
                var way = new TSP(9, graph);
                Assert.AreEqual(way.getMinWay(), 226);
            }

            [Test]
            public static void testFewCitiesAndLongerDestinations()
            {

                int[,] graph = {
                { 0, 55431, 354131, 412413 },
                { 4634134, 0, 522312, 4124214 },
                { 361341, 5326212, 0, 412531 },
                { 464134, 4120, 5412412, 0 }
            };
                var way = new TSP(4, graph);
                Assert.AreEqual(way.getMinWay(), 1300186);
            }

            [Test]
            public static void testMoreCitiesAndLongerDestination()
            {

                int[,] graph = {
                { 0, 55135, 35412, 44215, 77413, 19421, 23414, 25131, 23143 },
                { 4413416, 0, 54132, 431545, 51377, 53119, 51314, 41321, 41323 },
                { 41336, 4112, 0, 441245, 741247, 341249, 341244, 242144, 51351328 },
                { 412436, 412412, 431510, 0, 412477, 43119, 41224, 412421, 4134189 },
                { 413415, 41312, 64322, 73745, 0, 73519, 27354, 73567, 346423 },
                { 643623, 63412, 643610, 634645, 7523527, 0, 542624, 624521, 526223 },
                { 524616, 523512, 46230, 62445, 752317, 531419, 0, 413421, 67423 },
                { 412556, 11312, 31350, 412445, 52477, 52419, 64224, 0, 524523 },
                { 512336, 431412, 12360, 46425, 763437, 53119, 241344, 513221, 0 },
            };
                var way = new TSP(9, graph);
                Assert.AreEqual(way.getMinWay(), 368957);
            }

            [Test]
            public static void testPermutations()
            {

                int[] cities = new int[] { 0, 1, 2 };
                var permutations = TSP.GetAllCombinations(cities);
                var ans = new List<List<int>>(){
                new List<int>(){ 0, 1, 2 },
                new List<int>(){ 0, 2, 1 },
                new List<int>(){ 1, 0, 2 },
                new List<int>(){ 1, 2, 0 },
                new List<int>(){ 2, 0, 1 },
                new List<int>(){ 2, 1, 0 },
            };

                var counter = 0;
                foreach (var item in permutations)
                {
                    if (!item.Equals(ans[counter]))
                    {
                        var itemCounter = 0;
                        foreach (var n in item)
                        {
                            Assert.IsFalse(n != ans[counter][itemCounter]);
                            itemCounter++;
                        }
                    }
                    counter++;
                }
                Assert.Pass();
            }
        }
    }
}