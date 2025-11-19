using UnityEngine;

public class NextPose : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private GameObject button;
    private int index = 0;

    public void Next()
    {
        if (index == 0)
        {
            button.SetActive(false);
            StartCoroutine(LerpPlayerZ(8.5f));
        }
        else if (index == 1)
        {
            
        }
        
        index++;
    }
    
    private System.Collections.IEnumerator LerpPlayerZ(float targetZ)
    {
        Vector3 startPos = player.position;
        Vector3 endPos = new Vector3(startPos.x, startPos.y, targetZ);

        float t = 0f;

        while (t < moveDuration)
        {
            t += Time.deltaTime;
            float lerpValue = t / moveDuration;

            player.position = Vector3.Lerp(startPos, endPos, lerpValue);

            yield return null;
        }

        player.position = endPos;
    }
}
