namespace Advent2024;
public class GoFindYourFather {
    public void GiveItToBuddy(int[] arr, int lowindex, int highindex, Dictionary<int,Tuple<List<int>,List<int>>> rules) {
        if (lowindex < highindex) {
            
            /*pivotindex is the location of the partition we are using*/
            int pivotindex = HesAnAngryElf(arr, lowindex, highindex, rules);

            /* after this is called recursively call for the left side
             then recursively call for the right side */
            GiveItToBuddy(arr, lowindex, pivotindex - 1, rules);
            GiveItToBuddy(arr, pivotindex + 1, highindex, rules);
        }
    }
    public void GiveItToBuddy(int[] arr, int lowindex, int highindex) {
        if (lowindex < highindex) {
            
            /*pivotindex is the location of the partition we are using*/
            int pivotindex = HesAnAngryElf(arr, lowindex, highindex);

            /* after this is called recursively call for the left side
             then recursively call for the right side */
            GiveItToBuddy(arr, lowindex, pivotindex - 1);
            GiveItToBuddy(arr, pivotindex + 1, highindex);
        }
    }
   public int HesAnAngryElf(int[] array, int lowindex, int highindex, Dictionary<int,Tuple<List<int>,List<int>>> rules) {
        /* Choose a pivot value in this case the furthest right indexed value*/
        int pivotvalue = array[highindex];
        /* get just before the first index in the array so we can walk it left to right */
        int currentindex = lowindex - 1;

        /* start moving left to right in the array and find the first value that is "smaller" than the farthest right value 
        once we find one we swap their positions until we have moved everything left that should be left of our pivot value
        Not the whole time our pivot value is just sitting at the end so after we exit the loop it is still there*/
        for (var currentsearchindex = lowindex; currentsearchindex <= highindex - 1; currentsearchindex++) {
            /* would usually be something like this: if(array[currentsearchindex] < pivotvalue)
                but we are using custom rules to deterimine what numbers are greater/less than other numbers */
            if(rules[pivotvalue].Item2.Contains(array[currentsearchindex])) {
                currentindex++;
                SonOfANutcracker(array, currentindex, currentsearchindex);
            }
        }
        /* finally move our pivot to be just right of all the elements that should be left of it
         which means every item on the left should be left of the pivot and every item right of it
         should be right of it even if the left and right sides of the pivot are out of order within themselves*/
        SonOfANutcracker(array, currentindex + 1, highindex);
        return currentindex + 1;
    }
   public int HesAnAngryElf(int[] array, int lowindex, int highindex) {
        /* Choose a pivot value in this case the furthest right indexed value*/
        int pivotvalue = array[highindex];
        /* get just before the first index in the array so we can walk it left to right */
        int currentindex = lowindex - 1;

        /* start moving left to right in the array and find the first value that is "smaller" than the farthest right value 
        once we find one we swap their positions until we have moved everything left that should be left of our pivot value
        Not the whole time our pivot value is just sitting at the end so after we exit the loop it is still there*/
        for (var currentsearchindex = lowindex; currentsearchindex <= highindex - 1; currentsearchindex++) {
            if(array[currentsearchindex] < pivotvalue) {
                currentindex++;
                SonOfANutcracker(array, currentindex, currentsearchindex);
            }
        }
        /* finally move our pivot to be just right of all the elements that should be left of it
         which means every item on the left should be left of the pivot and every item right of it
         should be right of it even if the left and right sides of the pivot are out of order within themselves*/
        SonOfANutcracker(array, currentindex + 1, highindex);
        return currentindex + 1;
    }
    public void SonOfANutcracker(int[] array, int indexone, int indextwo) {
        /* Swap the positions of the items at the two input indexes.
        the tuple assignment here is the same as setting a to b and b to a */
        (array[indexone],array[indextwo]) = (array[indextwo],array[indexone]);
    }
}