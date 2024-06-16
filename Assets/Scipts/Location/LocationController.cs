using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    [Header("Complexity")]
    [SerializeField] private GameObject[] _PipePrefabsByComplexity;
    [SerializeField] private float[] _PipeYaxisSpawnMaxValueByComplexity;
    [SerializeField] private float[] _PipeYaxisSpawnMinValueByComplexity;
    [SerializeField] private float[] _PipeMovementSpeedByComplexity;

    [Space]
    [Header("Settings")]
    [SerializeField] private GameObject _PipePrefab;
    [SerializeField] private Transform _PipePoolParent;
    [SerializeField] private Queue<GameObject> _PipesPool = new Queue<GameObject>();
    private List<GameObject> _ActivePipes = new List<GameObject>();
    private bool _isMove;
    [SerializeField] private float _MoveSpeed;
    [SerializeField] private float _PipeYaxisSpawnMaxValue;
    [SerializeField] private float _PipeYaxisSpawnMinValue;
    [SerializeField] private float _PipeXAxisLimit;
    [SerializeField] private float _PipeSpawnTimeInSeconds;

    private void LoadPipesPool()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject pipe = Instantiate(_PipePrefab);
            pipe.transform.SetParent(_PipePoolParent);
            _PipesPool.Enqueue(pipe);
            pipe.gameObject.SetActive(false);
        }
    }
    private void ClearPipesPool()
    {
        int Length = _PipesPool.Count;
        for (int i = 0; i < Length; i++)
        {
            GameObject pipe = _PipesPool.Dequeue();
            Destroy(pipe);
        }
    }
    private void SpawnPipe()
    {
        GameObject pipe = _PipesPool.Dequeue();
        _ActivePipes.Add(pipe);
        pipe.transform.position = new Vector2(-5f, Random.Range(_PipeYaxisSpawnMinValue, _PipeYaxisSpawnMaxValue));
        pipe.SetActive(true);
    }
    public void StartMovement()
    {
        StartCoroutine(SpawnTimer());
        _isMove = true;
    }
    public void StopMovement()
    {
        StopAllCoroutines();
        _isMove = false;
    }
    public void Restart()
    {
        foreach (var pipe in _ActivePipes)
        {
            _PipesPool.Enqueue(pipe);
            pipe.gameObject.SetActive(false);
        }
        _ActivePipes.Clear();
    }
    private void FixedUpdate()
    {
        if (_isMove)
        {
            foreach (var pipe in _ActivePipes)
            {
                pipe.transform.Translate(Vector3.right * _MoveSpeed * Time.deltaTime);
                if (pipe.transform.position.x >= _PipeXAxisLimit)
                {
                    _ActivePipes.Remove(pipe);
                    pipe.SetActive(false);
                    _PipesPool.Enqueue(pipe);
                    break;
                }
            }
        }
    }
    IEnumerator SpawnTimer()
    {
        SpawnPipe();
        yield return new WaitForSeconds(_PipeSpawnTimeInSeconds);
        StartCoroutine(SpawnTimer());
    }
    public void ChangeComplexity(int ComplexityId)
    {
        _PipePrefab = _PipePrefabsByComplexity[ComplexityId];
        ClearPipesPool();
        LoadPipesPool();
        _PipeYaxisSpawnMaxValue = _PipeYaxisSpawnMaxValueByComplexity[ComplexityId];
        _PipeYaxisSpawnMinValue = _PipeYaxisSpawnMinValueByComplexity[ComplexityId];
        _MoveSpeed = _PipeMovementSpeedByComplexity[ComplexityId];
    }
}

