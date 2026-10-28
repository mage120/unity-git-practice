using UnityEngine;

public class gwajei : MonoBehaviour
{
    void Start()
    {
        /*for (int i = 1; i < 6; i++) 
        { 
            Debug.Log(i);
        }*/

        Human Alice = new Human("Alice", 23, 160f);

        Debug.Log(Alice.name);
        Debug.Log(Alice.age);
        Debug.Log(Alice.height);

        Human John = new Human();

        Debug.Log(John.name);
        Debug.Log(John.age);
        Debug.Log(John.height);
    }

    
}

class Human
{
    public string name;
    public float height;
    public int age;

    public Human()
    {

    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            Debug.Log(value);
            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            Debug.Log(value);
            age = value;
        }
    }

    public float Height
    {
        get
        {
            return height;
        }
        set
        {
            Debug.Log(value);
            height = value;
        }
    }

    public Human(string _name, int _age, float _height)
    {
        name = _name;
        age = _age;
        height = _height;
    }

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