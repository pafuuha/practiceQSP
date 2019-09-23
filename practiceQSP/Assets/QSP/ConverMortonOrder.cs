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
    public static uint GetMortonOrder(float x, float y, float lengthX, float lengthY)
    {
        int numX = (int)(x / lengthX);
        int numY = (int)(y / lengthY);
        

        return bitSeparate((uint)numX) | bitSeparate((uint)numY) << 1;
    }
    /// <summary>
    /// SpriteRendererのモートン順列を返す
    /// </summary>
    /// <param name="target"></param>
    /// <param name="lengthX"></param>
    /// <param name="lengthY"></param>
    /// <returns></returns>
    public static uint GetSpriteRendererMortonOrder(SpriteRenderer target, float lengthX, float lengthY)
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;

        float targetW = target.size.x;
        float targetH = target.size.y;

        uint mortonOrderLeftUp = GetMortonOrder(targetX - targetW / 2, targetY - targetH / 2, lengthX, lengthY);
        uint mortonOrderRightDown = GetMortonOrder(targetX + targetW / 2, targetY + targetH / 2, lengthX, lengthY);

        // 排他的論理和
        uint cal = mortonOrderLeftUp ^ mortonOrderRightDown;

        // 最上位ビットの位を取得
        int msb_num = getMSBNumber(mortonOrderLeftUp ^ mortonOrderRightDown);

        // いくつ動かせばいいかを計算
        int shift_bit = (((int)msb_num / 2) + 1) * 2;

        // レベルを計算
        int mortonLevel = 4 - shift_bit / 2;

        // いくつ足せばいいかの定数
        int[] mortonLiner = { 0, 5,  21, 85};
        
        return (mortonOrderRightDown >> shift_bit) + (uint)mortonLiner[mortonLevel - 1];
    }

    private static int getMSBNumber(uint mortonXor)
    {
        int msb_num = 0;
        int num = 0;
        while (num < 6)
        {
            if ((mortonXor & ((uint)1 << num)) == ((uint)1 << num))
            {
                msb_num = num;
            }
            num++;
        }
        return msb_num / 2;

    }

    private static uint bits_msb(uint v)
    {
        v = v | (v >> 1);
        v = v | (v >> 2);
        v = v | (v >> 4);
        v = v | (v >> 8);
        v = v | (v >> 16);
        return v ^ (v >> 1);
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
