using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointB : MonoBehaviour
{
    public Transform[] checkPointB;
    
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
            manager.loadEnemies(checkPointB, manager.dificultyFactor);
        }
    }
}
