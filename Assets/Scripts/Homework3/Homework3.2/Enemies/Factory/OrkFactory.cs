using System;

public class OrkFactory : EnemyFactory
{
    public override BattleCharacter Get(ClassType classType)
    {
        switch (classType)
        {
            case ClassType.Mage:   
                return new OrkMage();
            

            case ClassType.Palladin:
                return new OrkPalladin();

            default:
                throw new ArgumentException(nameof(classType));
        }
    }
}
