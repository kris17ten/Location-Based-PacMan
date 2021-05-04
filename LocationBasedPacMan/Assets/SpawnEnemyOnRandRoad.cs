using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemyOnRandRoad : MonoBehaviour
{
    public GameObject enemy;
    private GameObject[] roads = new GameObject[0];
    private GameObject[] land = new GameObject[0];
    private GameObject[] buildings = new GameObject[0];
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Wait");
        //GameObject spawnRoad = roads[2];

        //Debug.Log(spawnRoad.name);

        //Instantiate(enemy, new Vector3(spawnRoad.transform.position.x, 0, spawnRoad.transform.position.z), enemy.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roads.Length < 1)
        {
            StartCoroutine("Wait");
        }
        if (!spawned)
        {
            GameObject spawnRoad = roads[Random.Range(0, roads.Length-1)];
            
            Debug.Log(GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(spawnRoad.transform.position));

            //make roads walkable ?
            foreach (GameObject road in roads)
            {
                road.AddComponent<NavMeshSurface>();
                road.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
            foreach (GameObject lan in land)
            {
                lan.AddComponent<NavMeshSurface>();
                lan.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
            foreach (GameObject building in buildings)
            {
                building.AddComponent<NavMeshSurface>();
                building.GetComponent<NavMeshSurface>().defaultArea = 1;
                building.GetComponent<NavMeshSurface>().BuildNavMesh();
            }

            //Instantiate(enemy, new Vector3(spawnRoad.transform.position.x, 0, spawnRoad.transform.position.z), enemy.transform.rotation);
            Vector3 spawnPoints = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(spawnRoad.transform.position);
            Instantiate(enemy, new Vector3(9,6,15), enemy.transform.rotation);
            spawned = true;
        }
    }

    IEnumerator Wait()
    {
        int w = 1000;
        while(w > 0)
        {
            w--;
        }
        roads = GameObject.FindGameObjectsWithTag("road");
        land = GameObject.FindGameObjectsWithTag("land");
        buildings = GameObject.FindGameObjectsWithTag("building");
        yield return new WaitForSeconds(5.0f);
    }
}
