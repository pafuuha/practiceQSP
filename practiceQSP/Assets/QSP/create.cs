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


        foreach (var obj in lists)
        {
            myCollision.Register(obj.GetComponent<SpriteRenderer>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        myCollision.Collision(0);

    }
}
