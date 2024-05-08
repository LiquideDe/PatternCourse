public class DestroyOnlyOneColor : VictoryCondition
{
    private bool _isColorChosen;
    private int _idColorChosen;

    protected override void CheckCondition()
    {
        if(_isColorChosen == false)
        {
            _isColorChosen = true;
            for(int i = 0; i < _amountCirclesByType.Count; i++)
            {
                if(_amountCirclesByType[i] != _amountMaxCirclesByType[i])
                {
                    _idColorChosen = i;
                    break;
                }
            }
        }

        if (CheckAllAnotherDontPush() && CheckAmountChosenColor())
            Win();

    }

    public override void RestartLevel()
    {
        base.RestartLevel();
        _isColorChosen = false;
    }

    private bool CheckAllAnotherDontPush()
    {
        for(int i = 0; i < _amountMaxCirclesByType.Count; i++)
        {
            if(i != _idColorChosen)
            {
                if(_amountCirclesByType[i] != _amountMaxCirclesByType[i])
                {
                    Loose();
                    return false;
                }
            }
        }

        return true;
    }

    private bool CheckAmountChosenColor()
    {
        if (_amountCirclesByType[_idColorChosen] == 0)
            return true;

        return false;
    }
}
