using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    [SerializeField] private Image _timerImage;
    private float _timer;
    private float _maxTimer;
    public float TimerVal
    {
        get { return _timer; }
        set {
            if (value > 3)
            {
                _timer = value;
            }
        }
    }

    public static Timer Instance => instance;

    private void Awake()
    {
        instance = this;
    }

   private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _timerImage.fillAmount = _timer/_maxTimer;
            if (_timer < _maxTimer/100 * 30)
            {
                _timerImage.color = Color.red;
            }
        }
        else
        {
            StopGame();
        }
    }

    public void StartNewTimer(float maxValue)
    {
        _timerImage.color = Color.yellow;
        _timer = maxValue;
        _maxTimer = maxValue;
    }

    public void StopGame()
    {
        Play.IsActive = false;
    }
}
