using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//using System;

[System.Serializable]
public class LoadData2 : MonoBehaviour
{
    //note that this quests is build while compiling and it is a read-only file.
    public List<DataTree> trees2 = new List<DataTree>();

    // Start is called before the first frame update
    void Start()
    {
        //local
        TextAsset readdata2 = Resources.Load<TextAsset>("Annual_Surface_Temperature_Change");
        string[] data2 = readdata2.text.Split(new char[] { '\n' });

        //Debug.Log(data2.Length);

        //reading data1 and data2
        //ignore row[0] bc it contais the ID

        for (int k = 1; k < data2.Length -1; k++){
            string[] row2 = SmartSplit(data2[k], ',', '"', false);
            //Debug.Log("r2: " + row2[1]);
            //surface temp
            DataTree q2 = new DataTree();
            int.TryParse(row2[0], out q2.ObjectId);
            q2.Country = row2[1];
            float.TryParse(row2[41], out q2.F1992);
            float.TryParse(row2[42], out q2.F1993);
            float.TryParse(row2[43], out q2.F1994);
            float.TryParse(row2[44], out q2.F1995);
            float.TryParse(row2[45], out q2.F1996);
            float.TryParse(row2[46], out q2.F1997);
            float.TryParse(row2[47], out q2.F1998);
            float.TryParse(row2[48], out q2.F1999);
            float.TryParse(row2[49], out q2.F2000);
            float.TryParse(row2[50], out q2.F2001);
            float.TryParse(row2[51], out q2.F2002);
            float.TryParse(row2[52], out q2.F2003);
            float.TryParse(row2[53], out q2.F2004);
            float.TryParse(row2[54], out q2.F2005);
            float.TryParse(row2[55], out q2.F2006);
            float.TryParse(row2[56], out q2.F2007);
            float.TryParse(row2[57], out q2.F2008);
            float.TryParse(row2[58], out q2.F2009);
            float.TryParse(row2[59], out q2.F2010);
            float.TryParse(row2[60], out q2.F2011);
            float.TryParse(row2[61], out q2.F2012);
            float.TryParse(row2[62], out q2.F2013);
            float.TryParse(row2[63], out q2.F2014);
            float.TryParse(row2[64], out q2.F2015);
            float.TryParse(row2[65], out q2.F2016);
            float.TryParse(row2[66], out q2.F2017);
            float.TryParse(row2[67], out q2.F2018);
            float.TryParse(row2[68], out q2.F2019);
            float.TryParse(row2[69], out q2.F2020);
            trees2.Add(q2);
        }

        Debug.Log("Data Loaded from CSV file2");
    }

    //handle CSV with comma
    public static string[] SmartSplit(string s, char splitter, char quote, bool includeQuotes)
    {
        //if (splitter == quote) throw new ArgumentException();
        List<string> tokens = new List<string>();
        StringBuilder sb = new StringBuilder();
        bool insideQuotes = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (!insideQuotes && s[i] == splitter)
            {
                tokens.Add(sb.ToString());
                sb.Clear();
                continue;
            }
            if (s[i] == quote)
            {
                insideQuotes = !insideQuotes;
                if (includeQuotes)
                    sb.Append(quote);
                continue;
            }
            sb.Append(s[i]);
        }
        if (sb.Length > 0)
            tokens.Add(sb.ToString());
        return tokens.ToArray();
    }

}

