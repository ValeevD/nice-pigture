using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsInformation : MonoBehaviour
{
    private SolutionGenerator _generator;

    [ContextMenu("Show Level")]
    void ShowLevel()
    {
        _generator = new SolutionGenerator(5, 15, 3, 33);
        Solution bestSolution = null;
        int bestLen = 0;

        for(int i = 0; i < 30; ++i)
        {
            (List<int>, List<Solution>) solutionInformation = _generator.GenerateSolutions();


            foreach(var s in solutionInformation.Item2)
            {
                if(s.HasSolution && s.DifferentLegnghts.Count >= 2 && s.bestLen > bestLen)
                {
                    bestSolution = s;
                    bestLen = s.bestLen;
                }
            }
        }
            if(bestSolution != null)
            {
                Debug.Log($"Coins {GeneratorTester.LogList(bestSolution.Coins)}");
                Debug.Log(bestSolution.ToString());
            }
    }
}
