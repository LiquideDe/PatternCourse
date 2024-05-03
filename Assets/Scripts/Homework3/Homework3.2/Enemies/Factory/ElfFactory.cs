using System;

public class ElfFactory : EnemyFactory
{
    public override BattleCharacter Get(ClassType classType)
    {
        switch (classType)
        {
            case ClassType.Mage:
                return new ElfMage();

            case ClassType.Palladin:
                return new ElfPalladin();

            default:
                throw new ArgumentException(nameof(classType));
        }
    }
}
