using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 10f;
    public Slider Healthbar;

    public GameObject PlayerUI;
    public GameObject GameOverUI;

    float _currentValue;

    void Start()
    {
		
        _currentValue = MaxValue;
        UpdateHealthbar();
    }

    public void TakeDamage(float damage)
    {
		
        _currentValue  -= damage;
		
		
        if (_currentValue <= 0)
        {
            Destroy(gameObject);
            GameOver();
        }
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
		//обновить Healthbar.value текущим значением здоровья (от 0 до 1)
        Healthbar.value = Mathf.Lerp(0,1, _currentValue/100f);
    }
    void GameOver()
    {
        //включить или отключить объекты и компоненты
        PlayerUI.SetActive(false);
        GameOverUI.SetActive(true);
        //GetComponent<Player>().enabled = 0;
        //GetComponent<CameraController>().enabled = 0;
    }
}
