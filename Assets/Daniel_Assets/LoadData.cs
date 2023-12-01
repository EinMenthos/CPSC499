using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

[System.Serializable]
public class LoadData : MonoBehaviour
{
    //note that this quests is build while compiling and it is a read-only file.
    public List<DataTree> trees = new List<DataTree>();
    // Start is called before the first frame update
    void Start()
    {
        TextAsset readdata = Resources.Load<TextAsset>("Forest_and_Carbon");
        string[] data = readdata.text.Split(new char[] { '\n' });
        //Debug.Log(data.Length);
        
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != ""){
                DataTree q = new DataTree();
    
                int.TryParse(row[0], out q.ObjectId);
                q.Country = row[1];
                q.Indicator = row[4];
                q.Unit = row[5];
                float.TryParse(row[10], out q.F1992);
                float.TryParse(row[11], out q.F1993);
                float.TryParse(row[12], out q.F1994);
                float.TryParse(row[13], out q.F1995);
                float.TryParse(row[14], out q.F1996);
                float.TryParse(row[15], out q.F1997);
                float.TryParse(row[16], out q.F1998);
                float.TryParse(row[17], out q.F1999);
                float.TryParse(row[18], out q.F2000);
                float.TryParse(row[19], out q.F2001);
                float.TryParse(row[20], out q.F2002);
                float.TryParse(row[21], out q.F2003);
                float.TryParse(row[22], out q.F2004);
                float.TryParse(row[23], out q.F2005);
                float.TryParse(row[24], out q.F2006);
                float.TryParse(row[25], out q.F2007);
                float.TryParse(row[26], out q.F2008);
                float.TryParse(row[27], out q.F2009);
                float.TryParse(row[28], out q.F2010);
                float.TryParse(row[29], out q.F2011);
                float.TryParse(row[30], out q.F2012);
                float.TryParse(row[31], out q.F2013);
                float.TryParse(row[32], out q.F2014);
                float.TryParse(row[33], out q.F2015);
                float.TryParse(row[34], out q.F2016);
                float.TryParse(row[35], out q.F2017);
                float.TryParse(row[36], out q.F2018);
                float.TryParse(row[37], out q.F2019);
                float.TryParse(row[38], out q.F2020);
                trees.Add(q);
            }
        }
        Debug.Log("Data Loaded from CSV file!");
        /*
        foreach (DataTree q in trees)
        {
            if (q.Indicator == "Forest area"){
                //Debug.Log(q.Country + " forest area in 1992: " +  q.F1992);
                float diffTree = q.F2020 - q.F1992;
                if (diffTree  < 0 )
                    Debug.Log(q.Country + " lost " + Mathf.Abs(diffTree) + " kHA of trees");
                else
                {
                    Debug.Log(q.Country + " gained " + Mathf.Abs(diffTree) + " kHA of trees");
                }
            }
        }
        */
    }
}

