using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointC : MonoBehaviour
{
    public Transform[] checkPointB;
    public GameObject boss;
    private DificultyManager manager;
    public AudioSource aso;
    public AudioClip ac;
    private bool flagBoss;


    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        flagBoss = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            if (flagBoss) {
                aso.Play();
                flagBoss = false;
            }
            Debug.Log("OnTriggerEnter");
            //DificultyManager.actualCheckpoint = this.transform;
            //manager.loadEnemies(checkPointB, manager.dificultyFactor);
            boss.GetComponent<Boss>().StartCoroutine("CreateEnemies");
        }
    }
}
