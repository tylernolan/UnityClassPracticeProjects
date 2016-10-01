using UnityEngine;
using System.Collections;

public enum MarbleGameState {playing, won,lost };

public class MarbleGameManager : MonoBehaviour
{
    public static MarbleGameManager SP;

    private int totalGems;
    private int foundGems;
    private MarbleGameState gameState;
	private GUIStyle style;


    void Awake()
    {
        SP = this; 
        foundGems = 0;
        gameState = MarbleGameState.playing;
        totalGems = GameObject.FindGameObjectsWithTag("Pickup").Length;
        Time.timeScale = 1.0f;
		style = new GUIStyle ();
    }

	void OnGUI () {

		style.normal.textColor = Color.black;
	    GUILayout.Label(" Found gems: "+foundGems+"/"+totalGems,style);

        if (gameState == MarbleGameState.lost)
        {
			GUILayout.Label("You Lost!",style);
            if(GUILayout.Button("Try again") ){
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (gameState == MarbleGameState.won)
        {
			GUILayout.Label("You won!", style);
            if(GUILayout.Button("Play again") ){
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    public void FoundGem()
    {
        foundGems++;
        if (foundGems >= totalGems)
        {
            WonGame();
        }
    }

    public void WonGame()
    {
        Time.timeScale = 0.0f; //Pause game
        gameState = MarbleGameState.won;
    }

    public void SetGameOver()
    {
        Time.timeScale = 0.0f; //Pause game
        gameState = MarbleGameState.lost;
    }
}
