using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 5;
    private int currentHealth;

    // Start is called before the first frame update
    private void onEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth<=0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
