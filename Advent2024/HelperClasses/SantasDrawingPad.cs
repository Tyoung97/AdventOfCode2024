namespace Advent2024;

public class SantasDrawingPad() {
    public int[] FindTheNextHouse(List<int[]> chimneys, int[] position, Tuple<int,int> direction, int[] edgeofworld) {
        var chimneyposition = new int[3];
        chimneyposition = position;
        var indexofitem = -1;
        //some basic guard rails
        if(edgeofworld.Length == 4) {
            //loop till we find a chimney or the edge of the world
            while(
                chimneyposition[0] > edgeofworld[0]
                && chimneyposition[0] < edgeofworld[1]
                && chimneyposition[1] > edgeofworld[2]
                && chimneyposition[1] < edgeofworld[3]
            ) {
                indexofitem = chimneys.FindIndex(chimney => chimney[0] == chimneyposition[0] && chimney[1] == chimneyposition[1]);
                if(indexofitem != -1) {
                    (chimneyposition[0], chimneyposition[1], chimneyposition[2]) = (chimneyposition[0] - direction.Item1, chimneyposition[1] - direction.Item2, 0);
                    break;
                }
                (chimneyposition[0], chimneyposition[1], chimneyposition[2]) = (chimneyposition[0] + direction.Item1, chimneyposition[1] + direction.Item2, 0);
            }
            if(indexofitem == -1) {
                (chimneyposition[0], chimneyposition[1], chimneyposition[2]) = (chimneyposition[0] - direction.Item1, chimneyposition[1] - direction.Item2, 1);
            }
        }
        return chimneyposition;
    }
    public int[] FindTheNextHouse(List<int[]> chimneys, int[] position, Tuple<int,int> direction, int[] edgeofworld, int directionid) {
        var chimneyposition = new int[4];
        chimneyposition = position;
        var indexofitem = -1;
        //some basic guard rails
        if(edgeofworld.Length == 4) {
            //loop till we find a chimney or the edge of the world
            while(
                chimneyposition[0] > edgeofworld[0]
                && chimneyposition[0] < edgeofworld[1]
                && chimneyposition[1] > edgeofworld[2]
                && chimneyposition[1] < edgeofworld[3]
            ) {
                indexofitem = chimneys.FindIndex(chimney => chimney[0] == chimneyposition[0] && chimney[1] == chimneyposition[1]);
                if(indexofitem != -1) {
                    (chimneyposition[0], chimneyposition[1], chimneyposition[2],chimneyposition[3]) = (chimneyposition[0] - direction.Item1, chimneyposition[1] - direction.Item2, 0, directionid);
                    break;
                }
                (chimneyposition[0], chimneyposition[1], chimneyposition[2],chimneyposition[3]) = (chimneyposition[0] + direction.Item1, chimneyposition[1] + direction.Item2, 0, directionid);
            }
            if(indexofitem == -1) {
                (chimneyposition[0], chimneyposition[1], chimneyposition[2],chimneyposition[3]) = (chimneyposition[0] - direction.Item1, chimneyposition[1] - direction.Item2, 1, directionid);
            }
        }
        return chimneyposition;
    }
    public List<int[]> LookForChimneys(Location[,] santasmap, char symbol) {
        var positions = new List<int[]>();
        for (var y = 0; y < santasmap.GetLength(0); y++) {
            for (var x = 0; x < santasmap.GetLength(1); x++) {
                if(santasmap[y,x].locationsymbol == symbol) {
                    positions.Add([y,x,0,-1]);
                }
            }
        }
        return positions;
    }
}