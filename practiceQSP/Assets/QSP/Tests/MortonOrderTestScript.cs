using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MortonOrderTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MortonOrder_0_0()
        {
           uint morton =  ConverMortonOrder.GetMortonOrder(0,0,1,1);
            Assert.AreEqual(0,morton);
            // Use the Assert class to test conditions
        }

        [Test]
        public void MortonOrder_1_1()
        {
            uint morton = ConverMortonOrder.GetMortonOrder(1, 1, 1, 1);
            Assert.AreEqual(0b11, morton);
        }

        [Test]
        public void MortonOrder_3_1()
        {
            uint morton = ConverMortonOrder.GetMortonOrder(3, 1, 1, 1);
            Assert.AreEqual(0b0111, morton);
        }
        [Test]
        public void MortonOrderDeci_3_1()
        {
            uint morton = ConverMortonOrder.GetMortonOrder(32, 16, 10, 10);
            Assert.AreEqual(0b0111, morton);
        }

        [Test]
        public void MortonOrderSpriteRenderer_1_1()
        {
            float lengthX = 250;
            float lengthY = 125;
            GameObject obj = new GameObject();
            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer target = obj.GetComponent<SpriteRenderer>();
            target.transform.position = new Vector3(lengthX * 3, lengthY * 1,0);
            target.size = new Vector2(100, 100);

            uint morton = ConverMortonOrder.GetSpriteRendererMortonOrder(target, lengthX, lengthY);
            Assert.AreEqual(22, morton);
        }


        [Test]
        public void Test()
        {
            test  t = new test();
            t.Init();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
