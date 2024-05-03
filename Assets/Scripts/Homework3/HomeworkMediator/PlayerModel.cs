using System;

public class PlayerModel
{
    public event Action Dead;
    public event Action HpWasChanged;
    public event Action LvlWasChanged;

    private int _hp;
    private int _lvl;
    private readonly int _startHp;
    private readonly int _startLvl;

    public PlayerModel(int startHp, int startLvl)
    {
        _startHp = startHp;
        _startLvl = startLvl;
        RestartLvl();
    }

    public int Hp => _hp;
    public int Lvl => _lvl;

    public void DecreaseHp()
    {
        _hp--;
        HpWasChanged?.Invoke();

        if (_hp <= 0)
            Dead?.Invoke();
    }

    public void IncreaseLvl()
    {
        _lvl++;
        LvlWasChanged?.Invoke();
    }

    public void RestartLvl()
    {
        _hp = _startHp;
        _lvl = _startLvl;
        HpWasChanged?.Invoke();
        LvlWasChanged?.Invoke();
    }
    
}
