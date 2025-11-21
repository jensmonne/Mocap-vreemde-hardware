using AscentProtocol.SceneManagement;
using UnityEngine;

public class StopTriggers : MonoBehaviour
{
    [SerializeField] private PointGroup pointGroup;
    [SerializeField] private bool hasGroup = true;

    private void Start()
    {
        if (pointGroup == null && hasGroup)
        {
            pointGroup = FindAnyObjectByType<PointGroup>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        SceneObjectRegistry.Instance.Get("Player").GetComponentInChildren<PlayerMover>().StopMovement();
        if (pointGroup == null && hasGroup) return;
        pointGroup.EnablePoints();
    }
}