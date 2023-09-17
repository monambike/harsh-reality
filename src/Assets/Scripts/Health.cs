using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;
    public int MAX_HEALTH = 3;

    private void Update()
    {
        if (health <= 0)
        {
            throw new System.ArgumentOutOfRangeException("You are dead");
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage.");
        }

        health -= amount;
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing.");
        }

        if (health + amount > MAX_HEALTH)
        {
            health += MAX_HEALTH;
        }
        else
        {
            health += amount;
        }

        health -= amount;
    }
}
