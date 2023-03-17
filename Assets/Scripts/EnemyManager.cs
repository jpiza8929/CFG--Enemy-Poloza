using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //make an array of gameobjects called enemies//
    public GameObject[] enemies;
  
    public GameObject enemyprefab;

    public Transform leftTop;
    public Transform rightBottom;
    
    public int enemynum;
    
    // Start is called before the first frame update
    void Start()
    {
      enemies = new GameObject[enemynum];
        for(int i = 0; i< enemynum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newpos = new Vector3(newX, transform.position.y, newZ);
            GameObject newEnemy = Instantiate(enemyprefab, newpos, Quaternion.identity);
            enemies[i] = newEnemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
