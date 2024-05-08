using System;
using System.Collections.Generic;
using UnityEngine;

public class CircleKeeper 
{
    private CircleSpawner _circleSpawner;
    private List<CircleMonobehavior> _circles;
    private VictoryCondition _victoryCondition;

    public VictoryCondition VictoryCondition => _victoryCondition;

    public CircleKeeper(CircleSpawner circleSpawner, VictoryCondition victoryCondition)
    {
        _circleSpawner = circleSpawner;
        //_victoryCondition = new DestroyAllCircles();
        _victoryCondition = victoryCondition;
    }

    public void SetVictoryCondition(VictoryCondition victoryCondition)
    {
        _victoryCondition = victoryCondition;
    }

    public void CreatePlayingField(int minCirclesOneColor, int maxCirclesOneColor)
    {
        _circles = new List<CircleMonobehavior>();
        System.Random random = new System.Random();
        List<int>  amountCirclesByType = new List<int>();
        
        foreach(TypeCircle typeCircle in Enum.GetValues(typeof(TypeCircle)))
        {
            amountCirclesByType.Add(random.Next(minCirclesOneColor, maxCirclesOneColor));
        }

        for(int i = 0; i < amountCirclesByType.Count; i++)
        {
            _circles.AddRange(_circleSpawner.CreateCircles((TypeCircle)Enum.GetValues(typeof(TypeCircle)).GetValue(i), amountCirclesByType[i]));
        }

        _victoryCondition.SetCircles(amountCirclesByType);
    }

    public void ClickedOnCircle(CircleMonobehavior circle)
    {
        circle.Hide();
        _victoryCondition.CircleDown(circle.TypeCircle);
    }

    public void RestartLevel()
    {
        foreach(CircleMonobehavior circle in _circles)
        {
            circle.Show();
        }

        _victoryCondition.RestartLevel();
    }

}
