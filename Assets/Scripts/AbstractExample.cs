
using System.Drawing;
using UnityEngine;

public class AbstractExample : MonoBehaviour
{
    void Start()
    {
        Bird eagle = new Bird();
        Fish shark = new Fish();
        eagle.Move();
        shark.Move();
    }
}

abstract class Animal
{
    public abstract void Move();

    public void Eat()
    {
        Debug.Log("eat");
    }
}

class Bird : Animal
{
    public override void Move()
    {
        Debug.Log("fly");
    }
}

class Fish : Animal
{
    public override void Move()
    {
        Debug.Log("swim");
    }
}

public class StructExample : MonoBehaviour 
{ 
    void Start() 
    {
        Point_struct point = new Point_struct(1, 1);
        Debug.Log(point.GetPoint()); 
    }

    struct Point_struct
    {
        public int x; // int x = 1; 초기화 불가능
        public int y;
        // public int z; // 변수 z가 생성자에서 값이 할당되지 않음(오류)

        public Point_struct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string GetPoint()
        {
            return $"({x}, {y})";
        }
    }
}