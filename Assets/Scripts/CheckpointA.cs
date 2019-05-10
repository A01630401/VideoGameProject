using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointA : MonoBehaviour
{
    public Transform[] checkPointA;
    
    public DificultyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            DificultyManager.actualCheckpoint = this.transform;
            manager.loadEnemies(checkPointA, manager.dificultyFactor);
        }
    }
}
