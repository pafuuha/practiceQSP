using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MortonCell<T>
{
    public List<T> Objects;

    public MortonCell()
    {
        Init();
    }

    public void Init()
    {
        if (Objects == null)
            Objects = new List<T>();
    }

    public void Refresh()
    {
        if (Objects != null)
            Objects.Clear();
    }
}


public class MortonCollision
{
    public int maxElm = 100;
    public MortonCell<SpriteRenderer>[] cells = new MortonCell<SpriteRenderer>[100];

    public List<SpriteRenderer> stackCollisionList = new List<SpriteRenderer>();
    float lengthX = 250;
    float lengthY = 125;
    public MortonCollision()
    {
        
    }

    public void Register(SpriteRenderer target)
    {

        uint targetMorton = ConverMortonOrder.GetSpriteRendererMortonOrder(target, lengthX, lengthY);
        if (cells[targetMorton] == null)
        {
            Debug.Log("新規登録" + targetMorton);
            cells[targetMorton] = new MortonCell<SpriteRenderer>();
        }
        cells[targetMorton].Objects.Add(target);
    }

    public void Collision(int elem)
    {
        if (elem >= maxElm )
            return;


        Debug.Log(elem);

        // 同じ層同士の衝突
        if (cells[elem] != null)
        {
            
            for (int i = cells[elem].Objects.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // ここに衝突判定
                    Debug.Log(elem + " ; " + cells[elem].Objects.Count + " : " + i +  ":" + j);
                    Logic();
                }

                foreach (var stackObj in stackCollisionList)
                {
                    //ここに衝突
//                    Logic();
                }
            }
        }

        bool bAddObjeToStack = false;
        int objNum = 0;
        // 下に何かある場合
        for (int i = 0; i < 4; i++)
        {
            int nextElem = elem * 4 + 1 + i;
            if ( nextElem < maxElm - 1 && cells[nextElem] != null &&  cells[nextElem].Objects?.Count > 0)
            {
                if (bAddObjeToStack == false)
                {
                    // スタックに追加
                    foreach (var thisObj in cells[nextElem].Objects)
                    {
//                        stackCollisionList.Add(thisObj);
                    }
                    objNum++;
                }
                bAddObjeToStack = true;
            }
            Collision(nextElem);
        }

        // スタックを削除
        if (bAddObjeToStack)
        {
            /*
            for (int i = 0; i < objNum; i++)
                stackCollisionList.RemoveAt(stackCollisionList.Count - 1);
                */
        }

    }

    public void Logic()
    {
        Debug.Log("Hit");
    }
}





public class test
{
    MortonCell<SpriteRenderer>[] cells = new MortonCell<SpriteRenderer>[100];
    public void Init()
    {

        float lengthX = 250;
        float lengthY = 125;

        GameObject obj = new GameObject();
        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer target = obj.GetComponent<SpriteRenderer>();
        target.transform.position = new Vector3(lengthX * 3, lengthY * 1, 0);
        target.size = new Vector2(100, 100);


        // 登録
        uint targetMorton = ConverMortonOrder.GetSpriteRendererMortonOrder(target, lengthX, lengthY);
        if (cells[targetMorton] == null)
        {
            cells[targetMorton] = new MortonCell<SpriteRenderer>();
            cells[targetMorton].Objects = new List<SpriteRenderer>();
        }
        cells[targetMorton].Objects.Add(target);
        
        

    }
}