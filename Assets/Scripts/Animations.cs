using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
   

    public static IEnumerator NPCMovement(GameObject animateMe, Rigidbody2D rb, int direction)
    {
        Animator animDirection = animateMe.GetComponent<Animator>();
       if (animDirection == null)
        {
            Destroy(animateMe);
        }
        // Keep the coroutine running indefinitely
        while (true)
        {
            
            direction = Random.Range(0, 5);  // Adjusted to include case 4
            animDirection.ResetTrigger("Idle");
            switch (direction)
            {
                case 0:

                    animDirection.SetTrigger("Roam1");
                    rb.velocity = Vector2.left;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 1:

                    animDirection.SetTrigger("Roam2");
                    rb.velocity = Vector2.right;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 2:

                    animDirection.SetTrigger("Roam3");
                    rb.velocity = Vector2.up;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 3:

                    animDirection.SetTrigger("Roam4");
                    rb.velocity = Vector2.down;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 4:
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle"); // Trigger the "Idle" animation
                    break;
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            animDirection.ResetTrigger("Roam1");
            animDirection.ResetTrigger("Roam2");
            animDirection.ResetTrigger("Roam3");
            animDirection.ResetTrigger("Roam4");
            animDirection.ResetTrigger("Idle");
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
