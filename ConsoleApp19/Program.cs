//using System.Collections.Generic;

//class Program
//{
//    public class MyEvent : EventArgs
//    {
//        public string Message { get; set; }
//        public MyEvent(string message)
//        {
//            Message = message;
//        }
//    }

//    public class EventSource
//    {
//        public event EventHandler<MyEvent> MyEvent;

//        public void RaisEvent()
//        {
//            OnMyEvent(new MyEvent("alert"));
//        }
//        public virtual void OnMyEvent(MyEvent e)
//        {
//            MyEvent?.Invoke(this, e);
//        }
//    }

//    public class EventSubscriber
//    {
//        public EventSubscriber(EventSource eventSource)
//        {
//            eventSource.MyEvent += HandleEvent;
//        }
//        public void HandleEvent(object sender, MyEvent e)
//        {
//            Console.WriteLine("Recieved: " + e.Message);
//        }
//    }

//    public static void Main(string[] args)
//    {
//        EventSource source = new EventSource();
//        EventSubscriber subscriber = new EventSubscriber(source);
//        source.RaisEvent();
//    }
//}




public delegate void ButtonClickEvent();

public class EventManager
{
    private Dictionary<Type, List<Delegate>> eventHandler;

    public EventManager()
    {
        eventHandler = new Dictionary<Type, List<Delegate>>();
    }
    public void AddEventHandler<T>(T eventType, Action eventhandler) where T : Delegate
    {
        if (!eventHandler.ContainsKey(typeof(T))){
            eventHandler[typeof(T)] = new List<Delegate>();
        }
        eventHandler[typeof(T)].Add(eventhandler);
    }
}
