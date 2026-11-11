using UnityEngine;
using UnityEngine.UIElements;

public class InheritanceExample : MonoBehaviour
{
    private void Start()
    {
        /*// 상속
        Adult john = new Adult("john", 28, 173f);
        Baby lisa = new Baby("lisa", 3, 95f);

        Debug.Log(john.age);
        lisa.Sleep();*/

        /*Adult maria = new Adult("maria", 10, 12);
        maria.Age = 1;
        maria.SetBaseAge(2);
        Debug.Log(maria.Age);
        Debug.Log(maria.GetBaseAge());*/

        Adult maria = new Adult("Alice", 26, 165.5f);
        maria.Age = 10;
        maria.SetBaseAge(2);
        Debug.Log(maria.Age);
        Debug.Log(maria.GetBaseAge());

        /*Human jason = maria;
        Debug.Log(jason.GetAge());*/

        /*Human Bob = new Adult("Bob", 26, 165.5f);
        Adult tmpA = (Adult)Bob;*/


        Human Alexis = new Adult("alexis", 23, 155);
        Adult adult_alexis = Alexis as Adult;

        if (adult_alexis == null)
        {
            Debug.Log("형변환 실패");
        }
        else
        {
            Debug.Log("형변환 성공");
        }

    }
}

class Adult : Human
{
    public Adult(string _name, int _age, float _height) : base(_name, _age, _height) { }

    public void PrintAddress()
    {
        Debug.Log(Address);
    }
    public int Age;
    public void SetBaseAge(int age)
    {
        base.age = age;
    }

    public int GetBaseAge()
    {
        return base.age;
    }
}

class Baby : Human
{
    public Baby(string _name, int _age, float _height) : base(_name, _age, _height) { }
}