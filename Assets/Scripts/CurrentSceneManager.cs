using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int CoinPickedUpInThisScene;
    public static CurrentSceneManager Instance;
    public Vector3 RespawnPoint;
    public int levelToUnlock;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;

        RespawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

   
}
