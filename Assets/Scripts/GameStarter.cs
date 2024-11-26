using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    public UnityEvent StartEvent;

    private void Start()
    {
        //SwipeDetection.TapEvent += StartGame;
    }

    public void StartGame()
    {
        StartEvent.Invoke();
        //SwipeDetection.TapEvent -= StartGame;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //SwipeDetection.TapEvent -= StartGame;
    }
}
