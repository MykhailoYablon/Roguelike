using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{
    public Tile ObstacleTile;
    public Tile DamagedObstacle;
    public int MaxHealth = 3;

    private int m_HealthPoint;
    private Tile m_OriginalTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);

        m_HealthPoint = MaxHealth;
        m_OriginalTile = GameManager.Instance.Board.GetCellTile(cell);

        GameManager.Instance.Board.SetCellTile(cell, ObstacleTile);
    }

    public override bool PlayerWantsToEnter()
    {
        m_HealthPoint -= 1;
        if (m_HealthPoint > 1)
        {
            return false;
        }
        else if (m_HealthPoint == 1) {
            GameManager.Instance.Board.SetCellTile(m_Cell, DamagedObstacle);
            return false;
        }
        else
        {
            GameManager.Instance.Board.SetCellTile(m_Cell, m_OriginalTile);
            Destroy(gameObject);
            return true;
        }
        
    }
}
