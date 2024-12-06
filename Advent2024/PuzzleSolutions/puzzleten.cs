namespace Advent2024;

public class PuzzleTen {
    public int StartElvesWorking(List<int[]> inputtosearch, List<Tuple<int,int>> inputrules) {
        var naughtynicetotal = 0;

        var naughtyandnice = BuildNaughtyOrNiceList(inputrules);
        var naughtytonice = SortPeopleFromNaughtyToNice(inputtosearch,naughtyandnice);
        naughtynicetotal = CheckItTwice(naughtytonice);

        return naughtynicetotal;
    }
    public Dictionary<int,Tuple<List<int>,List<int>>> BuildNaughtyOrNiceList(List<Tuple<int,int>> inputrules) {
        var naughtyandnice = new Dictionary<int, Tuple<List<int>, List<int>>>();
        var allthethings = inputrules.Select(rule => rule.Item1).Distinct().ToList().Union(inputrules.Select(rule => rule.Item2).Distinct().ToList());
        var betterthan = new List<int>();
        var worsethan = new List<int>();

        foreach(var thing in allthethings) {
            betterthan = inputrules.Where(tuple => tuple.Item1 == thing).Select(tuple => tuple.Item2).ToList();
            worsethan = inputrules.Where(tuple => tuple.Item2 == thing).Select(tuple => tuple.Item1).ToList();
            naughtyandnice.Add(thing, new Tuple<List<int>, List<int>>(betterthan,worsethan));
        }

        return naughtyandnice;
    }
    public List<int[]> SortPeopleFromNaughtyToNice (List<int[]> inputtosearch, Dictionary<int,Tuple<List<int>,List<int>>> naughtyandnice) {
            var sorting = inputtosearch.Select(value => (int[])value.Clone()).ToList();
            var naughtytonice = new List<int[]>();
            var interation = 0;

            foreach(var array in sorting) {
                var length = array.Length;
                QuickSort(array, 0, length-1, naughtyandnice);
                if(!array.SequenceEqual(inputtosearch[interation])) {
                    naughtytonice.Add(array);
                }
                interation++;
            }

            return naughtytonice;
    }
    public int CheckItTwice(List<int[]> naughtytonice) {
        var totalnaughtyofnice = 0;

        totalnaughtyofnice = naughtytonice.Select(value => value[value.Length/2]).Sum();

        return totalnaughtyofnice;
    }
    // Partition function
    static int Partition(int[] array, int lowindex, int highindex, Dictionary<int,Tuple<List<int>,List<int>>> rules) {
        // Choose the pivot
        int pivotvalue = array[highindex];
        // Index of smaller element and indicates 
        // the right position of pivot found so far
        int currentindex = lowindex - 1;

        // Traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to 
        // currentindex are smaller after every iteration
        for (int currentsearchindex = lowindex; currentsearchindex <= highindex - 1; currentsearchindex++) {
            // if (array[currentsearchindex] < pivotvalue)
            if(rules[pivotvalue].Item2.Contains(array[currentsearchindex])) {
                currentindex++;
                Swap(array, currentindex, currentsearchindex);
            }
        }
        // Move pivot after smaller elements and
        // return its position
        Swap(array, currentindex + 1, highindex);
        return currentindex + 1;
    }

    // Swap function
    static void Swap(int[] arr, int indexone, int indextwo) {
        //swap the positions of the items at these indexes.
        //the tuple assignment here is the same as setting a to b and b to a
        (arr[indexone],arr[indextwo]) = (arr[indextwo],arr[indexone]);
    }

    // The QuickSort function implementation
    static void QuickSort(int[] arr, int lowindex, int highindex, Dictionary<int,Tuple<List<int>,List<int>>> rules) {
        if (lowindex < highindex) {
            
            // pi is the partition return index of pivot
            int partitionindex = Partition(arr, lowindex, highindex, rules);

            // Recursion calls for smaller elements
            // and greater or equals elements
            QuickSort(arr, lowindex, partitionindex - 1, rules);
            QuickSort(arr, partitionindex + 1, highindex, rules);
        }
    }
}