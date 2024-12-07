namespace Advent2024;

public class PuzzleEleven {
    public int StartElvesWorking(Dictionary<char,int>[,] inputtosearch) {
        var santasneakysteps = 0;
        var walls = new List<int[]>();
        var position = new int[3]{0,0,0};
        var path = new List<int[]>();
        var direction = new List<Tuple<int,int>>{
            new Tuple<int, int>(0,-1), //up
            new Tuple<int, int>(1,0),  //right
            new Tuple<int, int>(0,1),  //Down
            new Tuple<int, int>(-1,0)  //Left
        };


        //First identify wall positions and starting position
        //Add start position to path
        //find draw lines and pivot direction until we hit edge of the world.

        return santasneakysteps;
    }
}