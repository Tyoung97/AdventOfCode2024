using System.IO;
using System.Collections;

namespace Advent2024;

internal class Program {
    static void Main(string[] args) {
        var santasletteropener = new SantasLetterOpener();
        var puzzleone = new PuzzleOne();
        var puzzletwo = new PuzzleTwo();
        var puzzlethree = new PuzzleThree();
        var puzzlefour = new PuzzleFour();
        var puzzlefive = new PuzzleFive();
        var puzzlesix = new PuzzleSix();
        var puzzleseven = new PuzzleSeven();

        /* solve puzzle one and puzzle two*/
        var dayonefirstlist = santasletteropener.BreakSeal("./input/puzzleonelistone.txt", int.Parse);
        var dayonesecondlist = santasletteropener.BreakSeal("./input/puzzleonelisttwo.txt", int.Parse);

        var puzzleoneresult = puzzleone.StartElvesWorking(dayonefirstlist, dayonesecondlist);
        Console.WriteLine("Puzzle One's Answer: "+puzzleoneresult);

        var puzzletworesult = puzzletwo.StartElvesWorking(dayonefirstlist, dayonesecondlist);
        Console.WriteLine("Puzzle Two's Answer: "+puzzletworesult);

        /* solve puzzle three and puzzle four*/
        var daytwolines = santasletteropener.BreakSeal("./input/puzzlethreeandfourinput.csv");

        var puzzlethreeresult = puzzlethree.StartElvesWorking(daytwolines);
        Console.WriteLine("Puzzle Three's Answer: "+puzzlethreeresult);

        var puzzlefourresult = puzzlefour.StartElvesWorking(daytwolines);
        Console.WriteLine("Puzzle Four's Answer: "+puzzlefourresult);

        /* solve puzzle Five and puzzle six*/
        var daythreeinputstring = santasletteropener.BreakSeal("./input/daythreeinput.txt",(completeline, line) => completeline+line);

        var puzzlefiveresult = puzzlefive.StartElvesWorking(daythreeinputstring);
        Console.WriteLine("Puzzle Five's Answer: "+puzzlefiveresult);

        var puzzlesixresult = puzzlesix.StartElvesWorking(daythreeinputstring);
        Console.WriteLine("Puzzle Six's Answer: "+puzzlesixresult);

        /* solve puzzle seven and puzzle eight*/
        var dayfourinput = santasletteropener.BreakSeal("./input/dayfourinput.txt");
        var word = "XMAS";
        var puzzlesevenresult = puzzleseven.StartElvesWorking(dayfourinput.ToList(), word);
        Console.WriteLine("Puzzle Seven's Answer: "+puzzlesevenresult);
    }
}