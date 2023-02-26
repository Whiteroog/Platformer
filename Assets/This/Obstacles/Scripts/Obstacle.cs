using This.Characters.Hero.Scripts;
using UnityEngine;

namespace This.Obstacles.Scripts
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject == Hero.Instance.gameObject)
            {
                Hero.Instance.GetDamage();
            }
        } 
    }
}
