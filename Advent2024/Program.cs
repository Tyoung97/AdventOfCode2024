﻿using System.IO;
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
        var puzzleeight = new PuzzleEight();
        var puzzlenine = new PuzzleNine();
        var puzzleten = new PuzzleTen();
        var puzzleeleven = new PuzzleEleven();
        var puzzletwelve = new PuzzleTwelve();
        var puzzlethirteen = new PuzzleThirteen();
        var puzzlefourteen = new PuzzleFourteen();
        var puzzlefiteen = new PuzzleFifteen();
        var puzzlesixteen = new PuzzleSixteen();
        var puzzleseventeen = new PuzzleSeventeen();
        // var puzzlesixteen = new PuzzleEighteen();

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

        var puzzleeightresult = puzzleeight.StartElvesWorking(dayfourinput.ToList(), word);
        Console.WriteLine("Puzzle Eight's Answer: "+puzzleeightresult);

        /* solve puzzle nine and puzzle ten*/
        var dayfiveinputvalues = santasletteropener.BreakSeal("./input/dayfiveinputvalues.txt",line => line.Split(',').Select(int.Parse).ToArray());
        var dayfiveinputrules = santasletteropener.BreakSeal("./input/dayfiveinputrules.txt",line => line.Split('|') switch {var a => new Tuple<int,int>(int.Parse(a[0]), int.Parse(a[1]))});

        var puzzlenineresult = puzzlenine.StartElvesWorking(dayfiveinputvalues, dayfiveinputrules);
        Console.WriteLine("Puzzle Nine's Answer: "+puzzlenineresult);
        var puzzletenresult = puzzleten.StartElvesWorking(dayfiveinputvalues, dayfiveinputrules);
        Console.WriteLine("Puzzle Ten's Answer: "+puzzletenresult);

        /* solve puzzle eleven and puzzle twelve*/
        var daysixinputvalues = santasletteropener.BreakSeal("./input/daysixinput.txt",0);
        var puzzleelevenresult = puzzleeleven.StartElvesWorking(daysixinputvalues,'^','#');
        Console.WriteLine("Puzzle Eleven's Answer: "+puzzleelevenresult);
        //Commented cause it needs a rewrite cause it's soooo FUCKING SLOW takes like 5 minutes to run
        // var puzzletwelveresult = puzzletwelve.StartElvesWorking(daysixinputvalues,'^','#');
        // Console.WriteLine("Puzzle Twelve's Answer: "+puzzletwelveresult);

        /* solve puzzle thirteen and puzzle fourteen*/
        var dayseveninputvalues = santasletteropener.BreakSeal("./input/dayseveninput.txt",':',' ');
        var puzzlethirteenresult = puzzlethirteen.StartElvesWorking(dayseveninputvalues);
        Console.WriteLine("Puzzle Thirteen's Answer: "+puzzlethirteenresult);
        //Commented cause it takes like 5 seconds run
        // var puzzlefourteenresult = puzzlefourteen.StartElvesWorking(dayseveninputvalues);
        // Console.WriteLine("Puzzle Fourteen's Answer: "+puzzlefourteenresult);

        /* solve puzzle fifteen and puzzle sixteen*/
        var dayeightinputvalues = santasletteropener.FileTo2dCharArray("./input/dayeightinput.txt");
        var puzzlefifteenresult = puzzlefiteen.StartElvesWorking(dayeightinputvalues);
        Console.WriteLine("Puzzle fifteen's Answer: "+puzzlefifteenresult);
        //since we are mutating/changing values in the input set it back to its base
        dayeightinputvalues = santasletteropener.FileTo2dCharArray("./input/dayeightinput.txt");
        var puzzlsixteenresult = puzzlesixteen.StartElvesWorking(dayeightinputvalues);
        Console.WriteLine("Puzzle sixteen's Answer: "+puzzlsixteenresult);

        /* solve puzzle fifteen and puzzle sixteen*/
        var daynineinputvalues = santasletteropener.ReadinStringToCharArray("./input/dayninetestinput.txt");
        var puzzleseventeenresult = puzzleseventeen.StartElvesWorking(daynineinputvalues);
        Console.WriteLine("Puzzle fifteen's Answer: "+puzzleseventeenresult);
    }
}