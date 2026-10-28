using UnityEngine;

public class InheritanceExample : MonoBehaviour
{
    private void Start()
    {
        // »ó¼Ó
        Adult john = new Adult("john", 28, 173f);
        Baby lisa = new Baby("lisa", 3, 95f);

        Debug.Log(john.age);
        lisa.Sleep();
    }
}

class Adult : Human
{
    public Adult(string _name, int _age, float _height) : base(_name, _age, _height) { }
}

class Baby : Human
{
    public Baby(string _name, int _age, float _height) : base(_name, _age, _height) { }
}