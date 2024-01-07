using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDirector : MonoBehaviour
{
    private SolutionGenerator _generator;
    private List<Solution> _allSolutions;
    private Solution _bestSolution;

    private AvailableCoinsView _allCoinsView;
    private PigView _pigView;

    private void Awake() {

        _allCoinsView = GetComponentInChildren<AvailableCoinsView>();
        _pigView = GetComponentInChildren<PigView>();

        _generator = new SolutionGenerator();

        int coinMin = 5;
        int coinMax = 25;
        int coinNumber = 5;
        int maxSolutionValue = 80;

         _generator.GenerateSolutions(coinMin, coinMax, coinNumber, maxSolutionValue);

         _allSolutions = _generator.allSolutions;

        int solIndex = _allSolutions.Count;

        while(--solIndex >= 0)
        {
            if(!_allSolutions[solIndex].HasSolution)
            {
                _allSolutions[solIndex].Dispose();
                _allSolutions.RemoveAt(solIndex);
            }
        }

        int bestSolutionIndex = -1;
        int maxSolutionDifferentCoins = 0;

        for(int i = 0; i < _allSolutions.Count; ++i)
        {
            Solution curSolution = _allSolutions[i];
            int curSolutionDifCoins = curSolution.DifferentLegnghts.Count;

            if(curSolution.DifferentLegnghts.Count > maxSolutionDifferentCoins)
            {
                maxSolutionDifferentCoins = curSolutionDifCoins;
                bestSolutionIndex = i;
            }
        }

        _bestSolution = _allSolutions[bestSolutionIndex];
    }

    // Start is called before the first frame update
    void Start()
    {
        _allCoinsView.AddCoins(_generator.allCoins);
        _pigView.SetSum(_bestSolution.Sum);

        Debug.Log(_bestSolution);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
