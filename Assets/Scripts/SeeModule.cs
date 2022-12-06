using System;
using UnityEngine;

public class SeeModule : MonoBehaviour
{
    private GameObject _target;
    private string _tag;
    public Action<Transform> OnTargetMove;

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
            _target = coll.gameObject;
            OnTargetMove?.Invoke(_target.transform);
        }
    }

    private void OnEnable()
    {
        _target = null;
    }
}
