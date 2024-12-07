namespace Advent2024;

public class SantasDrawingPad() {
    public int[] LineUpTheReindeer(List<int[]> walls, int[] position, Tuple<int,int> direction, int[] edgeofworld) {
        var wallposition = position;
        var indexofitem = -1;
        //some basic guard rails
        if(edgeofworld.Length == 4) {
            //loop till we find a wall or the edge of the world
            while(
                wallposition[0] < edgeofworld[0]
                && wallposition[0] > edgeofworld[1]
                && wallposition[1] < edgeofworld[2]
                && wallposition[1] > edgeofworld[3]
            ) {
                indexofitem = walls.FindIndex(wall => wall[0] == wallposition[0] && wall[1] == wallposition[1]);
                if(indexofitem != -1) {
                    break;
                }
                (wallposition[0], wallposition[1]) = (wallposition[0] + direction.Item1, wallposition[1] + direction.Item2);
            }
        }
        if(indexofitem == -1) {
            wallposition[2] = 1;
        }
        return wallposition;
    }
}