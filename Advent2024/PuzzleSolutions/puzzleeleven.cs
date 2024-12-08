namespace Advent2024;

public class PuzzleEleven {
    public int StartElvesWorking(Location[,] inputtosearch, char startsymbol, char chimneysymbol) {
        var santasneakysteps = 0;
        var chimneys = new List<int[]>();
        var edgeofworld = new int[4]{
            -1,
            inputtosearch.GetLength(0),
            -1,
            inputtosearch.GetLength(1)
        };
        var path = new List<int[]>();
        var finishedroute = false;
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
            path.Add(start);
        };
        //Then identify wall positions
        foreach(var chimney in santasdrawingpad.LookForChimneys(inputtosearch, chimneysymbol)) {
            chimneys.Add(chimney);
        };
        //find draw lines and pivot direction until we hit edge of the world.
        var position = new int[3];
        position = (int[])path[0].Clone();
        while(!finishedroute) {
            position = santasdrawingpad.FindTheNextHouse(chimneys, position, direction[currentdirection],edgeofworld);
            path.Add((int[])position.Clone());
            currentdirection = ChangeDirection(currentdirection,direction.Count-1);
            finishedroute = position[2] == 1;
        }
        DeliverThePresents(inputtosearch,path);
        santasneakysteps = CountThePresents(inputtosearch);
        return santasneakysteps;
    }
    public int ChangeDirection(int currentdirection, int maxdirection) {
        var newdirection = currentdirection == maxdirection ? 0 : ++currentdirection;
        return newdirection;
    }
    public Location[,] DeliverThePresents(Location[,] inputtosearch, List<int[]> path) {
        var startlocation = true;
        var steptowarddestination = new int[2]{0,0};
        var currentlocation = new int[2]{0,0};
        for(var dest = 0; dest < path.Count; dest++) {
            if (startlocation) {
                inputtosearch[path[dest][0],path[dest][1]].locationwalked = 1;
                (currentlocation[0],currentlocation[1]) = (path[dest][0],path[dest][1]);
                startlocation = false;
            }
            else {
                (steptowarddestination[0],steptowarddestination[1]) = (path[dest][0] - path[dest-1][0],path[dest][1] - path[dest-1][1]);
                steptowarddestination[0] = steptowarddestination[0] == 0 ? steptowarddestination[0] : steptowarddestination[0]/Math.Abs(steptowarddestination[0]);
                steptowarddestination[1] = steptowarddestination[1] == 0 ? steptowarddestination[1] : steptowarddestination[1]/Math.Abs(steptowarddestination[1]);
                while(currentlocation[0] != path[dest][0] || currentlocation[1] != path[dest][1]) {
                    currentlocation[0] += steptowarddestination[0];
                    currentlocation[1] += steptowarddestination[1];
                    inputtosearch[currentlocation[0],currentlocation[1]].locationwalked = 1;
                }
            }
        }
        return inputtosearch;
    }
    public int CountThePresents(Location[,] inputtosearch) {
        var totalpresents = 0;
        foreach(var location in inputtosearch) {
            totalpresents += location.locationwalked;
        }
        return totalpresents;
    }
}