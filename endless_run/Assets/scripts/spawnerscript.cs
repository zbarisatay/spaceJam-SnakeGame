using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public player PlayerScript;
    public GameObject Obstacle;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
        while (!PlayerScript.isDead)
        {
            Instantiate(Obstacle, new Vector3(11, Random.Range(-3.85f, 3.85f), 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

}
