using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinQTest2 : MonoBehaviour
{

    List<int>[] ints1 = new List<int>[3]
  {
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 6, 7  },
    new List<int> { 7, 8, 9 },
  };


    List<int>[] ints2 = new List<int>[3]
    {
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 10 },
    new List<int> { 7, 0, 9 },
    };

    List<int>[] ints3 = new List<int>[3]
    {
    new List<int> (),
    new List<int> (),
    new List<int> (),
    };


    List<int> list1 = new List<int>() {1,2,3,4,5 };

    List<int> list2 = new List<int>() { 1, 0, 3, 9, 5 };
    List<int> list3;

    // Start is called before the first frame update
    void Start()
    {

        // 取出兩 一 維集合 差異的索引值
        // 陣列內部裝的就是 差異數在目標陣列的 索引值 


        list3 = list1.Where((index, item) => index != list2[item])
                     .Select(index => list1.IndexOf(index))
                     .ToList();

        for (int i = 0; i < list3.Count; i++)
        {
            Debug.Log($"長度 : {list3.Count} ,  list3[{i}] : {list3[i]}");
        }



        //---------------------------------------------------------------------------------

        // 取出兩個 一 維集合 中差異的元素
        // 陣列內部裝的就是 差異數在目標陣列的 子元素為何

        list3 = list1.Where( (index,item) => index != list2[item] ) 
                     .ToList();

        for (int i=0;i<list3.Count;i++) 
        {
            Debug.Log($"長度 : {list3.Count} ,  list3[{i}] : {list3[i]}");
        }

    //=================================================================================================================================

        // 取出兩 二維集合 差異的索引值
        // 陣列內部裝的就是 差異數的 索引值 

        //-----------------------------------------------------------------------------------------------------------------------


        // 直接用 LinQ 處理

        // item為索引值
        // list_index 為 為第二層的List

        // 說明 : 對 二為結構內 的 List 做 Select ,接著繼續針對 List 做篩選 , 將篩選出來的值 轉成索引值
        // 之後才對 這些值 轉List => 這是對 Array內部的 List 做的處理 , 所以 第一個 Select 內部 才會 含括 Where跟第二個 Select


        var ret = ints1.Select((list_index, item) => list_index
                          .Where((index, item2) => list_index[item2] != ints2[item][item2])
                          .Select((number) => list_index.IndexOf(number))
                          .ToList())
                          .ToArray();

        
        ints3 = ret;

        // 印值方式

        for (int i = 0; i < ints3.Length; i++)
        {
            if (ints3[i].Count == 0)
            {
                Debug.Log($"ints3[{i}] 長度 : {ints3[i].Count}");
            }
            else
            {
                for (int j = 0; j < ints3[i].Count; j++)
                {
                    Debug.Log($"ints3[{i}] 長度 : {ints3[i].Count} , ints3[{i}][{j}] : {ints3[i][j]}");
                }
            }

        }



        //====================================================================================================================================


        // 同上的原理 , 這裡是直接取得兩集合何差異的值差異的值

        var ret2 = ints1.Select((list_index, item) => list_index
                          .Where((index, item2) => list_index[item2] != ints2[item][item2])
                          .ToList())
                          .ToArray();

        ints3 = ret2;


        // 印值方式

        for (int i = 0; i < ints3.Length; i++)
        {
            if (ints3[i].Count == 0)
            {
                Debug.Log($"ints3[{i}] 長度 : {ints3[i].Count}");
            }
            else
            {
                for (int j = 0; j < ints3[i].Count; j++)
                {
                    Debug.Log($"ints3[{i}] 長度 : {ints3[i].Count} , ints3[{i}][{j}] : {ints3[i][j]}");
                }
            }

        }

    }
}

    