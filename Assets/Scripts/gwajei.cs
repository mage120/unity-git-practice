using UnityEngine;

public class gwajei : MonoBehaviour
{
    void Start()
    {
        int k = 1; 
        while (k <= 10) 
        { 
            if (k % 2 == 0) 
            { 
                k++;
                continue; 
            } 
            Debug.Log(k);
            k++; 
        }

        int[] i = { 1, 2, 3, 4, 5 };
        foreach (int j in i)
        {
            
        }


    }
}

class Human
{
    public string name;
    public float height;
    public int age;

    public void Eat()
    {
        Debug.Log("eat");
    }

    public void Walk()
    {
        Debug.Log("walk");
    }

    public void Sleep()
    {
        Debug.Log("sleep");
    }
}
