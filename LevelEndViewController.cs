using UnityEngine;
using System.Collections;

public class LevelEndViewController : MonoBehaviour
{
    public tk2dTextMesh PointsCounterLabel;

    public tk2dUIItem OkButton;

    // Use this for initialization
    void Start()
    {
        OkButton.OnClick += OkButtonClickHandler;

        //
        // Start counter animation
        //

        StartCounterAnimation();
    }

    void StartCounterAnimation()
    {
        StartCoroutine(UnityUtils.LerpAction(3f, delegate(float t)
        {
        
            PointsCounterLabel.text = "x" + Mathf.Round( Mathf.Lerp(0,GameData.Get.Score.Points,t) );

        }));
    }

    void OkButtonClickHandler()
    {
        Application.LoadLevel("AboutLevel");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
