using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stratagems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField] private SpawnArrow _spawnObj;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _iconPrefab;
    [SerializeField] private GameObject _iconsSpawnPos;
    private Queue<GameObject> _tempQueue;
    private Queue<GameObject> _currentQueue;
    private Queue<GameObject> _iconsQueue;
    private List<Stratagem> _listStratagems;
    private int _indexStratagem;
    private int _playerInt = -1;
    public static bool IsActive = true;
    public Button UpButton;
    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;

    private void Start()
    {
        NewPullStratagem();
        UpButton.onClick.AddListener(() => GetInputAndCheck(0));
        DownButton.onClick.AddListener(() => GetInputAndCheck(180));
        RightButton.onClick.AddListener(() => GetInputAndCheck(270));
        LeftButton.onClick.AddListener(() => GetInputAndCheck(90));
    }

    private void Update()
    {
        PlayerInput();
    }

    private void NewPullStratagem()
    {
        _indexStratagem = 0;
        _listStratagems = _spawnObj.CreatePullStratagem();
        _currentQueue = _spawnObj.SpawnArrows(_indexStratagem++);
        StartAgain();
        SpawnIconsPull();
        var timer = _listStratagems.Select(s => s.Timer).Sum();
        Timer.Instance.StartNewTimer(timer);
    }

    private void SpawnIconsPull()
    {
        _iconsQueue = new Queue<GameObject>();
        foreach (var stratagem in _listStratagems)
        {
            _iconPrefab.GetComponent<Image>().sprite = stratagem.Icon;
             var icon = Instantiate(_iconPrefab, _iconsSpawnPos.transform.position, transform.rotation);
             _iconsQueue.Enqueue(icon); 
            icon.transform.SetParent(_iconsSpawnPos.transform);
        }
    }
    
    private void StartAgain()
    {
        _tempQueue = new Queue<GameObject>(_currentQueue);
        _scoreText.SetText($"Your Score : {Score.ScoreInt}");
    }
    
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetInputAndCheck(0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetInputAndCheck(180);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetInputAndCheck(90);
            Debug.Log("Test Git");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetInputAndCheck(270);
        }
    }

    private void GetInputAndCheck(int input)
    {
        if (IsActive && _tempQueue.Count > 0)
        {
            _playerInt = input;
            Check();
        }
    }

    private void Check()
    {
        var arrowInt = _tempQueue.Peek().GetComponent<Arrow>().ArrowInt;
        if (_playerInt == -1)
        {
            return;
        }

        else if (_playerInt == arrowInt)
        {
            _tempQueue.Dequeue().GetComponent<Image>().color = Color.yellow;
            if (_tempQueue.Count == 0)
            {
                Score.ScoreInt += 5 * _currentQueue.Count;
                NextStratagem();
            }
        }
        else
        {
            WrongChooseAsync();
        }
        _playerInt = -1;
    }

    private async void NextStratagem()
    {
        await Task.Delay(700);
        Destroy(_iconsQueue.Dequeue());
        foreach (var arrow in _currentQueue)
        {
            Destroy(arrow);
        }
        if (_indexStratagem < _listStratagems.Count)
        {
            _currentQueue = _spawnObj.SpawnArrows(_indexStratagem++);
            StartAgain();
        }
        else
        {
            NewPullStratagem();
        }
    }

    private async void WrongChooseAsync()
    {
        foreach (var arrow in _currentQueue)
        {
            arrow.GetComponent<Image>().color = Color.red;
            IsActive = false;
        }
        await Task.Delay(700);
        foreach (var arrow in _currentQueue)
        {
            arrow.GetComponent<Image>().color = Color.white;
            IsActive = true;
        }
        StartAgain();
    }
}
