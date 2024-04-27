public static class DamageSystem
{
    public static float GetDamageMultiplier(this EnemyType source, DamageType target)
    {
        return (source, target) switch 
        {
            (EnemyType.Slime, DamageType.Ice) => 1.5f,
            (EnemyType.Slime, DamageType.Lava) => 1.5f,
            (EnemyType.Slime, DamageType.Sand) => 0.5f,
            (EnemyType.Slime, DamageType.Plant) => 0.5f,
            (EnemyType.Tentacle, DamageType.Ice) => 1.5f,
            (EnemyType.Tentacle, DamageType.Sand) => 1.5f,
            (EnemyType.Tentacle, DamageType.Water) => 1.5f,
            (EnemyType.Tentacle, DamageType.Earth) => 1.5f,
            (EnemyType.Tentacle, DamageType.Lava) => 0.5f,
            (EnemyType.Tentacle, DamageType.Plant) => 0.0f,
            (EnemyType.ChongusDragon, DamageType.Ice) => 1.5f,
            (EnemyType.ChongusDragon, DamageType.Plant) => 1.5f,
            (EnemyType.ChongusDragon, DamageType.Water) => 1.5f,
            (EnemyType.ChongusDragon, DamageType.Sand) => 0.5f,
            (EnemyType.ChongusDragon, DamageType.Earth) => 0.5f,
            (EnemyType.ChongusDragon, DamageType.Lava) => 0.0f,
            (EnemyType.ChongusDragon, DamageType.Fire) => 0.0f,
            (EnemyType.EldrichShadow, DamageType.Steam) => 2.0f,
            (EnemyType.EldrichShadow, DamageType.Lava) => 2.0f,
            (EnemyType.EldrichShadow, DamageType.Fire) => 2.0f,
            (EnemyType.EldrichShadow, _) => 0.0f,
            (_, _) => 1,
        };
    }
}