using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "GameData", menuName = "GameData", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool saveLoad;
    public bool music = true;
    public bool sound = true;

    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public int pointsToBall = 0;
    public int baseBonusRate = 1;
    public int fireBonusRate = 1;
    public int normBonusRate = 1;
    public int steelBonusRate = 1;
    public int noBonusRate = 0;
    
    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
        //PlayerPrefs.SetInt("baseBonusRate", baseBonusRate);
        //PlayerPrefs.SetInt("fireBonusRate", fireBonusRate);
        //PlayerPrefs.SetInt("normBonusRate", normBonusRate);
        //PlayerPrefs.SetInt("steelBonusRate", steelBonusRate);
        //PlayerPrefs.SetInt("noBonusRate", noBonusRate);
    }

  public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 6);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
        //baseBonusRate = PlayerPrefs.GetInt("baseBonusRate", baseBonusRate);
        //fireBonusRate = PlayerPrefs.GetInt("fireBonusRate", fireBonusRate);
        //normBonusRate = PlayerPrefs.GetInt("normBonusRate", normBonusRate);
        //steelBonusRate = PlayerPrefs.GetInt("steelBonusRate", steelBonusRate);
        //noBonusRate = PlayerPrefs.GetInt("noBonusRate", noBonusRate);
    }

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
        baseBonusRate = 1;
        fireBonusRate = 1;
        normBonusRate = 1;
        steelBonusRate = 1;
        noBonusRate = 0;
    }

    public int getBonusType()
    {
        int sumRates = baseBonusRate + fireBonusRate + normBonusRate + steelBonusRate + noBonusRate;
        int bonus = Random.Range(0, sumRates);
        
        if (bonus < noBonusRate)
        {
            return 0;
        } 
        else if (bonus < noBonusRate + baseBonusRate)
        {
            return 1;
        } 
        else if (bonus < noBonusRate + baseBonusRate + fireBonusRate)
        {
            return 2;
        }
        else if ( bonus < noBonusRate + baseBonusRate + fireBonusRate + normBonusRate)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }
}
