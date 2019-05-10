using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool flagCreate;
    public GameObject troll;
    public GameObject[] path;
    public GameObject enemyFly;
    public GameObject zombie;
    private bool flag;
    private int current;
    public AudioSource aso;
    public AudioClip ac;
    private int bossLife;
    // Start is called before the first frame update
    void Start()
    {
        aso.clip = ac;
        flagCreate = false;
        flag = true;
        current = 0;
        StartCoroutine("Disappear");
        bossLife = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagCreate) {
            StartCoroutine("CreateEnemies");
        }
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        if (Vector3.Distance(transform.position, path[current].transform.position) < 0.1f) {
            current = Random.Range(0, path.Length);
        }
    }

    IEnumerator Disappear() {
        while(true) {
            flagCreate = false;
            flag = !flag;
            troll.active = flag;
            //troll.GetComponent<MeshRenderer>().enabled = flag;
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator CreateEnemies() {
        while(true) {
            Vector3 position = new Vector3(Random.Range(gameObject.transform.position.x - 10, gameObject.transform.position.x + 10), 10, Random.Range(gameObject.transform.position.z - 10, gameObject.transform.position.z + 10));
            Quaternion rotation = new Quaternion(gameObject.transform.rotation.w, gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            Instantiate(enemyFly, position, rotation);
            Vector3 zombiePosition = new Vector3(Random.Range(gameObject.transform.position.x - 10, gameObject.transform.position.x + 10), 0, Random.Range(gameObject.transform.position.z - 10, gameObject.transform.position.z + 10));

            Instantiate(zombie, zombiePosition, transform.rotation);
            yield return new WaitForSeconds(5);
        }
    }


    public void dead() {
        Debug.Log("Dead");
        bossLife--;

        if (bossLife <= 0) {

            Destroy(GameObject.Find("CheckPoint C"));
            Destroy(this.gameObject);



            GameObject aux = GameObject.Find("SceneMan");
            ChangeScene auxScenemanager = aux.GetComponent<ChangeScene>();
            Destroy(aux);
            auxScenemanager.loadsScene(3);
        }
    }
}
