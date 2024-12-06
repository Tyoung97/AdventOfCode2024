namespace Advent2024;

public class PuzzleNine {
    public int StartElvesWorking(List<int[]> inputtosearch, List<Tuple<int,int>> inputrules) {
        var naughtynicetotal = 0;

        var naughtyandnice = BuildNaughtyOrNiceList(inputrules);
        var naughtytonice = SortPeopleFromNaughtyToNice(inputtosearch,naughtyandnice);
        naughtynicetotal = CheckItTwice(naughtytonice);

        return naughtynicetotal;
    }
    public Dictionary<int,Tuple<List<int>,List<int>>> BuildNaughtyOrNiceList(List<Tuple<int,int>> inputrules) {
        var naughtyandnice = new Dictionary<int, Tuple<List<int>, List<int>>>();
        var allthethings = inputrules.Select(rule => rule.Item1).Distinct().ToList().Union(inputrules.Select(rule => rule.Item2).Distinct().ToList());
        var betterthan = new List<int>();
        var worsethan = new List<int>();

        foreach(var thing in allthethings) {
            betterthan = inputrules.Where(tuple => tuple.Item1 == thing).Select(tuple => tuple.Item2).ToList();
            worsethan = inputrules.Where(tuple => tuple.Item2 == thing).Select(tuple => tuple.Item1).ToList();
            naughtyandnice.Add(thing, new Tuple<List<int>, List<int>>(betterthan,worsethan));
        }

        return naughtyandnice;
    }
    public List<int[]> SortPeopleFromNaughtyToNice (List<int[]> inputtosearch, Dictionary<int,Tuple<List<int>,List<int>>> naughtyandnice) {
            var  gofindyourfather = new GoFindYourFather();
            var sorting = inputtosearch.Select(value => (int[])value.Clone()).ToList();
            var naughtytonice = new List<int[]>();
            var interation = 0;

            foreach(var array in sorting) {
                var length = array.Length;
                gofindyourfather.GiveItToBuddy(array, 0, length-1, naughtyandnice);
                if(array.SequenceEqual(inputtosearch[interation])) {
                    naughtytonice.Add(array);
                }
                interation++;
            }

            return naughtytonice;
    }
    public int CheckItTwice(List<int[]> naughtytonice) {
        var totalnaughtyofnice = 0;

        totalnaughtyofnice = naughtytonice.Select(value => value[value.Length/2]).Sum();

        return totalnaughtyofnice;
    }
}