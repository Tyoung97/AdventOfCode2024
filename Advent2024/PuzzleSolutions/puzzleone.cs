using System.Collections.Generic;

namespace Advent2024;
public class PuzzleOne {
    public int StartElvesWorking(List<int> firstlist, List<int> secondlist) {
        var iteration = 0;
        var sum = 0;
        var listlength = firstlist.Count;
        firstlist.Sort();
        secondlist.Sort();
        while (iteration < listlength){
            sum += Math.Abs(firstlist[iteration] - secondlist[iteration]);
            iteration++;
        }
        return sum;
    }
}