using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;

    public CollectManager collectManager;

    public EnemyManager enemymanager;
    
    public bool abletomove;
    
    // Start is called before the first frame update
    void Start()
    {
      abletomove = true; 
    }

    // Update is called once per frame
    void Update()
    {
    
    if(abletomove){

    
    Vector3 newpos = transform.position;
 
    if(Input.GetKey(KeyCode.W))
    {
      
      newpos.z = newpos.z + speed * Time.deltaTime;
    }

    if(Input.GetKey(KeyCode.S))
    {
        newpos.z = newpos.z - speed * Time.deltaTime;
    }

    if(Input.GetKey(KeyCode.A))
    {
        newpos.x = newpos.x - speed * Time.deltaTime;
    }

    if(Input.GetKey(KeyCode.D))
    {
        newpos.x = newpos.x + speed * Time.deltaTime;
    }
        transform.position = newpos;
    }
   
   if(Input.GetKey(KeyCode.Space))
   {
        for(int i = 0; i<enemymanager.enemynum; i++)
    {
        if(Vector3.Distance(transform.position, enemymanager.enemies[i].transform.position) < 0.9f)
        {
           Vector3 enemypos = enemymanager.enemies[i].transform.position;
           Vector3 resetpos = new Vector3(Random.Range(-2,5), transform.position.y, Random.Range(-2,5));
           enemymanager.enemies[i].transform.position = resetpos;
        }
    }
   }
    
    }

   
  // This ontrigger function is to destroy the collectible object, when the player collides with it//
  
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {
         collectManager.collectibles.Remove(other.gameObject);
         Destroy(other.gameObject);
        }
        //pauses movement of the player//
        for(int i = 0; i<enemymanager.enemynum; i++)
            {
                if(other.gameObject == enemymanager.enemies[i])
                {
                    Debug.Log("hit");
                    abletomove = false;
                }
            }
    }

     

  
}
