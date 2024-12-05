using System.IO;
using System.Collections;

var lines = File.ReadLines("TestInput.csv");
// var lines = File.ReadLines("Input.csv");
var safelines = 0;

foreach (var line in lines) {
    var values = line.Split(",").Select(int.Parse).ToList();
    var length = values.Count()-1;
    var safe = false;

    List<Tuple<int, bool>> WhiteSnake(List<int> list, int length) {
        var increasingcount = 0;
        var decreasingcount = 0;
        var iteration = 0;
        var tuplelist = new List<Tuple<int, bool>>();

        /*
            AND HERE I GO AGAIN ON MY OWN! LOOPING LISTS IS THE ONLY CODE I'VE EVER KNOWN!
            LIKE A LINTER I WAS BORN FOR ERRORS THROWN! BUT I'VE MADE UP MY MIND, I'M LOOPING ONE MORE TIME!
            BUT HERE I GO AGAIN!
        */
        while (iteration < length) {
            var delta = list[iteration] - list[iteration+1];
            if(delta > 0) {
                increasingcount++;
            }
            if (delta < 0) {
                decreasingcount++;
            }
            iteration++;
        }

        iteration = 0;
        while (iteration < length) {
            var fault = false;
            var delta = list[iteration] - list[iteration+1];
            if(delta > 0 && decreasingcount > increasingcount) {
                fault = true;
            }
            if (delta < 0 && decreasingcount < increasingcount) {
                fault = true;
            }
            if (delta == 0) {
                fault = true;
            }
            if (delta > 3 || delta < -3) {
                fault = true;
            }

            tuplelist.Add(new Tuple<int, bool>(list[iteration],fault));
            if (iteration+1 == length) {
                tuplelist.Add(new Tuple<int, bool>(list[iteration+1],false));
            }
            iteration++;
        }

        return tuplelist;
    };

    var tuplelist = WhiteSnake(values, length);
    safe = tuplelist.Where(pair => pair.Item2 == true).Count() < 1;

    // if (!safe) {
    //     var failures = tuplelist.Select((value, index) => new {value, index}).Where(pair => pair.value.Item2 == true).Select(pair => pair.index).DefaultIfEmpty(-1);
    //     foreach (var fail in failures) {
    //         var valueswithoutfailure = values.Select((value, index) => new {value,index}).Where(pair => pair.index != fail).Select(pair => pair.value).ToList();
    //         Console.WriteLine(valueswithoutfailure.Aggregate("",(str, value) => str + value.ToString()+","));
    //         /*
    //             AND HERE I GO AGAIN ON MY OWN! LOOPING LISTS IS THE ONLY CODE I'VE EVER KNOWN!
    //             LIKE A LINTER I WAS BORN FOR ERRORS THROWN! BUT I'VE MADE UP MY MIND, I'M LOOPING ONE MORE TIME!
    //             AND HERE I GO AGAIN! LOOPING LISTS IS THE ONLY CODE I'VE EVER KNOWN!
    //             LIKE A LINTER I WAS BORN FOR ERRORS THROWN! CAUSE I KNOW WHAT IT MEANS, TO ITERATE OVER A LONELY LIST OF DREAMS!
    //         */
    //         var failuretuplelist = WhiteSnake(valueswithoutfailure, length-1);
    //         safe = safe || failuretuplelist.Where(pair => pair.Item2 == true).Count() < 1;

    //         /* maybe both sides of the failure count? */
    //         //valueswithoutfailure.Clear();
    //         //failuretuplelist.Clear();

    //         //valueswithoutfailure = values.Select((value, index) => new {value,index}).Where(pair => pair.index != fail+1).Select(pair => pair.value).ToList();
    //         //Console.WriteLine(valueswithoutfailure.Aggregate("",(str, value) => str + value.ToString()+","));
    //         //failuretuplelist = WhiteSnake(valueswithoutfailure, length-1);
    //         //safe = safe || failuretuplelist.Where(pair => pair.Item2 == true).Count() < 1;
    //     }
    // }

    var testindex = 0;
    if (!safe) {
        while (testindex < length) {
            var valueswithoutfailure = values.Select((value, index) => new {value,index}).Where(pair => pair.index != testindex).Select(pair => pair.value).ToList();
            // Console.WriteLine(valueswithoutfailure.Aggregate("",(str, value) => str + value.ToString()+","));
            /*
                AND HERE I GO AGAIN ON MY OWN! LOOPING LISTS IS THE ONLY CODE I'VE EVER KNOWN!
                LIKE A LINTER I WAS BORN FOR ERRORS THROWN! BUT I'VE MADE UP MY MIND, I'M LOOPING ONE MORE TIME!
                AND HERE I GO AGAIN! LOOPING LISTS IS THE ONLY CODE I'VE EVER KNOWN!
                LIKE A LINTER I WAS BORN FOR ERRORS THROWN! CAUSE I KNOW WHAT IT MEANS, TO ITERATE OVER A LONELY LIST OF DREAMS!
            */
            var failuretuplelist = WhiteSnake(valueswithoutfailure, length-1);
            safe = safe || failuretuplelist.Where(pair => pair.Item2 == true).Count() < 1;
            testindex++;
        }
    }

    // Console.WriteLine(line +" "+ safe.ToString());
    if (safe) {
        safelines++;
    }
}

Console.WriteLine(safelines.ToString());