using System.Collections.Generic;

namespace Advent2024;

public class PuzzleSixteen {
    public long StartElvesWorking(char[,] input){
        var nodelist = new Dictionary<char,List<int[]>>();
        //print input
        var ylength = input.GetLength(0);
        var xlength = input.GetLength(1);
        for(var y = 0; y < ylength; y++){
            for(var x = 0; x < xlength; x++){
                Console.Write(input[y,x]);
            }
            Console.Write("\n");
        }
        //get nodes
        GetNodes(input,nodelist);
        //print nodes
        foreach(var nodetype in nodelist){
            Console.Write(nodetype.Key);
            Console.Write(": ");
            foreach(var value in nodetype.Value){
                Console.Write("[{0}]",string.Join(", ",value));
                Console.Write(" ");
            };
            Console.Write("\n");
        }
        var antinodelist = CartesianMyNodes(nodelist,ylength-1,xlength-1,input);
        foreach(var antinode in antinodelist){
            Console.Write(antinode);
            Console.Write(" ");
        }
        Console.Write("\n");
        for(var y = 0; y < ylength; y++){
            for(var x = 0; x < xlength; x++){
                Console.Write(input[y,x]);
            }
            Console.Write("\n");
        }
        int result = antinodelist.Distinct().Count();
        return result;
    }
    public void GetNodes(char[,] input, Dictionary<char,List<int[]>> nodelist){
        var xlength = input.GetLength(1);
        var ylength = input.GetLength(0);
        for(var y = 0; y < ylength; y++){
            for(var x = 0; x < xlength; x++){
                if(!nodelist.Keys.Contains(input[y,x]) && input[y,x] != '.'){
                    nodelist.Add(input[y, x], new List<int[]>{([y, x])});
                }
                else if (input[y,x] != '.'){
                    nodelist[input[y,x]].Add([y, x]);
                }
            }
        }
    }
    public List<string> CartesianMyNodes(Dictionary<char,List<int[]>> nodelist,int yupperbound,int xupperbound,char[,] input){
        var antinodes = new List<string>();
        Console.WriteLine(yupperbound+","+xupperbound);
        foreach(var list in nodelist){
            var nodepairs = new List<List<int[]>>
            {
                list.Value,
                list.Value
            };
            var antinodecalcs = MakeNumbersGoBrr.CartesianProduct(nodepairs);
            foreach(var metalist in antinodecalcs){
                var ydirection = 0;
                var xdirection = 0;
                var yvalue = 0;
                var xvalue = 0;
                var skip = 0;
                foreach(var arr in metalist){
                    ydirection *= -1;
                    xdirection *= -1;
                    ydirection -= arr[0];
                    xdirection -= arr[1];
                    if (
                        yvalue == arr[0]
                        &&xvalue == arr[1]
                    ){
                        skip = 1;
                    }else {
                        yvalue = arr[0];
                        xvalue = arr[1];
                    }
                }
                if(skip == 1){
                    continue;
                }
                var yfirstantinode = yvalue+(ydirection*2);
                var xfirstantinode = xvalue+(xdirection*2);
                var ysecondantinode = yvalue+(ydirection*-1);
                var xsecondantinode = xvalue+(xdirection*-1);
                if(
                    CheckXYin2dArrayBounds(yfirstantinode,xfirstantinode,yupperbound,xupperbound)
                ){
                    input[yfirstantinode,xfirstantinode] = '#';
                    antinodes.Add(yfirstantinode+","+xfirstantinode);
                }
                if(
                    CheckXYin2dArrayBounds(ysecondantinode,xsecondantinode,yupperbound,xupperbound)
                ){
                    input[ysecondantinode,xsecondantinode] = '#';
                    antinodes.Add(ysecondantinode+","+xsecondantinode);
                }
            }
        }
        return antinodes;
    }
    public bool CheckXYin2dArrayBounds(int yvalue,int xvalue,int yupperbound,int xupperbound){
        if(
            yvalue <= yupperbound
            && xvalue <= xupperbound
            && yvalue > -1
            && xvalue > -1
        ){
            return true;
        }
        else {
            return false;
        }
    }
}