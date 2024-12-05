namespace Advent2024;

public class PuzzleEight {
    public int StartElvesWorking(List<string> input, string word) {
        var occurrencecount = 0;
        var height = input.Count;
        var width = input[0].Length;
        var crossword = MakeSantasCrossword(input);

        /* Horizontal technically we could just do this "var horizontallines = crosswordlist;" but I want to learn how to change things back and forth*/
        var horizontallines = WriteALetterToSanta(crossword);
        /* Vertical */
        var verticallines = WriteALetterToSanta(SquintTurnThePaperAndLookAtItInAMirror(crossword));
        /* Diagonal top center to left center */
        var diagonallines = GrantSomeWishes(crossword);
        /* Diagonal bottom center to left center */
        var diagonallinesrotated = GrantSomeWishes(SquintAndTurnThePaper(crossword));

        occurrencecount += GoForASleighRide(horizontallines,word);
        occurrencecount += GoForASleighRide(verticallines,word);
        occurrencecount += GoForASleighRide(diagonallines,word);
        occurrencecount += GoForASleighRide(diagonallinesrotated,word);

        return occurrencecount;
    }
    public char[,] MakeSantasCrossword(List<string> input){
        var height = input.Count;
        var width = input[0].Length;
        var crossword = new char[height,width];
        var lineiteration = 0;
        var chariteration = 0;
        while (lineiteration < height) {
            while (chariteration < width) {
                crossword[chariteration,lineiteration] = input[lineiteration][chariteration];
                chariteration++;
            }
            chariteration = 0;
            lineiteration++;
        }
        return crossword;
    }
    public List<string> WriteALetterToSanta(char[,] somewishes) {
        var lettertosanta = new List<string>();
        var line = "";
        for(var y = 0; y < somewishes.GetLength(1); y++) {
            line = "";
            for (var x = 0; x < somewishes.GetLength(0); x++) {
                line += somewishes[x,y];
            }
            lettertosanta.Add(line);
        }
        return lettertosanta;
    }
    public char[,] SquintAndTurnThePaper(char[,] somewishes) {
        var lettertosanta = new char[somewishes.GetLength(1),somewishes.GetLength(0)];
        var newx = somewishes.GetLength(1) - 1;
        var newy = 0;
        for (var oldy = 0; oldy < somewishes.GetLength(0); oldy++) {
            newy = 0;
            for(var oldx = 0; oldx < somewishes.GetLength(1); oldx++) {
                lettertosanta[newx,newy] = somewishes[oldx, oldy];
                newy++;
            }
            newx--;
        }
        return lettertosanta;
    }
    public char[,] SquintTurnThePaperAndLookAtItInAMirror(char[,] somewishes) {
        var lettertosanta = new char[somewishes.GetLength(1),somewishes.GetLength(0)];
        for(var y = 0; y < somewishes.GetLength(1); y++) {
            for (var x = 0; x < somewishes.GetLength(0); x++) {
                lettertosanta[y,x] = somewishes[x,y];
            }
        }
        return lettertosanta;
    }
    public List<string> GrantSomeWishes(char[,] somewishes) {
        var lettertosanta = new List<string>();
        var crawlx = somewishes.GetLength(0);
        var crawly = 0;
        var line = "";
        for (var x = somewishes.GetLength(0); x >= 0; x--) {
            crawlx = x;
            crawly = 0;
            while (crawlx < somewishes.GetLength(0) && crawly < somewishes.GetLength(1)) {
                line += somewishes[crawlx,crawly];
                crawlx++;
                crawly++;
            }
            lettertosanta.Add(line);
            line = "";
        }
        for (var y = 1; y < somewishes.GetLength(1); y++) {
            crawlx = 0;
            crawly = y;
            while (crawlx < somewishes.GetLength(0) && crawly < somewishes.GetLength(1)) {
                line += somewishes[crawlx,crawly];
                crawlx++;
                crawly++;
            }
            lettertosanta.Add(line);
            line = "";
        }
        return lettertosanta;
    }

    public int GoForASleighRide(List<string> presents, string word) {
        var validpresents = presents.Where(present => present.Length > 3).ToList();
        var length = word.Length;
        var presentsdelivered = 0;
        var scaniterator = 0;
        var reverseword = new string(word.Reverse().ToArray());
        foreach (var present in validpresents) {
            scaniterator = 0;
            while (scaniterator < present.Length + 1 - word.Length) {
                if (present.Substring(scaniterator,length).Contains(word) || present.Substring(scaniterator,length).Contains(reverseword)) {
                    presentsdelivered++;
                }
                scaniterator++;
            }
        }
        return presentsdelivered;
    }
}