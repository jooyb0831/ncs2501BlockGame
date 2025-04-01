using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_InputField inputField;

    private const string BESTSCORE_KEY = "BESTSCORE";
    private const string BESTPLAYER_KEY = "BESTPLAYER";
    private const string NONAME = "NoName";

    private string userName;
    public string UserName
    {
        get { return userName; }
        set
        {
            userName = (value.Length == 0) ? NONAME : value;
        }
    }

    public string BestPlayer
    {
        get { return PlayerPrefs.GetString(BESTPLAYER_KEY, NONAME); }
        set { PlayerPrefs.SetString(BESTPLAYER_KEY, value); }
    }

    public int BestScore
    {
        get
        {
            return  PlayerPrefs.GetInt("BESTSCORE_KEY", 0);
        }
        set
        {
            if (BestScore <= value)
            {
                PlayerPrefs.SetInt("BESTSCORE_KEY", value);
                BestPlayer = userName;
            }
        }
    }


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = GetBestText();
    }

    public string GetBestText()
    {
        return $"BEST : {BestScore} by {BestPlayer}";
    }

    public void UpdateName()
    {
        name = inputField.text;
        Debug.Log(name);
    }

    public void StartGame()
    {
        UserName = inputField.text;
        SceneManager.LoadScene("main");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    [MenuItem("BlockGame/ResetBestScore")]
    public static void ResetBestScore()
    {
        PlayerPrefs.SetInt("BESTSCORE_KEY", 0);
        PlayerPrefs.SetString("BESTPLAYER_KEY", NONAME);
    }
}
