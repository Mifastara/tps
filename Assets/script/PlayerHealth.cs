using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float value = 100;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;

    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<cameraRotation>().enabled = false;
    }
}
