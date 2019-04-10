using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyChild : MonoBehaviour
{

    public GameObject enemyfly;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            EnemyFly aux = enemyfly.GetComponent<EnemyFly>();
            aux.activateCoroutine();
        }
 
    }
}
