using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour
{
    public static PlayerEffect Instance;
    public SpriteRenderer playerSprite;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }
    public void AddSpeed(int SpeedGiven,float SpeedDuration)
    {
        PlayerMove.Instance.jumpForce += SpeedGiven;
        playerSprite.color = new Color(0f, 151f, 1f, 1f);
        StartCoroutine(RemoveSpeed(SpeedGiven, SpeedDuration));
    }

    IEnumerator RemoveSpeed(int SpeedGiven, float SpeedDuration)
    {
        yield return new WaitForSeconds(SpeedDuration);
        playerSprite.color = new Color(1f, 1f, 1f, 1f);
        PlayerMove.Instance.moveSpeed -= SpeedGiven;
    }
}
