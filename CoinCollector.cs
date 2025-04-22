using Godot;

public partial class CoinCollector : Node2D
{
    [Export] public PackedScene CoinScene { get; set; }
    private int _score = 0;
    private Label _scoreLabel;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("ScoreLabel");
        SpawnCoins(5);
    }

    private void SpawnCoins(int count)
    {
        var viewportRect = GetViewport().GetVisibleRect();

        for (int i = 0; i < count; i++)
        {
            var coin = CoinScene.Instantiate<Coin>();
            AddChild(coin);


            coin.Position = new Vector2(
                (float)GD.RandRange(50, viewportRect.Size.X - 50),
                (float)GD.RandRange(50, viewportRect.Size.Y - 50)
            );

            coin.Collected += OnCoinCollected;
        }
    }

    private void OnCoinCollected()
    {
        _score++;
        _scoreLabel.Text = $"Score: {_score}";
    }
}