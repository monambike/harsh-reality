using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private float attackSpeed = default;

    private bool attacking = false;
    private float timer = 0f;

    public Animator animator;

    public Transform attackHitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PrimaryAttack"))
            PrimaryAttack();


        if (Input.GetButtonDown("SecondaryAttack"))
            SecondaryAttack();

        if (Input.GetButtonDown("DefensiveAbility"))
            DefensiveAbility();

        if (Input.GetButtonDown("Ultimate"))

            if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= attackSpeed)
            {
                timer = 0;
                attacking = false;
            }
        }
    }

    private void PrimaryAttack()
    {
        Debug.Log("Has used PrimaryAttack");

        // Play attack animation
        //animator.SetTrigger("Attack");

        // Dettect enemies in the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(@"We hit """ + enemy.name + @"""");
        }
        attacking = true;
    }

    private void SecondaryAttack()
    {
        Debug.Log("Has used SecondaryAttack");
    }

    private void DefensiveAbility()
    {
        Debug.Log("Has used DefensiveAbility");
    }

    private void Ultimate()
    {
        Debug.Log("Has used Ultimate");
    }


    private void OnDrawGizmosSelected()
    {
        if (attackHitbox == null) return;
        Gizmos.DrawWireSphere(attackHitbox.position, attackRange);
    }
}
