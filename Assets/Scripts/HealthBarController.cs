using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private HealthModule _healthModule;
    private Camera _mainCamera;
    [SerializeField] private MeshRenderer _meshRenderer;
    private MaterialPropertyBlock _matBlock;

    private void Awake()
    {
        _healthModule.OnChangeHealth += UpdateParams;
        _matBlock = new MaterialPropertyBlock();
        _mainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        _healthModule.OnChangeHealth -= UpdateParams;
    }

    private void Update() 
    {
        AlignCamera();
    }

    private void UpdateParams(int health, int maxHealth) {
        _meshRenderer.GetPropertyBlock(_matBlock);
        _matBlock.SetFloat("_Fill", health / (float)maxHealth);
        _meshRenderer.SetPropertyBlock(_matBlock);
    }

    private void AlignCamera() {
        if (_mainCamera != null) {
            var camXform = _mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
