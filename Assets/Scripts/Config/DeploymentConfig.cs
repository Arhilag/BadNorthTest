using UnityEngine;

[CreateAssetMenu(fileName = "Deployment", menuName = "ScriptableObjects/DeploymentConfig", order = 0)]
public class DeploymentConfig : ScriptableObject
{
    [SerializeField] private Vector3[] _positions;
    public Vector3[] Positions => _positions;
}
