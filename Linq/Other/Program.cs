using System;
using System.Collections.Generic;
using System.Linq;

namespace Other
{
    class Program
    {
        static void Main(string[] args)
        {
            //Groups
            GetData().GroupBy(x => x.Genre).ToList().ForEach(x => {
                Console.WriteLine("Key: " + x.Key);
                GetData().Where(y => y.Genre == x.Key).ToList().ForEach(y => 
                    Console.WriteLine("Name: " + y.Name)
                );
            }); 

            Console.WriteLine();

            GetData().GroupBy(x => new{x.Genre, x.Year})
            .OrderByDescending(x => x.Key.Year).ThenBy(x => x.Key.Genre)
            .Select(g => new {
                Genre = g.Key.Genre,
                Year = g.Key.Year,
                Movie = g.OrderBy(x => x.Name)
            }).ToList().ForEach(y =>{ 
                    Console.WriteLine($"{y.Genre}/{y.Year} | {y.Movie.Count()}");    
                    y.Movie.ToList().ForEach(m => Console.WriteLine("Name: "+ m.Name));
            });

            Console.WriteLine();

            (from d in GetData() 
                group d by d.Genre into gr
                from d2 in gr
                select new { 
                    Key  = gr.Key,
                    Name = d2.Name
                }).ToList().ForEach( x =>{
                    Console.WriteLine("Key: " + x.Key);
                    Console.WriteLine("Name: " + x.Name);                    
                });

            /*foreach(var i in data){
                  Console.WriteLine("\tKey: " + i.Key);
                  Console.WriteLine("\tName: " + i.Name);
            }*/
    
        }
        static List<Movies> GetData(){
            return new List<Movies>{
                new Movies{ Name = "Name 1", Genre = "SF" ,Year = 2000},
                new Movies{ Name = "Name 2", Genre = "SF" , Year = 2010},
                new Movies{ Name = "Name 3", Genre = "ACTION", Year = 1990},
                new Movies{ Name = "Name 4", Genre = "SF" , Year = 2000}
            };
        }

    }
    class Movies{
        public string Name, Genre;
        public int Year;
    }
}
