using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    Image hpbar;

    private void Awake()
    {
        hpbar = GetComponent<Image>();
    }
    public void UpdateBarValue()
    {
        hpbar.fillAmount = enemyHealth.curHealth / enemyHealth.maxHealth;
    }
}
