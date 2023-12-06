using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
//using System;

[System.Serializable]
public class LoadData3a : MonoBehaviour
{
    //note that this quests is build while compiling and it is a read-only file.
    public List<float> trees2 = new List<float>();
    public Text TextBox;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting LoadData3...");
        if (StaticClass.CrossSceneInformation == null)
            StaticClass.CrossSceneInformation = "Birmingham";
        Debug.Log("Retrieving data from " + StaticClass.CrossSceneInformation);
        TextAsset readdata2 = Resources.Load<TextAsset>("cities_temp");
        string[] data2 = readdata2.text.Split(new char[] { '\n' });
        Debug.Log("Read " + data2.Length + " entries from DB");

        // Create a dictionary to store the sum of temperatures for each year
        Dictionary<int, float> yearSum = new Dictionary<int, float>();
        Dictionary<int, int> yearCount = new Dictionary<int, int>();

        //reading data3
        for (int k = 1; k < data2.Length - 1; k++)
        {
            string[] row2 = SmartSplit(data2[k], ',', '"', false);
            float q2;

            //check if the city name match
            if (row2[1] == StaticClass.CrossSceneInformation)
            {
                if (float.TryParse(row2[5], out q2))
                {
                    if (q2 != -99){     //ignore entries where temperature = -99 F.
                        int year = int.Parse(row2[4]); // Assuming the year is in the 5th column
                        if (!yearSum.ContainsKey(year))
                        {
                            yearSum[year] = q2;
                            yearCount[year] = 1;
                        }
                        else
                        {
                            yearSum[year] += q2;
                            yearCount[year]++;
                        }
                    }

                }
            }
        }

        // Calculate and store the annual average temperatures
        foreach (var entry in yearSum)
        {
            int year = entry.Key;
            float sum = entry.Value;
            int count = yearCount[year];
            float average = sum / count;

            // Store the annual average temperature in your desired data structure (e.g., trees2)
            trees2.Add(average);
            // Debug.Log("sum: " + sum + " count: " + count + " avg: " + average);
        }

        //end - year average

        TextBox.text = StaticClass.CrossSceneInformation;
        Debug.Log(trees2.Count + " entries is going to be plotted");
        Window_Graph3 Window_GraphScript = FindObjectOfType<Window_Graph3>();

        Window_GraphScript.comboListGraph(trees2);
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

