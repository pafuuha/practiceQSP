using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConverMortonOrder 
{
    /// <summary>
    /// モートン順列を返す
    /// </summary>
    /// <param name="x">Xの座標</param>
    /// <param name="y">Yの座標</param>
    /// <param name="lengthX">１単位のXの長さ</param>
    /// <param name="lengthY">１単位のYの長さ</param>
    /// <returns></returns>
    public static uint GetMortonOrder(float x, float y, int lengthX, int lengthY)
    {
        int numX = (int)x / lengthX;
        int numY = (int)y / lengthY;
        

        return bitSeparate((uint)numX) | bitSeparate((uint)numY) << 1;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="lengthX"></param>
    /// <param name="lengthY"></param>
    /// <returns></returns>
    public static uint GetSpriteRendererMortonOrder(SpriteRenderer target, int lengthX, int lengthY)
    {

        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;

        float targetW = target.size.x;
        float targetH = target.size.y;

        uint mortonOrderLeftUp = GetMortonOrder(targetX - targetW / 2, targetY - targetH / 2, lengthX, lengthY);
        uint mortonOrderRightDown = GetMortonOrder(targetX + targetW / 2, targetY - targetH / 2, lengthX, lengthY);

        return mortonOrderLeftUp & mortonOrderRightDown;
    }

    private static uint bitSeparate(uint inp)
    {
        inp = (inp | (inp << 8)) & 0x00ff00ff;
        inp = (inp | (inp << 4)) & 0x0f0f0f0f;
        inp = (inp | (inp << 2)) & 0x33333333;
        inp = (inp | (inp << 1)) & 0x55555555;
        return inp;
    }
}
