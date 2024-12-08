using System.Collections.Generic;

namespace Advent2024;

public class PuzzleThirteen {
    public long StartElvesWorking(Dictionary<long,int[]> inputcompare) {
        long piperspiping = 0;
        var cartesians = new Dictionary<long,int[]>();
        var sequencetest = new List<int[]>();
        foreach (var input in inputcompare) {
            var sequences = new List<int[]>();
            for (var x = 0; x < input.Value.Length-1; x++) {
                var sequence = (int[])[0,1];
                sequences.Add(sequence);
            }
            var operationpermutations = MakeNumbersGoBrr.CartesianProduct(sequences);
            sequences.Clear();
            foreach(var operationset in operationpermutations) {
                var iteration = 0;
                long operationtotal = 0;

                foreach(var operation in operationset) {
                    if(iteration == 0) {
                        operationtotal = PerformOperation(operation,input.Value[iteration],input.Value[iteration+1]);
                    }
                    else {
                        operationtotal = PerformOperation(operation,operationtotal,input.Value[iteration+1]);
                    }
                    iteration++;
                }

                if(operationtotal == input.Key) {


                    piperspiping += operationtotal;
                    break;
                }

            }
        }
        return piperspiping;
    }
    public long PerformOperation(int operation, long value1, long value2) {
        long result = 0;
        if(operation == 0) {
            result = value1 + value2;
        }
        if(operation == 1) {
            result = value1 * value2;
        }
        return result;
    }
}