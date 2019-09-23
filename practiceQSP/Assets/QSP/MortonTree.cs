using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortonTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TreeObject <T>
{
    public List<T> haveObjects = new List<T>();
    public List<TreeObject<T>> pNext = new List<TreeObject<T>>();
    public List<TreeObject<T>> pPrev = new List<TreeObject<T>>();

    
}

public class test
{
    public void Init()
    {
        var root = new TreeObject<SpriteRenderer>();
        

    }
}