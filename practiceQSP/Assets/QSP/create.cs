using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    private List<GameObject> lists = new List<GameObject>();
    private MortonCollision myCollision = new MortonCollision();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform ts in this.transform)
        {
            lists.Add(ts.gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        myCollision.Clear();
        foreach (var obj in lists)
        {
            myCollision.Register(obj.GetComponent<SpriteRenderer>());
        }
        myCollision.Collision(0,(left, right) => {
            Debug.Log("Hitしました");
            return 1;
        });

    }
}
