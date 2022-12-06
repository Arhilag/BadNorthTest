using UnityEngine;

public class InterpreterPlayerInput : MonoBehaviour
{
    [SerializeField] private Map _map;
    private ActiveObject _firstSelected;
    private ActiveObject _secondSelected;
    private Panel _firstPanel;

    private void Awake()
    {
        Panel.OnSelectObject += OnSelectObject;
        Panel.OnSelectPanel += OnSelectPanel;
    }

    private void OnDestroy()
    {
        Panel.OnSelectObject -= OnSelectObject;
        Panel.OnSelectPanel -= OnSelectPanel;
    }
    
    private void OnSelectObject(ActiveObject obj, Panel panel)
    {
        if (_firstSelected == null)
        {
            _firstSelected = obj;
            _firstPanel = panel;
            _map.ShowTiles();
        }
        else
        {
            _secondSelected = obj;
            _firstSelected.MoveToPanel(panel.transform.position);
            panel.SetActiveObject(_firstSelected);
            _secondSelected.MoveToPanel(_firstPanel.transform.position);
            _firstPanel.SetActiveObject(_secondSelected);
            _map.HideTiles();
            ResetSelect();
        }
    }

    private void OnSelectPanel(Vector3 position, Panel panel)
    {
        if (_firstSelected != null)
        {
            _firstSelected.MoveToPanel(position);
            panel.SetActiveObject(_firstSelected);
            _firstPanel.ResetActiveObject();
            _map.HideTiles();
            ResetSelect();
        }
    }

    private void ResetSelect()
    {
        _firstSelected = null;
        _secondSelected = null;
        _firstPanel = null;
    }
}
