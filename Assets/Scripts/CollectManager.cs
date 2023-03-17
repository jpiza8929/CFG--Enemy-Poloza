using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
  
  public Transform leftTop;
  public Transform rightBottom;
 
  public List<GameObject> collectibles = new List<GameObject>();

   public GameObject item;
  // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 7; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newpos = new Vector3(newX, transform.position.y, newZ);
            GameObject enemy = Instantiate(item, newpos, Quaternion.identity);
            collectibles.Add(enemy);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(collectibles.Count);  
    }

}
