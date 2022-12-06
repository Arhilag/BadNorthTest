using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class EnemySquad : Squad
{
    [SerializeField] [HideInInspector]private ListHouse _listHouse;
    [SerializeField] private float _timeToSwim;
    private Vector3 _swimTarget;
    
    protected override void AddStart()
    {
        foreach (var unit in _units)
        {
            unit.EnableNavMesh(false);
            unit.transform.SetParent(transform);
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_swimTarget, _timeToSwim));
        sequence.OnComplete(GetOffTheShip);
    }

    public void SetSwimTarget(Vector3 target)
    {
        _swimTarget = target;
    }
    
    private void OnDestroy()
    {
        if (_listHouse.Houses.Length > 0)
        {
            HouseAI.OnDestroyHouse -= SetTarget;
        }
    }

    private void GetOffTheShip()
    {
        foreach (var unit in _units)
        {
            unit.transform.SetParent(null);
            unit.EnableNavMesh(true);
        }

        SetTarget();
    }
    
    public void SetListTarget(ListHouse listHouse)
    {
        _listHouse = listHouse;
        HouseAI.OnDestroyHouse += SetTarget;
    }

    private async void SetTarget()
    {
        await Task.Delay(1000);
        if (!Application.isPlaying)
        {
            return;
        }
        foreach (var house in _listHouse.Houses)
        {
            if (house.gameObject.activeSelf == true)
            {
                MoveToPanel(house.position);
                break;
            }
        }
    }
}
