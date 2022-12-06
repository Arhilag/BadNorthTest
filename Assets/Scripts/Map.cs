using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Panel[] _tiles;

    public void ShowTiles()
    {
        foreach (var tile in _tiles)
        {
            tile.Show();
        }
    }
    
    public void HideTiles()
    {
        foreach (var tile in _tiles)
        {
            tile.Hide();
        }
    }
}
