using System;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private ActiveObject _activeObject;
    [SerializeField] private GameObject _mesh;
    public static Action<ActiveObject, Panel> OnSelectObject;
    public static Action<Vector3, Panel> OnSelectPanel;

    public void Select()
    {
        if (_activeObject != null)
        {
            OnSelectObject?.Invoke(_activeObject, this);
        }
        else
        {
            OnSelectPanel?.Invoke(transform.position, this);
        }
    }

    public void SetActiveObject(ActiveObject obj)
    {
        _activeObject = obj;
    }
    
    public void ResetActiveObject()
    {
        _activeObject = null;
    }

    public void Show()
    {
        _mesh.SetActive(true);
    }
    
    public void Hide()
    {
        _mesh.SetActive(false);
    }
}
