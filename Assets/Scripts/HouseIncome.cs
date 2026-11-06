using UnityEngine;

public class HouseIncome : MonoBehaviour
{
    public int incomePerSecond = 5;

    private float timer = 0f;
    private Economy economy;

    void Start()
    {
        economy = FindFirstObjectByType<Economy>(); // Utiliza FindFirstObjectByType para buscar la instancia «Economy» en la escena
    }

    void Update() 
    {
        if (economy == null) // Si no se encuentra la instancia de «Economy», no se puede continuar con la actualización
            return;

        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            economy.money += incomePerSecond;
            timer = 0f;
        }
    }
}
