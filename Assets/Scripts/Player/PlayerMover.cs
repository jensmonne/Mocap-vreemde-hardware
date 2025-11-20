using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("Movement")]
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private float moveDistance = 3f;
    
    private Coroutine moveRoutine;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerStop")) return;
        
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
            moveRoutine = null;
        }
    }

    public void MovePlayer()
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);

        moveRoutine = StartCoroutine(LerpMove());
    }
    
    private System.Collections.IEnumerator LerpMove()
    {
        Vector3 startPos = player.position;
        Vector3 endPos = startPos + player.forward * moveDistance;

        float t = 0f;

        while (t < moveDuration)
        {
            t += Time.deltaTime;
            float lerpValue = t / moveDuration;

            player.position = Vector3.Lerp(startPos, endPos, lerpValue);

            yield return null;
        }

        player.position = endPos;
        moveRoutine = null;
    }
}