using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Jett : MonoBehaviour
{
    static int currentMaxKnifeAmount = 7;
    List<Knife> knives = new List<Knife>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateKnives(int quantity)
    {
        knives.Clear();

        for (int knifeCount = 0; knifeCount < quantity; knifeCount++)
        {
            knives.Add(new Knife());
        }
    }

    void OnEntityKill()
    {
        // Restores all knives cooldown to 0
        knives.ForEach(knife => knife.currentKnifeCooldown = 0);
    }

    void ThrowKnife(Knife knife)
    {
        // If there's one knife avaiable
        if (knives.Count() > 0)
        {
            // Throw the knife
            ThrowKnife(knife);
        }
    }

    void ThrowAllKnifes()
    {
        // Get all the knives you can throw
        var knivesNotInCooldown = knives.Where(knife => knife.knifeCooldown != 0).ToList();

        if (knivesNotInCooldown.Count() > 0)
        {
            // Throw all knives avaiable
            knivesNotInCooldown.ForEach(knife => ThrowKnife(knife));
        }
    }

    public class Knife
    {
        public int knifeCooldown = 5;
        public int currentKnifeCooldown = 0;
        public int damage = 40;

        void ThrowKnife(Knife knife)
        {
            knife.currentKnifeCooldown = knife.knifeCooldown;
        }
    }
}
