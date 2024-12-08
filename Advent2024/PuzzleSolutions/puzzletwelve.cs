namespace Advent2024;

public class PuzzleTwelve {
    public int StartElvesWorking(Location[,] inputtosearch, char startsymbol, char chimneysymbol) {
        var santasneakysteps = 0;
        var startlocation = new int[4];
        var chimneys = new List<int[]>();
        var edgeofworld = new int[4]{
            -1,
            inputtosearch.GetLength(0),
            -1,
            inputtosearch.GetLength(1)
        };
        var path = new List<int[]>();
        var looplist = new List<List<int[]>>();
        var finishedroute = false;
        var infiniteloop = false;
        var direction = new List<Tuple<int,int>>{
            new Tuple<int, int>(-1,0), //up
            new Tuple<int, int>(0,1),  //right
            new Tuple<int, int>(1,0),  //Down
            new Tuple<int, int>(0,-1)  //Left
        };
        var currentdirection = 0;

        var santasdrawingpad = new SantasDrawingPad();

        //First find the starting position
        foreach(var start in santasdrawingpad.LookForChimneys(inputtosearch, startsymbol)) {
            startlocation = (int[])start.Clone();
            path.Add(start);
        };
        //Then identify wall positions
        foreach(var chimney in santasdrawingpad.LookForChimneys(inputtosearch, chimneysymbol)) {
            chimneys.Add(chimney);
        };
        //add a wall then draw lines and pivot direction until we hit a route where we loop back or leave the world.
        var loopcount = 1;
        var maxloopcount = inputtosearch.GetLength(0);
        var chimneycount = chimneys.Count;
        for (var y = 0; y < inputtosearch.GetLength(0); y++) {
            Console.WriteLine("On loop "+loopcount+" of "+maxloopcount);
            for (var x = 0; x < inputtosearch.GetLength(1); x++) {
                if((path[0][0] != y || path[0][1] != x) && chimneys.FindIndex(chim => chim[0] == y && chim[1] == x) == -1) {
                    finishedroute = false;
                    infiniteloop = false;
                    currentdirection = 0;
                    var position = new int[4];
                    position = (int[])path[0].Clone();
                    chimneys.Add([y,x,0]);
                    var whileloopcount = 0;
                    while(!finishedroute) {
                        position = santasdrawingpad.FindTheNextHouse(chimneys, position, direction[currentdirection],edgeofworld, currentdirection);
                        if (path.FindIndex(location => location[0] == position[0] && location[1] == position[1] && location[3] == position[3]) != -1) {
                            infiniteloop = true;
                        }
                        path.Add((int[])position.Clone());
                        currentdirection = ChangeDirection(currentdirection,direction.Count-1);
                        if(infiniteloop) {
                            looplist.Add(path);
                        }
                        finishedroute = infiniteloop ? infiniteloop : position[2] == 1;
                        whileloopcount++;
                    }
                    chimneys.RemoveAt(chimneycount);
                }
                path.Clear();
                path.Add(startlocation);
            }
            loopcount++;
        }
        santasneakysteps = looplist.Count;
        return santasneakysteps;
    }
    public int ChangeDirection(int currentdirection, int maxdirection) {
        var newdirection = currentdirection == maxdirection ? 0 : ++currentdirection;
        return newdirection;
    }
}