using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Analytics;
using System.Security.Cryptography.X509Certificates;


public class NewBehaviourScript : MonoBehaviour
{
    public List<Number> numbers;
    public List<Data> datas;

    void Start()
    {
        // 透過 LinQ 尋找 “指定值” 於一維集合中 的索引值
        IEnumerable<int> ints = numbers.Select((a, i) => i).Where(i => numbers[i] == (int)Number.one);

        foreach (var i in ints)
        {
            Debug.Log(i);
        }

        //------------------------------------------------------------------------------------------------------------
        //< 1. >算指定值出現的總數 （一維）


        int oneCount = numbers.Count(i => i == Number.one);
        Debug.Log($"OneCount : {oneCount}");


        //-----------------------------------------------------------------------------------------------------------------------
        // < 2. > 算指定值出現的總數 (二維)(整個盤面的)


        var twoCount = datas.Sum(row => row.Reels.Count(Item => Item == (int)Number.one));
        Debug.Log($"twoCount : {twoCount}");



        //-----------------------------------------------------------------------------------------------------------------------
        // < 3. > 算每個輪條 指定值出現的次數 （二維）


        var value = datas.Select((x) => x.Reels.Count(item => item == (int)Number.one));

        foreach (var index in value)
        {
            Debug.Log(index);
        }
        //-----------------------------------------------------------------------------------------------------------------------
        //< 3.5 > 算指定值位於 輪調上的索引值（二維）

        // var index2 = datas.Select((X,Y)=>Y).Where(Y=> datas[Y].Reels.Contains(Number.one)).Where(i => datas.Reels[i] == (int)Number.one);

        // foreach (var i in index2)
        // {
        //     Debug.Log($"指定值位於 輪調上的索引值{i}");
        // }

        //-----------------------------------------------------------------------------------------------------------------------
        // 算指定項目在哪個輪條（哪個輪條有指定的項目）（二維）


        var Reel = datas.Select((X, i) => i).Where(i => datas[i].Reels.Contains(Number.one));

        foreach (var i in Reel)
        {
            Debug.Log(i);
        };



        //-----------------------------------------------------------------------------------------------------------------------
        //配合 上面 找出 指定圖在輪條哪個位置（二維）（指定值位於 輪調上的索引值）


        foreach (var reel in Reel)
        {
            var index = datas[reel].Reels.Select((a, i) => i).Where(i => datas[reel].Reels[i] == (int)Number.one);
            foreach (var item in index)
            {
                Debug.Log($"{reel},{item}");
            }
        }

    }
    //-----------------------------------------------------------------------------------------------------------------------
}
public enum Number
{
    one,
    two,
    three
}

[Serializable]
public class Data
{
    public List<Number> Reels;
}

