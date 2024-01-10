using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Solution: IDisposable
{
    public int Sum;
    public int MinCoinNumber;
    public List<List<int>> Sequences;
    public List<int> DifferentLegnghts;
    public List<int> DifferentCoins;
    public int bestLen;

    public bool HasSolution => Sequences.Count != 0;

    public Solution(int _Sum)
    {
        Sum = _Sum;
        Sequences = new List<List<int>>();
        DifferentLegnghts = new List<int>();
        DifferentCoins = new List<int>();
    }

    public void Dispose()
    {
        DifferentCoins.Clear();
        DifferentLegnghts.Clear();
        foreach(var l in Sequences)
            l.Clear();
        Sequences.Clear();
    }

    public void FillFromSolutionWithCoin(Solution sol, int newCoin)
    {
        foreach(List<int> l in sol.Sequences){
            List<int> newList = new List<int>(l);
            newList.Add(newCoin);

            Sequences.Add(newList);
        }
    }

    public void AddSolutionWithOneCoin(int newCoin)
    {
        List<int> newList = new List<int>();

        newList.Add(newCoin);

        Sequences.Add(newList);
    }

    public void CutSolution()
    {
        foreach(List<int> l in Sequences)
            l.Sort();

        int i = 0;

        while(i < Sequences.Count)
        {
            List<int> curSolution = Sequences[i];
            List<int> sameSolutionIndexes = new List<int>();

            for(int j = 0; j < curSolution.Count; ++j){
                if(j == 0){
                    for(int k = i + 1; k < Sequences.Count; ++k)
                        if(curSolution[j] == Sequences[k][j])
                            sameSolutionIndexes.Add(k);
                }
                else{
                    for(int l = sameSolutionIndexes.Count - 1; l >= 0; --l){
                        List<int> watchSequence = Sequences[sameSolutionIndexes[l]];

                        if(j >= watchSequence.Count || curSolution[j] != watchSequence[j])
                            sameSolutionIndexes.RemoveAt(l);
                    }
                }

                if(sameSolutionIndexes.Count == 0)
                    break;
            }

            sameSolutionIndexes.Sort((a, b) => b.CompareTo(a));

            foreach(int ind in sameSolutionIndexes)
                Sequences.RemoveAt(ind);

            ++i;
        }

        FillDifferentCoins();
    }

    private void FillDifferentCoins()
    {
        DifferentLegnghts.Clear();
        HashSet<int> existedCoins = new HashSet<int>();

        foreach(List<int> l in Sequences){
            existedCoins.Add(l.Count);
        }

        DifferentLegnghts.AddRange(existedCoins);
        bestLen = 999;

        foreach(var s in DifferentLegnghts)
        {
            bestLen = s > bestLen ? bestLen : s;
        }

        bestLen = bestLen == 999 ? 0 : bestLen;

        foreach(List<int> l in Sequences){
            existedCoins = new HashSet<int>(l);
            DifferentCoins.Add(existedCoins.Count);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"--------------- SUM {Sum} SOLUTION");
        sb.Append($" DIFFERENT LENGHTS ----------------");
        DifferentLegnghts.Sort();

        foreach(var d in DifferentLegnghts)
            sb.Append($"{d}, ");

        sb.Append($" [COUNT {DifferentLegnghts.Count}]----------------[BEST {bestLen}]");

        sb.Append("---------------\n");

        for(int i = 0; i < Sequences.Count; ++i){
            foreach(int n in Sequences[i])
                sb.Append($"{n.ToString()}\t");

            sb.Append($" --> coins: {Sequences[i].Count} ({DifferentCoins[i]}) {(Sequences[i].Count == bestLen ? " >>>>>>>>>>>> BEST" : "")}\n");
        }
        return sb.ToString();
    }
}
