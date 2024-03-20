using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 10f;
    public Slider Healthbar;

    public GameObject PlayerUI;
    public GameObject GameOverUI;
    public GameObject HealEffect;

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
    public void AddHealth(float amount)
    {
        _currentValue += amount;
        // if (_currentValue >= MaxValue) 
        //{
        //_currentValue = MaxValue;
        //}
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
        
        //HealEffect.GetComponent<ParticleSystem>().Play();
        UpdateHealthbar(); 
    }

    void UpdateHealthbar()
    {		
        Healthbar.value = Mathf.Lerp(0,1, _currentValue/100f);
    }
    void GameOver()
    {
       
        PlayerUI.SetActive(false);
        GameOverUI.SetActive(true);
        //GetComponent<Pl>().enabled = 0;
        //GetComponent<PlayerController>().enabled = 0;
    }
}
