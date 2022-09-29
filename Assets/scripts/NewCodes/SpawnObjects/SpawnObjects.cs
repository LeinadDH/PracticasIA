using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Spawner Dependencies")]
    private GameObject Spawner;
    public GameObject collectable;
    public List<GameObject> collectables;
    public int numberOfEnemies;
    private float thirdPart, twoPart;
    private float objectInFollow;
    public GameObject player;
    public List<GameObject> enemies;

    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
        numberOfEnemies = Random.Range(20, 40);
    }

    void Update()
    {
        if (collectables.Count < numberOfEnemies)
        {
            Vector3 randomPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
            Spawner = Instantiate(collectable, randomPos, Quaternion.identity) as GameObject;
            Spawner.transform.parent = this.gameObject.transform;
            collectables.Add(GameObject.FindGameObjectWithTag("collectable"));
        }


        thirdPart = Mathf.Round(numberOfEnemies * 0.3f);
        Debug.Log("La tercera parte de objetos: " + thirdPart);
        objectInFollow = player.GetComponent<Player>().collectables.Count;
        Debug.Log("Objetos siguiendo al player: " + objectInFollow);

        foreach (var followcode in GetComponentsInChildren<FollowObject>())
        {
            followcode.enableFlee = false;
            if (objectInFollow >= thirdPart) followcode.enableFlee = true;
        }

        twoPart = Mathf.Round(numberOfEnemies * 0.6f);
        Debug.Log("La tercera parte de objetos: " + twoPart);
            
        if(objectInFollow >= twoPart)
        {
            foreach (var avoidCode in GetComponentsInChildren<AvoidWalls>())
            {
                avoidCode.enableAvoid = true;        
            }
            if(enemies.Count < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    player.GetComponent<Player>().collectables.Peek().GetComponent<FollowObject>().enablePursuit = true;
                    player.GetComponent<Player>().collectables.Dequeue();
                    enemies.Add(GameObject.FindGameObjectWithTag("Enemy"));
                }
                foreach (var stearingCode in GetComponentsInChildren<SteeringBehaviors>())
                {
                    stearingCode.distanceBehind = stearingCode.distanceBehind - 3;
                }
            }
        }
        if (objectInFollow < twoPart)
        {
            foreach (var avoidCode in GetComponentsInChildren<AvoidWalls>())
            {
                avoidCode.enableAvoid = false;
            }
        }

        if(numberOfEnemies - 3 == player.GetComponent<Player>().collectables.Count)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("End Game");
        }
    }
}
