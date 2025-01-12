namespace Advent2024;

public class PuzzleEight {
    public int StartElvesWorking(List<string> input, string word) {
        var occurrencecount = 0;
        var crossword = MakeSantasCrossword(input);
        occurrencecount = VisitEveryHouseInOneNight(crossword);
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
    public int VisitEveryHouseInOneNight(char[,] input) {
        // var height = input.GetLength(1);
        // var width = input.GetLength(0);
        var innerheight = input.GetLength(1)-1;
        var innerwidth = input.GetLength(0)-1;
        var xmascount = 0;
        var leftsum = 0;//but not a checksum
        var rightsum = 0;
        for (var x = 1; x < innerwidth; x++) {
            for(var y = 1; y < innerheight; y++) {
                leftsum = 0;
                rightsum = 0;
                if (input[x,y] == 'A') {
                    /* upleft */
                    leftsum += input[x - 1, y - 1] switch
                    {
                        'M' => 1,
                        'S' => 0,
                        'X' => 3,
                        'A' => 3,
                        _ => 0
                    };
                    /* downright */
                    leftsum += input[x+1,y+1] switch {
                        'M' => 1,
                        'S' => 0,
                        'X' => 3,
                        'A' => 3,
                        _ => 0
                    };
                    /* upright */
                    rightsum += input[x+1,y-1] switch {
                        'M' => 1,
                        'S' => 0,
                        'X' => 3,
                        'A' => 3,
                        _ => 0
                    };
                    /* downleft */
                    rightsum += input[x-1,y+1] switch {
                        'M' => 1,
                        'S' => 0,
                        'X' => 3,
                        'A' => 3,
                        _ => 0
                    };
                    xmascount = leftsum == 1 && rightsum == 1 ? xmascount+1 : xmascount;
                }
            }
        }
        return xmascount;
    }
}