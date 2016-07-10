using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text;

//Opens dialog for the observer
public class OpenDialog : MonoBehaviour {
    //Holds all the questions and available responses
    static string[] myIndex;
    static StringBuilder myStringBuilder = new StringBuilder();
	// Use this for initialization
	void Start () {
        //"questions.txt" will most likely need to be changed to \\Assets\\questions.txt
        // or you can leave it in root folder.
        StreamReader sr = File.OpenText("questions.txt");
        string line;
        while ((line = sr.ReadLine()) != null) {
            myIndex = line.Split(',');
            }

        }
    //if you want to have a interlocking story (where nodes point back to each other)
    // then you gotta send do: the question - 1
    // so it goes back to the previous question (you do the wrong response twice, but
    // i dont want to make that better
    // @param the 'wave/round' of question the user is currently on
	static string PromptUser(int theQuestion) {
        //the value will change depending on the selection. 
        string currQuestion = myIndex[(theQuestion * 3) + 0];
        //good response is going to return true
        string currOption1 = myIndex[(theQuestion * 3) + 1];
        //bad response is going to return false
        string currOption2 = myIndex[(theQuestion * 3) + 2];
        //Display shit
        bool isCorrect = EditorUtility.DisplayDialog("Make the choice!", currQuestion, currOption1, currOption2);
        //translate back to text
        string returnStr;
        if (isCorrect) {
            returnStr = currOption1;
        } else {
            returnStr = currOption2;
        }
        myStringBuilder.Append(returnStr);
        return returnStr;
    }
    //Show the path that the student took (log)
    static string getReview() {
        return myStringBuilder.ToString();
    }
}
