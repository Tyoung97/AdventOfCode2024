namespace Advent2024;

public class PuzzleFive {
    public int StartElvesWorking(string input) {
        var santasreadingglasses = new SantasReadingGlasses();
        var pairstomultiply = santasreadingglasses.Squint(input);
        var sum = pairstomultiply.Sum(tuple => tuple.Item1 * tuple.Item2);
        return sum;
    }
}