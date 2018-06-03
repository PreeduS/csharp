using System;
using System.Collections.Generic;
using System.Linq;

namespace Select
{
    class Program
    {
        static void Main(string[] args)
        {

            GetAllComments().Select(x => x.Content).ToList().ForEach(x => Console.WriteLine(x) );

            Console.WriteLine();
            GetAllComments().SelectMany(x => x.Replies).ToList().ForEach(x => Console.WriteLine(x.Content) );

            Console.WriteLine();
            GetAllComments().Select(x => x.Replies).ToList().ForEach(x => {
                x.ForEach(y => Console.WriteLine(y.Content) );
                Console.WriteLine("---"); 

            });

            //sqlike syntax
            Console.WriteLine("Content: ");
            IEnumerable<string> c = (from comment in GetAllComments()
                                    from reply in comment.Replies
                                    select reply.Content).Distinct();
            c.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Content2: ");
            var c2 = from comment in GetAllComments()
                    from reply in comment.Replies
                    select new{
                        CommentContent = comment.Content,
                        ReplyContent = reply.Content
                    };
             c2.ToList().ForEach(x => Console.WriteLine(x));

        }



        static List<Comment> GetAllComments(){
            return new List<Comment>(){
                new Comment{
                    Id = 1, 
                    Content = "content",
                    Replies = new List<Replies>{
                        new Replies{Id = 2, Content  = "reply 1"},
                        new Replies{Id = 3, Content  = "reply 2"},
                        //new Replies{Id = 4, Content  = "reply 3"},
                        //new Replies{Id = 5, Content  = "reply 4"}
                    }
                },
                new Comment{
                    Id = 6, 
                    Content = "content2",
                    Replies = new List<Replies>{
                        new Replies{Id = 7, Content  = "replyb 5"},
                        new Replies{Id = 8, Content  = "replyb 2"},
                        //new Replies{Id = 9, Content  = "replyb 3"}
                    }
                }

            };
        }

        
    }

    public class Comment{
        public int Id;
        public string Content;
        public List<Replies> Replies;
    }
    public class Replies{
        public int Id;
        public string Content;       
    }

}
