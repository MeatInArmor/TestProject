using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyList
{
    private int[] m_array = new int[4];

    public int Count { get;  set; }
    public int Capacity { get; set; }

    public MyList()
    {
        
    }

    public MyList(int capacity)
    {
        Capacity = capacity;
    }

    public int this[int index]
    {
        get { return m_array[index]; }
        set { m_array[index] = value; }
    }

    public void Add(int item)
    {
        m_array[this.Count++] = item;
        Debug.Log($"element {item} added on {this.Count-1} position");

    }

    public void Insert(int index, int item)
    {
        this.Count++;
        for(int i = this.Count-1; i > index; --i)
            m_array[i] = m_array[i-1];
        m_array[index] = item;
        Debug.Log($"element {item} inserted on {index} position");

    }

    public int IndexOf(int item)
    {
        for (int i= 0; i < this.Count; ++i)
            if (m_array[i] == item)
                return i;
        return -1;
    }

    public bool Remove(int item)
    {
        while(IndexOf(item) != -1)
            RemoveAt(IndexOf(item));
        Debug.Log($"all elements {item} removed from array");
        return false;
    }

    public void RemoveAt(int index)
    {
        int removedElement = m_array[index];
        for (int i = index; i < this.Count; ++i)
                m_array[i] = m_array[i+1];
        this.Count--;
        Debug.Log($"element {removedElement} removed from {index} position");
    }

    public bool Contains(int item)
    {
        for (int i= 0; i < this.Count; ++i)
            if(m_array[i] == item)
                return true;
        return false;
    }
    
    public void Clear()
    {
        while(this.Count != 0)
        {
            this.RemoveAt(this.Count - 1);
        }
    }
    public void Rebuild()
    {
        m_array = new int[this.Capacity];
    }
}
  

public class Script : MonoBehaviour
{
    GameObject textObject;
    MyList myList;
    private void Start()
    {
        textObject = this.gameObject;
        myList = new MyList();
        myList.Capacity = 4; 

        myList.Add(1);
        myList.Add(5);
        myList.Insert(1, 8);

        ShowList();

        Debug.Log(myList.Capacity);

        myList.Remove(8);
        myList.RemoveAt(0);
        
        ShowList();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(myList.Count < myList.Capacity)
            {
                int newElem = Random.Range(0, 10);
                myList.Add(newElem);
            }
            else
                Debug.Log($"array is full. clear it wits \"C\" key or delete last element with \"D\" key");
                
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log($"you can increase array's capacity if it is empty. total capacity: {myList.Capacity}");
            if(myList.Count == 0)
            {
                myList.Capacity++;
                myList.Rebuild();
                Debug.Log($"array's capacity increased. total capacity: {myList.Capacity}");
            }
            else
                Debug.Log($"array's capacity don't increased. array is not empty");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(myList.Count == myList.Capacity)
                myList.Count--; //  ???
            myList.Clear();
            Debug.Log($"array was cleared with {myList.Capacity} free element space");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(myList.Count == myList.Capacity)
                myList.Count--; //  ???

            if(myList.Count != 0)
                myList.RemoveAt(myList.Count-1);
            else
                Debug.Log($"array is empty already");

        }
        if(Input.GetKeyDown(KeyCode.S))
            ShowList();
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (myList.Contains(1))
                Debug.Log($"element \"1\" is in array");
            else
                Debug.Log($"there are no elements \"1\" in array");
        }
    }
    private void ShowList()
    {
        for (int i= 0; i < myList.Count; ++i)
            Debug.Log($"{myList[i]} ");
        Debug.Log($"elements count: {myList.Count}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Portal p))
        {
            textObject.transform.position = new Vector2(0, 8);
            textObject.GetComponent<Rigidbody2D>().Sleep();

        }
    }
    
}
