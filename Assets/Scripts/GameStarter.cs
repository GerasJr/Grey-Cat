using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    public UnityEvent StartEvent;

    public void StartGame()
    {
        StartEvent.Invoke();
    }
}
