using System;
using UnityEngine;

public class FightModule : MonoBehaviour
{
    private AIObject _target;
    public Action<AIObject, Transform> OnTargetFight;
    private string _tag;

    private void Awake()
    {
        _tag = gameObject.transform.parent.tag;
    }
    
    private void OnTriggerStay(Collider coll)
    {
        if (_target == null && 
            ((coll.tag=="Enemy"&&_tag=="Player")||
             (coll.tag=="Player"&&_tag=="Enemy")||
             (coll.tag=="House"&&_tag=="Enemy")))
        {
            _target = coll.gameObject.GetComponent<AIObject>();
            OnTargetFight?.Invoke(_target, coll.transform);
        }
    }

    private void OnEnable()
    {
        _target = null;
    }
}
