using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.TerrainTools;

public class Solution
{
    public int Sum;
    public int MinCoinNumber;
    public List<List<int>> Sequences;
    private List<int> _differentCoins;

    public bool HasSolution => Sequences.Count != 0;

    public Solution(int _Sum)
    {
        Sum = _Sum;
        Sequences = new List<List<int>>();
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
    }

    private void FillDifferentCoins()
    {
        _differentCoins.Clear();

        foreach(List<int> l in Sequences){
            HashSet<int> existedCoins = new HashSet<int>(l);
            _differentCoins.Add(existedCoins.Count);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"--------------- SUM {Sum} SOLUTION ---------------\n");

        for(int i = 0; i < Sequences.Count; ++i){
            foreach(int n in Sequences[i])
                sb.Append($"{n.ToString()}\t");

            sb.Append($" --> coins: {Sequences[i].Count}\n");
        }

        sb.Append($"---------------------------------------------");

        return sb.ToString();
    }
}
