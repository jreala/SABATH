public class EnemyModel
{
    public EnemyType enemyType { get; set; }
    public double experienceGain { get; set; }
}

public enum EnemyType
{
    Small,
    Medium,
    Large,
    Boss
}