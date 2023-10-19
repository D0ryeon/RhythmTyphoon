public class PlayerData : IBaseData
{
    private string _playerName;
    private int _maxHP;
    private float _speed;
    private int _hp;

    public string Name { get { return _playerName; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public int MaxHP { get { return _maxHP; } }
    public float Speed { get { return _speed; } }

    public PlayerData(string name, int maxhp, int speed)
    {
        _playerName = name;
        _hp = maxhp;
        _maxHP = maxhp;
        _speed = speed;
    }
}
