using System;
using UnityEngine;

/// <summary>
/// From a list of random spawn areas, select one at random and then spawn enemy(s) randomly within the area
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnAreas;
    [SerializeField] int _enemiesToSpawn;    
    CapsuleCollider _areaCollider;
    int _areaToSpawnIn;

    // Start is called before the first frame update
    void Start()
    {
        _areaCollider = _spawnAreas[0].GetComponentInChildren<CapsuleCollider>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(_enemiesToSpawn > 0) 
            {
                _enemiesToSpawn--;
                _areaToSpawnIn = _enemiesToSpawn; //Lazy - Create random area to spawn in and remove from pool (if each area is only to be used once)

                GetRandomPoint();
            }
        }
    }

    void GetRandomPoint()
    {
        float randomNumber = UnityEngine.Random.Range(0, 101) * 0.01f;
        float radius = _areaCollider.radius * _spawnAreas[_areaToSpawnIn].transform.localScale.x;
        float a = (UnityEngine.Random.Range(0, 101) * 0.01f) * 2 * Mathf.PI;
        float r = radius * Mathf.Sqrt((UnityEngine.Random.Range(0, 101) * 0.01f));
        float x = r * Mathf.Cos(a);
        float z = r * Mathf.Sin(a);
        //Debug.Log($"Random Number: {randomNumber} | Theta: {a} | X: {x} | Y: {z}");
        
        //Replace sphere with enemy prefab
        var sphere = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
        sphere.transform.localPosition = new Vector3(_spawnAreas[_areaToSpawnIn].transform.position.x + x, 0, _spawnAreas[_areaToSpawnIn].transform.position.z + z);
    }
}
