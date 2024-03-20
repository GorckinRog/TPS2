using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healthAmount = 30;

    void OnTriggerEnter(Collider other)
    {
        //пробуем взять у объекта с которым мы столкнулись компонент системы здоровья
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        //если такой действительно существует
        if (player != null)
        {
            //добавляем игроку здоровье
            player.AddHealth(healthAmount);
            //уничтожаем объект лечилку
            Destroy(gameObject);
        }
    }
}
