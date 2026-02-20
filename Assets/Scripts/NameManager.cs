using UnityEngine;
using System.Collections.Generic;

public class NameManager : MonoBehaviour
{
    // A list
    private List<KeyCode> NameKeys = new List<KeyCode>();

    void Update()
    {
        // There is probably a more effiecent way but idk
        CheckAndAddKey(KeyCode.A);
        CheckAndAddKey(KeyCode.B);
        CheckAndAddKey(KeyCode.C);
        CheckAndAddKey(KeyCode.D);
        CheckAndAddKey(KeyCode.E);
        CheckAndAddKey(KeyCode.F);
        CheckAndAddKey(KeyCode.G);
        CheckAndAddKey(KeyCode.H);
        CheckAndAddKey(KeyCode.I);
        CheckAndAddKey(KeyCode.J);
        CheckAndAddKey(KeyCode.K);
        CheckAndAddKey(KeyCode.L);
        CheckAndAddKey(KeyCode.M);
        CheckAndAddKey(KeyCode.N);
        CheckAndAddKey(KeyCode.O);
        CheckAndAddKey(KeyCode.P);
        CheckAndAddKey(KeyCode.Q);
        CheckAndAddKey(KeyCode.R);
        CheckAndAddKey(KeyCode.S);
        CheckAndAddKey(KeyCode.T);
        CheckAndAddKey(KeyCode.U);
        CheckAndAddKey(KeyCode.V);
        CheckAndAddKey(KeyCode.W);
        CheckAndAddKey(KeyCode.X);
        CheckAndAddKey(KeyCode.Y);
        CheckAndAddKey(KeyCode.Z);


        CheckAndAddKey(KeyCode.Backspace);

    }

    /// <summary>
    /// Checks if a specific key was pressed down this frame and adds it to the list.
    /// </summary>
    /// <param name="key">The KeyCode to check.</param>
    private void CheckAndAddKey(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (key != 'Backspace')
            {
                NameKeys.Add(key);
                Debug.log(NameKeys);
            }
            else
            {
                NameKeys.RemoveAt(rows.Count - 1);
                Debug.log(NameKeys);
            }
            
        }
    }
}
