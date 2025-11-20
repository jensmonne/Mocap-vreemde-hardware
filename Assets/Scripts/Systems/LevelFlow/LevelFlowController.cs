using System.Collections;
using UnityEngine;

public class LevelFlowController : MonoBehaviour
{
    public FlowState state = FlowState.LoadingPose;
    
    private int poseIndex = 0;
    private int sceneIndex = 0;

    private void Start()
    {
        StartCoroutine(RunFlow());
    }

    private IEnumerator RunFlow()
    {
        while (true)
        {
            switch (state)
            {
                case FlowState.LoadingPose:
                    break;
                case FlowState.WaitingForPlayerPose:
                    yield return new WaitUntil(() => PointManager.Instance.PlayerHasCompletedPose);
                    state = FlowState.PoseCompleted;
                    break;
                case FlowState.PoseCompleted:
                    state = FlowState.PlayingAnimations;
                    break;
                case FlowState.PlayingAnimations:
                    state = FlowState.MovingPlayer;
                    break;
                case FlowState.MovingPlayer:
                    
                    break;
                case FlowState.LoadingNextScene:
                    break;
            }

            yield return null;
        }
    }
}
