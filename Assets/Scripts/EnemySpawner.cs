using System;
using UnityEngine;

/// <summary>
/// From a list of random spawn areas, select one at random and then spawn enemy(s) randomly within the area
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnAreas;
    [SerializeField] GameObject _enemy;
    [SerializeField] int _enemiesToSpawn;
    SphereCollider _areaCollider;     
    int _nextSpawnArea;

    // Start is called before the first frame update
    void Start()
    {
        _nextSpawnArea = _spawnAreas.Length - 1; //Start with last area  
        //_areaCollider = _spawnAreas[_nextSpawnArea].GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(_enemiesToSpawn > 0) //If there enemies still to spawn
            {
                _enemiesToSpawn--;              
               
                SpawnEnemy();

                if(_nextSpawnArea <= 0)
                {
                    _nextSpawnArea = _spawnAreas.Length - 1; //Loop
                }
                else
                {
                    _nextSpawnArea--; //Next spawn area
                }
            }
        }
    }

    /// <summary>
    /// Place an agent randomly within a given area
    /// </summary>
    void SpawnEnemy()
    {
        var areaCollider = _spawnAreas[_nextSpawnArea].GetComponentInChildren<SphereCollider>();

        float radius = areaCollider.radius * _spawnAreas[_nextSpawnArea].transform.localScale.x; //Collider radius * Mesh Scale
        float a = UnityEngine.Random.Range(0, 101) * 0.01f * 2 * Mathf.PI;
        float r = radius * Mathf.Sqrt(UnityEngine.Random.Range(0, 101) * 0.01f);
        float x = r * Mathf.Cos(a);
        float z = r * Mathf.Sin(a);

        var currentEnemy = Instantiate(_enemy, new Vector3(_spawnAreas[_nextSpawnArea].transform.position.x + x, 1, _spawnAreas[_nextSpawnArea].transform.position.z + z), Quaternion.identity);

        //var sphere = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
        //sphere.transform.localPosition = new Vector3(_spawnAreas[_nextSpawnArea].transform.position.x + x, 0, _spawnAreas[_nextSpawnArea].transform.position.z + z);
        //Debug.Log($"Random Number: {randomNumber} | Theta: {a} | X: {x} | Y: {z}");
    }
}
