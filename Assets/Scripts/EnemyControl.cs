using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour {

    [Multiline] 
    public string Description;
    public static string name;
    LevelManager manager;
    public int cal;
    public static int enemyhealth;
    
	// Use this for initialization
	void Start () {
        name = "PattyR";
        manager = FindObjectOfType<LevelManager>();
        manager.SetFact(Description,name,true);
        gameObject.SetActive(false);
	}
	
	
	public static string EnemyTurn () {

            int random = Mathf.RoundToInt(Random.value * 4);
            string dialog;
            switch(random)
            {
                case 1:
                    dialog = name+" used Bun Rush and gave you 50 calories";
                    enemyhealth -= 50;
                    PlayerControls.currentHealth += 50;
                    break;
                case 2:
                    dialog = name+" used Oil Hit and gave you 20 calories";
                    enemyhealth -= 20;
                    PlayerControls.currentHealth += 20;
                    break;
                case 3:
                    dialog = name+" used Cheese Overdose and gave you 40 calories";
                    enemyhealth -= 40;
                    PlayerControls.currentHealth += 40;
                    break;
                default:
                    return(name+" tried to attack but you resisted the temptation");
            }
            
            return (dialog);
            
        

	}
}
