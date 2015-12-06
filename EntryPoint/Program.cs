using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var fullscreen = false;
        read_input:
            switch (Microsoft.VisualBasic.Interaction.InputBox("Which assignment shall run next? (1, 2, 3, 4, or q for quit)", "Choose assignment", VirtualCity.GetInitialValue()))
            {
                case "1":
                    using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance, fullscreen))
                        game.Run();
                    break;
                case "2":
                    using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse, fullscreen))
                        game.Run();
                    break;
                case "3":
                    using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
                        game.Run();
                    break;
                case "4":
                    using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
                        game.Run();
                    break;
                case "q":
                    return;
            }
            goto read_input;
        }

        private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
        {
            //return specialBuildings.OrderBy(v => Vector2.Distance(v, house));

            int length = specialBuildings.Count();
            Vector2[] unorderedArray = specialBuildings.ToArray();

            /*orderedArray = */
            MergeSort(unorderedArray, 0, length - 1, house);
            return (IEnumerable<Vector2>) unorderedArray;
            // returning unordered array?
        }

        private static void MergeSort(Vector2[] UnsortedArray, int left, int right, Vector2 house)
        {
            int mid;

            if (left < right)
            {
                mid = (right + left) / 2;
                MergeSort(UnsortedArray, left, mid, house);
                MergeSort(UnsortedArray, mid + 1, right, house);

                Merge(UnsortedArray, left, mid, right, house);
            }
            //return tempArray;
        }

        private static void Merge(Vector2[] UnsortedArray, int left, int mid, int right, Vector2 house)
        {
            Vector2[] tempArray = new Vector2[right - left + 1];
            int tempPosition = 0;
            int startOfRightSide = mid + 1;
            int initialLeft = left;

            while (tempPosition < tempArray.Count())
            {
                if (DistanceBetween(house, UnsortedArray[left]) < DistanceBetween(house, UnsortedArray[startOfRightSide]))
                {
                    tempArray[tempPosition] = UnsortedArray[left];
                    tempPosition++;
                    if (left < mid)
                        left++;
                    else
                        for (int s = startOfRightSide; s <= right; s++)
                        {
                            tempArray[tempPosition] = UnsortedArray[s];
                            tempPosition++;
                        }
                }
                else
                {
                    tempArray[tempPosition] = UnsortedArray[startOfRightSide];
                    tempPosition++;
                    if (startOfRightSide < right)
                        startOfRightSide++;
                    else
                        for (int l = left; l <= mid; l++)
                        {
                            tempArray[tempPosition] = UnsortedArray[l];
                            tempPosition++;
                        }
                }
            }

            for (int i = 0; i < tempArray.Count(); i++)
            {
                UnsortedArray[initialLeft] = tempArray[i];
                initialLeft++;
            }
        }

        private static float DistanceBetween(Vector2 house, Vector2 specialBuilding)
        {
            return (float)Math.Sqrt(Math.Pow(house.X - specialBuilding.X, 2) + Math.Pow(house.Y - specialBuilding.Y, 2));
        }

        private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(
          IEnumerable<Vector2> specialBuildings,
          IEnumerable<Tuple<Vector2, float>> housesAndDistances)
        {
            return
                from h in housesAndDistances
                select
                  from s in specialBuildings
                  where Vector2.Distance(h.Item1, s) <= h.Item2
                  select s;
        }

        private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding,
          Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
            List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
            var prevRoad = startingRoad;
            for (int i = 0; i < 30; i++)
            {
                prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, destinationBuilding)).First());
                fakeBestPath.Add(prevRoad);
            }
            return fakeBestPath;
        }

        private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding,
          IEnumerable<Vector2> destinationBuildings, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
            foreach (var d in destinationBuildings)
            {
                var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
                List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
                var prevRoad = startingRoad;
                for (int i = 0; i < 30; i++)
                {
                    prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
                    fakeBestPath.Add(prevRoad);
                }
                result.Add(fakeBestPath);
            }
            return result;
        }
    }
#endif
}
