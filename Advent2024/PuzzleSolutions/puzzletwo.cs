namespace Advent2024;

public class PuzzleTwo {
    public int StartElvesWorking(List<int> firstlist, List<int> secondlist) {
        var sum = 0;
        var listlength = firstlist.Count;
        var secondListOccurrence = secondlist.GroupBy(i => i);
        var secondListLookup = new Dictionary<int,int>();

        firstlist.Sort();
        secondlist.Sort();

        foreach (var value in secondListOccurrence) {
            secondListLookup.Add(value.Key,value.Count());
        };

        foreach (var value in firstlist) {
            if(secondListLookup.TryGetValue(value, out int count)) {
                sum += value * count;
            }
        }
        return sum;
    }
}