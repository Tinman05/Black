using UnityEngine;

public class BlackholePerSecondTimer : MonoBehaviour
{
    public float TimerDuration = 1f;

    public double BlackholePerSecond { get; set; }
    private float _counter;

    private void Update()
    {
        _counter += Time.deltaTime;
        if (_counter >= TimerDuration)
        {
            BlackholeManager.instance.SimpleBlackholeIncrease(BlackholePerSecond);

            _counter = 0;
        }
    }
}
