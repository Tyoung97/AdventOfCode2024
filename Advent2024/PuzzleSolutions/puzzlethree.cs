namespace Advent2024;

public class PuzzleThree {
    public int StartElvesWorking(IEnumerable<string> lines) {

        var safelines = 0;

        foreach (var line in lines) {

            var values = line.Split(",").Select(int.Parse).ToList();
            var safe = true;
            var increasing = false;
            var decreasing = false;
            var stagnant = false;
            var notinrange = false;
            var length = values.Count()-1;
            var iteration = 0;

            while (iteration < length) {
                var delta = values[iteration] - values[iteration+1];
                increasing = increasing || delta > 0;
                decreasing = decreasing || delta < 0;
                stagnant = stagnant || delta == 0;
                notinrange = notinrange || delta < -3 || delta > 3;
                iteration++;
            }

            safe = !notinrange && ((increasing && !decreasing) || (!increasing && decreasing)) && !stagnant;
            if (safe) {
                safelines++;
            }

        }

        return safelines;
    }
}