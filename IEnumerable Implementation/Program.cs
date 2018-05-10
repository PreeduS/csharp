using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerable_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MeList<int>(){1, 2, 3};  //Add method is used by default when IEnumerable is implemented

            list.Add(11);
            list.Add(12);
            list.Add(13);
         
            //IEnumerator<int> ienum = list.GetEnumerator();
            //ienum.MoveNext(); Console.WriteLine(ienum.Current);

            foreach(var i in list){
                Console.WriteLine(i);
            }

        }
       
    }

    public class MeList<T> : IEnumerable<T>{
        private T[] items = new T[1];
        private int count = 0;
        
        public void Add(T item){
            if(count == items.Length){
                Array.Resize(ref items, items.Length + 1 );
            }
            items[count++] = item;

        }

        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }

        //new syntax
        /*public IEnumerator<T> GetEnumerator(){
            for(int i = 0; i < count; i++){
                yield return items[i];
            }
        }*/

        //old syntax
        public IEnumerator<T> GetEnumerator(){
            return new MeEnumerator(this);
        }


        class MeEnumerator : IEnumerator<T>
        {
            private readonly MeList<T> Array;
            private int index = -1;

            public MeEnumerator(MeList<T> array){
                Array = array;
            }
            public T Current{
                get { return Array[index]; }
            }

            object IEnumerator.Current{
                get{ return Current; }
            }

            public void Dispose(){
                //throw new NotImplementedException();
            }

            public bool MoveNext(){
                index++;
                return index < Array.count;
            }

            public void Reset(){
                index = -1;
            }
        }


        public T this[int index]{
            get{ return items[index]; }
        }
    }

}
