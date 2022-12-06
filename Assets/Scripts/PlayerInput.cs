using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300, _mask))
            {
                if (hit.transform.TryGetComponent<Panel>(out Panel panel))
                {
                    panel.Select();
                }
            }
        }
    }
}
