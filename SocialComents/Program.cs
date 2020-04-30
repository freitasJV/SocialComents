using SocialComents.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SocialComents
{
    class Program
    {
        static void Main(string[] args)
        {
            String continuar;
            List<Post> posts = new List<Post>();

            do
            {
                Console.Write("Digite o título do post: ");
                string title = Console.ReadLine();

                Console.Write("Digite o contéudo: ");
                string content = Console.ReadLine();

                Post post = new Post
                {
                    Title = title,
                    Content = content,
                    Moment = DateTime.Now,
                    Likes = 5
                };

                string capture;
                do
                {
                    Console.Write("Caso queira incluir um comentária é só digitá-lo e apertar enter, caso contrário apenas aperte enter, deixando o comentário vazio: ");
                    capture = Console.ReadLine();

                    if (!String.IsNullOrWhiteSpace(capture))
                    {
                        Comment comment = new Comment(capture);
                        post.AddComment(comment);
                    }
                } while (!String.IsNullOrWhiteSpace(capture));

                posts.Add(post);

                Console.Write("Digite a palavra sim para criar outro post: ");
                continuar = Console.ReadLine();
                Console.Clear();
            } while (continuar.ToUpper().Equals("SIM"));

            foreach(Post p in posts)
            {
                Console.WriteLine(p);
            }
        }
    }
}
