using UnityEngine;

public class StopwatchBehaviour: MonoBehaviour
{
    private float _currentTime;
    private bool _stopped;

    void Start()
    {
        _stopped = false;
        _currentTime = 0f;
    }

    void Update()
    {
        if(!_stopped) _currentTime += Time.deltaTime;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }

    public void StopTimer()
    {
        _stopped = true;
    }
}
