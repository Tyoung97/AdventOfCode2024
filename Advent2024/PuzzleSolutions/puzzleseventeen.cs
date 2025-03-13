using System.Collections.Generic;

namespace Advent2024;

public class PuzzleSeventeen {
    public long StartElvesWorking(char[] input){
        var result = 0;
        var totallength = input.Sum(x => x);
        var actualarray = BuildActualArray(input,totallength);
        foreach(var character in input){
            Console.Write(character);
        }
        Console.Write('\n');
        foreach(var value in actualarray){
            Console.Write(value+" ");
        }
        Console.Write('\n');
        return result;
    }
    public string[] BuildActualArray(char[] input,int totallength){
        var stringarray = new string[totallength];
        var loopnumber = 0;
        var arrraynumber = 0;
        var arrayposition = 0;
        foreach(var value in input){
            var inegervalue = int.Parse(value.ToString());
            var diskvalue = ".";
            if(loopnumber % 2 == 0){
                diskvalue = arrraynumber.ToString();
                arrraynumber++;
            }
            for(var occurrencecount = 0; occurrencecount < inegervalue; occurrencecount++){
                stringarray[arrayposition] = diskvalue;
                arrayposition++;
            }
            loopnumber++;
        }
        return stringarray;
    }
    public string[] CompactArray(string[] currentarray){
        var nextemptyposition = 0;
        var nextnonemptyposition = 0;
        
    }
    public int FindNextEmptyPosition(string[] currentarray, int startposition, int arraylength){
        var emptyposition = -1;
        for(var loopnumber = startposition; loopnumber <= arraylength; loopnumber++){
            if(){
                
            }
        }
    }
}
