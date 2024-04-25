using System.Collections.Generic;
using Stratagems;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private GameObject _goSpawnPos;
    [SerializeField] private float _xOffset = 114;
    private List<Stratagem> listStratagems;
    private Queue<GameObject> ArrowsQueue;
    private int _length;
    private float _startPos;
    public List<Stratagem> ConfigStratagems;

    public Queue<GameObject> SpawnArrows(int index)
    {
        if (listStratagems.Count == 0)
        {
            Debug.Log("Lox");
            return null;
        }
        var pos = _goSpawnPos.transform.position;
        var stratagem = listStratagems[index];
        ArrowsQueue = new Queue<GameObject>();
        for (int i = 0; i < stratagem.Arrows.Length; i++)
        {
            var arrow = Instantiate(_arrowPrefab, pos, Quaternion.Euler(0,0,stratagem.Arrows[i]));
            ArrowsQueue.Enqueue(arrow);
            arrow.transform.SetParent(_goSpawnPos.transform);
            pos.x += _xOffset;
        }
        return ArrowsQueue;
    }
    
    public List<Stratagem> CreatePullStratagem()
    {
        listStratagems = new List<Stratagem>();
        for (int i = 0; i < Random.Range(1,10); i++)
        {
            var randomIndex = Random.Range(0, ConfigStratagems.Count);
            var stratagem = ConfigStratagems[randomIndex];
            listStratagems.Add(stratagem);
            
        }
        return listStratagems;
    }
}
