using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    //public Text TextBox = transform.GetComponent<Text>;
    public Text TextBox;
    public Text Text2;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Loading the Dropdown box");
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

/*
        List<string> items = new List<string>();
        items.Add("item 1");
        items.Add("item 2");

        foreach(var item in items)
            {
                dropdown.options.Add(new Dropdown.OptionData() {text = item});
            }
*/
// Assuming you have a reference to your LoadData script
        LoadData loadDataScript = FindObjectOfType<LoadData>();

        if (loadDataScript != null)
        {
            //Debug.Log("tree is not null");
            Debug.Log(loadDataScript.trees.Count);
            foreach (DataTree tree in loadDataScript.trees)
            {
                //Debug.Log(tree.Country);
                // Add the desired data field (e.g., tree.Country) as an option
                //dropdown.options.Add(new Dropdown.OptionData() { text = tree.Country });
                
                if (tree.Indicator == "Forest area")
                    dropdown.options.Add(new Dropdown.OptionData() { text = tree.Country });
                    
            }
        }



        //this will forcefully call the function and fill the text with first option.
        //DropdownitemSelected(dropdown);
        
        dropdown.onValueChanged.AddListener(delegate { DropdownitemSelected(dropdown);});
    }

    void DropdownitemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        string selectedCountry = dropdown.options[index].text;
        LoadData loadDataScript = FindObjectOfType<LoadData>();
        Text2.text = "";
        Window_Graph Window_GraphScript = FindObjectOfType<Window_Graph>();
        foreach (DataTree tree in loadDataScript.trees)
        {
            if (tree.Indicator == "Forest area" && tree.Country == selectedCountry ){
                float diffTree = tree.F2020 - tree.F1992;
                //Debug.Log("2020: " + tree.F2020 + " / 1992: " + tree.F1992);

                if (diffTree  < 0 )
                   TextBox.text = tree.Country + " lost " + Mathf.Abs(diffTree).ToString("n2") + " x1000 HA of trees";
                else
                {
                    TextBox.text = tree.Country + " gained " + Mathf.Abs(diffTree).ToString("n2") + " x1000 HA of trees";
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

                /*
                Window_GraphScript.valueList.Add((int)tree.F1992);
                Window_GraphScript.valueList.Add((int)tree.F1993);
                Window_GraphScript.valueList.Add((int)tree.F1994);
                Window_GraphScript.valueList.Add((int)tree.F1995);
                Window_GraphScript.valueList.Add((int)tree.F1996);
                Window_GraphScript.valueList.Add((int)tree.F1997);
                Window_GraphScript.valueList.Add((int)tree.F1998);
                Window_GraphScript.valueList.Add((int)tree.F1999);
                Window_GraphScript.valueList.Add((int)tree.F2000);
                Window_GraphScript.valueList.Add((int)tree.F2001);
                Window_GraphScript.valueList.Add((int)tree.F2002);
                Window_GraphScript.valueList.Add((int)tree.F2003);
                Window_GraphScript.valueList.Add((int)tree.F2004);
                Window_GraphScript.valueList.Add((int)tree.F2005);
                Window_GraphScript.valueList.Add((int)tree.F2006);
                Window_GraphScript.valueList.Add((int)tree.F2007);
                Window_GraphScript.valueList.Add((int)tree.F2008);
                Window_GraphScript.valueList.Add((int)tree.F2009);
                Window_GraphScript.valueList.Add((int)tree.F2010);
                Window_GraphScript.valueList.Add((int)tree.F2011);
                Window_GraphScript.valueList.Add((int)tree.F2012);
                Window_GraphScript.valueList.Add((int)tree.F2013);
                Window_GraphScript.valueList.Add((int)tree.F2014);
                Window_GraphScript.valueList.Add((int)tree.F2015);
                Window_GraphScript.valueList.Add((int)tree.F2016);
                Window_GraphScript.valueList.Add((int)tree.F2017);
                Window_GraphScript.valueList.Add((int)tree.F2018);
                Window_GraphScript.valueList.Add((int)tree.F2019);
                Window_GraphScript.valueList.Add((int)tree.F2020);
                Debug.Log(Window_GraphScript.valueList.Count);
                Window_GraphScript.ShowGraph(valueList);
*/

                //Debug.Log(tree.F1992);
                //Text2.text = tree.F1992.ToString() + "\n" + 
                Text2.text = tree.F1992 + "\n" + 
                tree.F1993 + "\n" + 
                tree.F1994 + "\n" + 
                tree.F1995 + "\n" + 
                tree.F1996 + "\n" + 
                tree.F1997 + "\n" + 
                tree.F1998 + "\n" + 
                tree.F1999 + "\n" + 
                tree.F2000 + "\n" + 
                tree.F2001 + "\n" + 
                tree.F2002 + "\n" + 
                tree.F2003 + "\n" + 
                tree.F2004 + "\n" + 
                tree.F2005 + "\n" + 
                tree.F2006 + "\n" + 
                tree.F2007 + "\n" + 
                tree.F2008 + "\n" + 
                tree.F2009 + "\n" + 
                tree.F2010 + "\n" + 
                tree.F2011 + "\n" + 
                tree.F2012 + "\n" + 
                tree.F2013 + "\n" + 
                tree.F2014 + "\n" + 
                tree.F2015 + "\n" + 
                tree.F2016 + "\n" + 
                tree.F2017 + "\n" + 
                tree.F2018 + "\n" + 
                tree.F2019 + "\n" + 
                tree.F2020;

            }
                
                

        } 
        

    }

}


