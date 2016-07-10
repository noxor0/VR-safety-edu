using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Timer : MonoBehaviour {

    public Text counterText;
    public float seconds, minutes;
	private int question_num;
	private static float my_height = 0;
    // Use this for initialization
    void Start () {
        counterText = GetComponent<Text>() as Text;
    }
	
	// Update is called once per frame
	void Update () {
		if (my_height < 0.5) { 
			my_height = (float)Camera.main.gameObject.transform.position.y;
		}
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
		//Debug.Log("the players coordinates are " +  my_height);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
		if (counterText.text.Equals("00:10") && ((float)Camera.main.gameObject.transform.position.y > (float)(0.5 * my_height)))
        {
            OpenDialog.PromptUser(0);
		} 
		if (counterText.text.Equals("00:30"))
		{
			OpenDialog.PromptUser(1);
		} 
		if (counterText.text.Equals("01:00"))
		{
			OpenDialog.PromptUser(2);
		} 
	}
}
