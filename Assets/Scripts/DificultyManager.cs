using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject flyEnemy;
    public GameObject zombieEnemy;
    public GameObject shootingEnemy;
    public GameObject enemyBullet;

    public Transform zone1;
    public Transform[] checkPointA;
    public Transform[] checkPointB;
    public Transform[] checkPointC;

    public static Transform actualCheckpoint;

    public int dificultyFactor;
    
    void Start()
    {
        //loadEnemies(checkPointA, dificultyFactor);
        

        GameObject aux = GameObject.Find("SceneMan");
        ChangeScene auxScenemanager = aux.GetComponent<ChangeScene>();
        dificultyFactor = auxScenemanager.getDifficulty();
        Debug.Log(this.dificultyFactor);
        instanciateOnZone(zone1, dificultyFactor);
    }

    public void loadEnemies(Transform[] zone, int dificultyFactor) 
    {
        foreach (Transform dot in zone) {
            instanciateOnZone(dot, dificultyFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void instanciateOnZone(Transform zone, int amount)
    {
        for (int i = 1; i<=amount; i++)
        {
            int ranX = Random.Range(-3, 4);
            int ranY = Random.Range(-3, 4);
 
            Vector3 pos = new Vector3(zone.position.x + i * ranX, zone.position.y, zone.position.z + i * ranY);
            Instantiate(zombieEnemy, pos, zone.rotation);
        }
        
        for (int i = 1; i<=amount; i++)
        {
            int ranX = Random.Range(-3, 4);
            int ranY = Random.Range(-3, 4);
            Vector3 pos = new Vector3(zone.position.x + i * ranX, zone.position.y + 8, zone.position.z + i * ranY);
            Instantiate(flyEnemy, pos, zone.rotation);
        }
        
        for (int i = 1; i<=amount; i++)
        {
            int ranX = Random.Range(-3, 4);
            int ranY = Random.Range(-3, 4);
            Vector3 pos = new Vector3(zone.position.x + i * ranX, zone.position.y, zone.position.z + i * ranY);
            Instantiate(shootingEnemy, pos, zone.rotation);
        }
        
    }


    IEnumerator respawn(int enemies, float sec, float speed)
    {
        while(true)
        {
            yield return new WaitForSeconds(sec);
        }
    }
}
