using UnityEngine;

namespace This.Characters.Scripts
{
    public class Entity : MonoBehaviour
    {
        public virtual void GetDamage()
        {
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
