using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
using UnityEngine.SceneManagement;

public class back_caller : MonoBehaviour
{
    public Button Button_back;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_back.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

	void TaskOnClick(){
        SceneManager.LoadScene("caller_graph");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
