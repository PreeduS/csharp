using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Delegate
            var subs = new Subs();

            new User("u1").Upload(subs);
            new User("u2").Upload(subs);
            new User("u3").Upload(subs);
            subs.Uploads = null;
            subs.Uploads += () => { Console.WriteLine("reset"); };
            new User("u4").Upload(subs);

            subs.Uploads();

            Console.WriteLine();

            //Event
            //only -=, += ; no direct call outside class
            var subsEvent = new SubsEvent();
            subsEvent.Uploads += () => { Console.WriteLine("Ev1"); };
            subsEvent.Uploads += () => { Console.WriteLine("Ev2"); };

            subsEvent.GetUploads();

            var subsEvent2 = new SubsEvent2();
            subsEvent2.Uploads += (object s, EventArgs e) => { Console.WriteLine("Evh1"); };
            subsEvent2.Uploads += (object s, EventArgs e) => { Console.WriteLine("Evh2"); };

            subsEvent2.GetUploads();


        }
    }

    public class Subs{
        public Action Uploads;
    }

    public class User{
        private readonly string Name;
        public User(string name){Name = name;}
        public void Upload(Subs s){
            s.Uploads += ()=> { Console.WriteLine($"{Name} uploaded" ); };
        }
    }

    public class SubsEvent{
        public event Action Uploads;
        
        public SubsEvent(){
            Uploads = () => { Console.WriteLine("Ev ctor"); };     //= allowed only under type
        }
        public void GetUploads(){
            Uploads();
        }
        
    }

    //EventHandler, same thing...
    public class SubsEvent2{
        public event EventHandler Uploads;

        public SubsEvent2(){
             Uploads = (object s, EventArgs e) => { Console.WriteLine("\nEv ctor 2"); };    
        }
        public void GetUploads() => Uploads(this, EventArgs.Empty);
        
    }


}
