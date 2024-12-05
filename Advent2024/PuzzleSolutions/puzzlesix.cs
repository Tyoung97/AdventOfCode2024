namespace Advent2024;

public class PuzzleSix {
    public int StartElvesWorking(string input) {
        var santasreadingglasses = new SantasReadingGlasses();
        var pairstomultiply = santasreadingglasses.Squint(input, 1);
        var sum = pairstomultiply.Where(arr => arr[0] == 1).Sum(arr => arr[1] * arr[2]);
        return sum;
    }
}