using Zenject;

public class GameInstaller : MonoInstaller
{
    public PlayerMoney playerMoney;
    public PlayerActiveIncome playerActiveIncome;
    public PlayerPassiveIncome playerPassiveIncome;
    public PlayerActiveUpgrades playerActiveUpgrades;
    public PlayerMorePassiveUpgrades playerMorePassiveUpgrades;
    public PlayerFasterPassiveUpgrades playerFasterPassiveUpgrades;
    public PlayerBonuses playerBonuses;
    public GameSettings gameSettings;
    public GameManager gameManager;
    public GameLoop gameLoop;
    public ScoreCounter score;
    public PrefabManager prefabManager;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMoney>().FromInstance(playerMoney).AsSingle();
        Container.Bind<PlayerPassiveIncome>().FromInstance(playerPassiveIncome).AsSingle();
        Container.Bind<PlayerActiveIncome>().FromInstance(playerActiveIncome).AsSingle();
        Container.Bind<PlayerActiveUpgrades>().FromInstance(playerActiveUpgrades).AsSingle();
        Container.Bind<PlayerMorePassiveUpgrades>().FromInstance(playerMorePassiveUpgrades).AsSingle();
        Container.Bind<PlayerFasterPassiveUpgrades>().FromInstance(playerFasterPassiveUpgrades).AsSingle();
        Container.Bind<PlayerBonuses>().FromInstance(playerBonuses).AsSingle();
        Container.Bind<GameSettings>().FromInstance(gameSettings).AsSingle();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
        Container.Bind<GameLoop>().FromInstance(gameLoop).AsSingle();
        Container.Bind<ScoreCounter>().FromInstance(score).AsSingle();
        Container.Bind<PrefabManager>().FromInstance(prefabManager).AsSingle();
    }
}
