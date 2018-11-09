using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private float step = 1f;
    private float timeCount;
    private float timeCalc;
    private bool play;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Play")
            {
                Debug.Log(hit.collider.gameObject.name);
                play = !play;
                timeCalc = 0;
                timeCount = 0;
                timerText.text = timeCount.ToString();
            }
        }

        if (play)
        {
            timeCalc += Time.deltaTime;
            if (Mathf.Floor(timeCalc) == step)
            {
                Debug.Log("Seconds: " + timeCount);
                timeCalc = 0;
                timeCount++;
                timerText.text = timeCount.ToString();
            }
        }
    }
}
