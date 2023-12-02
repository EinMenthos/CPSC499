  //create a graph
//reference: https://www.youtube.com/watch?v=CmU5-v-v1Qo

//dynamic list
//https://www.youtube.com/watch?v=iIVBu-z0Akw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Window_Graph3 : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private List<GameObject> gameObjectList;
    private List<float> dynamicValueList;
    private float pointDelay = 0.1f; // Delay between each point in seconds
    private WaitForSeconds delay;

    
    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        gameObjectList = new List<GameObject>();

        dynamicValueList = new List<float>();
        delay = new WaitForSeconds(pointDelay);

        //will generate a new random graph
        //valueList.Clear();
        //for (int i = 0; i < 15; i++){
        //    valueList.Add(UnityEngine.Random.Range(0, 500));
        //}
        //ShowGraph(valueList);
        
    }

    private void Update()
{

}

    public void comboListGraph(List<float> valueList){
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        gameObjectList = new List<GameObject>();
        StartCoroutine(ShowGraph(valueList, -1));
    }

    public void comboListGraphClear(){
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        foreach (GameObject gameObject in gameObjectList){
            Destroy(gameObject);
        }
        gameObjectList.Clear();
    }

    private GameObject CreateCircle(Vector2 anchoredPosition){
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectransform = gameObject.GetComponent<RectTransform>();
        rectransform.anchoredPosition = anchoredPosition;
        //size of the dot
        rectransform.sizeDelta = new Vector2(5,5);
        rectransform.anchorMin = new Vector2(0,0);
        rectransform.anchorMax = new Vector2(0,0);
        return gameObject;
    }

    private IEnumerator ShowGraph(List<float> valueList, int maxVisibleAmount = -1){
        Debug.Log("Creating graph...");
        if (maxVisibleAmount <= 0) {
            maxVisibleAmount = valueList.Count;
        }
        
        //clear the previous graph
        foreach (GameObject gameObject in gameObjectList){
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;

        //finding the max and min values from the list
        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        for (int i = Mathf.Max(valueList.Count - maxVisibleAmount, 0); i < valueList.Count; i++){
            float value = valueList[i];
            if (value > yMaximum)
                yMaximum = value;
            if (value < yMinimum)
                yMinimum = value;
        }
        Debug.Log("maxTemp = " + yMaximum + " / minTemp: " + yMinimum);
        
        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0) {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        //xSize will increment in spaces of 40 "units"
        float xSize = graphWidth / (maxVisibleAmount + 1);
        //float xSize = graphWidth / (valueList.Count + 1 );
        GameObject lastCircleGameObject = null;
        //Debug.Log(valueList.Count);
        int xIndex = 0;

        //this will create the labels for y-axis
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++){
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            //20f is the position of the label, 20 px under the x axis
            float normalizedValue = i * 1f/ separatorCount;
            labelY.anchoredPosition = new Vector2(-40f, normalizedValue * graphHeight);
            //labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();
            //labelY.GetComponent<Text>().text = Mathf.RoundToInt(yMinimum + (normalizedValue * (yMaximum - yMinimum))).ToString();            
            labelY.GetComponent<Text>().text = Math.Round(yMinimum + (normalizedValue * (yMaximum - yMinimum)),1).ToString();            
            gameObjectList.Add(labelY.gameObject);

            //this will create the reference line for y-axis
            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            //20f is the position of the dash, 10 px at left axis
            dashY.anchoredPosition = new Vector2(-10f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
        }

        //this will create x-elements
        for (int i = Mathf.Max(valueList.Count - maxVisibleAmount, 0); i < valueList.Count; i++){

            // Wait for the specified delay
            yield return delay;

            float xPosition = xSize + xIndex * xSize;
            //float yPosition = (valueList[i] / yMaximum) * graphHeight;
            float yPosition = ((valueList[i] - yMinimum)/ (yMaximum - yMinimum) * graphHeight);
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);

            //dots for each data
            if (lastCircleGameObject != null){
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;
            
            //this will create x-axis label 
            if (((i + 1995) % 5 == 0) || (i == 0) || (i == valueList.Count -1)) {
                RectTransform labelX = Instantiate(labelTemplateX);
                labelX.SetParent(graphContainer, false);
                labelX.gameObject.SetActive(true);
                //20f is the position of the label, 10 px under the x axis
                labelX.anchoredPosition = new Vector2(xPosition, -10f);
                labelX.GetComponent<Text>().text = (i + 1995).ToString();
                //labelX.alignment = TextAnchor.MiddleCenter;
                gameObjectList.Add(labelX.gameObject);
            }
            
            //this will create x-axis reference lines 
            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            //20f is the position of the label, 10 px under the x axis
            dashX.anchoredPosition = new Vector2(xPosition, -10f);
            gameObjectList.Add(dashX.gameObject);

            CreateCircle(new Vector2(xPosition, yPosition));
            xIndex++;
        }

    }

    //functions from libraries
    private GameObject CreateDotConnection (Vector2 dotPositionA, Vector2 dotPositionB){
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        //Debug.Log(distance);
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0,0);
        //size of bar is double the xSize (left and right of a point)
        rectTransform.sizeDelta = new Vector2(distance,  3f);
        //CreateCircle(dotPositionA + dir * distance * 0.5f);
        //rectTransform.anchoredPosition = dotPositionA;
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(dir));
        return gameObject;
    }

    //functions copied to not use external libraries
    public static float GetAngleFromVectorFloat(Vector3 dir) {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
    }
}

