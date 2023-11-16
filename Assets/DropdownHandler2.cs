using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler2 : MonoBehaviour
{
    //public Text TextBox = transform.GetComponent<Text>;
    public Text TextBox;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Loading the Dropdown box");
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();


// Assuming you have a reference to your LoadData script
        LoadData2 loadDataScript = FindObjectOfType<LoadData2>();

        if (loadDataScript != null)
        {
            //Debug.Log("tree is not null");
            //Debug.Log(loadDataScript.trees2.Count);
            foreach (DataTree tree in loadDataScript.trees2)
            {
                //Debug.Log(tree.Country);
                // Add the desired data field (e.g., tree.Country) as an option
                //dropdown.options.Add(new Dropdown.OptionData() { text = tree.Country });
                dropdown.options.Add(new Dropdown.OptionData() { text = tree.Country });
                    
            }
        }
        Debug.Log("script loading Countries ended");


        //this will forcefully call the function and fill the text with first option.
        //DropdownitemSelected(dropdown);
        
        dropdown.onValueChanged.AddListener(delegate { DropdownitemSelected(dropdown);});
    }

    void DropdownitemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        string selectedCountry = dropdown.options[index].text;
        LoadData2 loadDataScript = FindObjectOfType<LoadData2>();
        Window_Graph2 Window_GraphScript = FindObjectOfType<Window_Graph2>();
        foreach (DataTree tree in loadDataScript.trees2)
        {
            if (tree.Country == selectedCountry ){
                float diffTree = tree.F2020 - tree.F1992;
                //Debug.Log("2020: " + tree.F2020 + " / 1992: " + tree.F1992);

                if (diffTree  < 0 )
                   TextBox.text = TextBox.text + "\n" + tree.Country + " decreased " + Mathf.Abs(diffTree).ToString("n2") + " Celsius";
                else
                {
                    TextBox.text = TextBox.text + "\n" + tree.Country + " increased " + Mathf.Abs(diffTree).ToString("n2") + " Celsius";
                }

                //List<string> items = new List<string>();
                //items.Add("item 1");
                //items.Add("item 2");
                Window_GraphScript.comboListGraphClear();
                List<int> valueList = new List<int>();
                valueList.Add((int)tree.F1992);
                valueList.Add((int)tree.F1993);
                valueList.Add((int)tree.F1994);
                valueList.Add((int)tree.F1995);
                valueList.Add((int)tree.F1996);
                valueList.Add((int)tree.F1997);
                valueList.Add((int)tree.F1998);
                valueList.Add((int)tree.F1999);
                valueList.Add((int)tree.F2000);
                valueList.Add((int)tree.F2001);
                valueList.Add((int)tree.F2002);
                valueList.Add((int)tree.F2003);
                valueList.Add((int)tree.F2004);
                valueList.Add((int)tree.F2005);
                valueList.Add((int)tree.F2006);
                valueList.Add((int)tree.F2007);
                valueList.Add((int)tree.F2008);
                valueList.Add((int)tree.F2009);
                valueList.Add((int)tree.F2010);
                valueList.Add((int)tree.F2011);
                valueList.Add((int)tree.F2012);
                valueList.Add((int)tree.F2013);
                valueList.Add((int)tree.F2014);
                valueList.Add((int)tree.F2015);
                valueList.Add((int)tree.F2016);
                valueList.Add((int)tree.F2017);
                valueList.Add((int)tree.F2018);
                valueList.Add((int)tree.F2019);
                valueList.Add((int)tree.F2020);
                Window_GraphScript.comboListGraph(valueList);
            }
        } 
    }
}


