using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NGEntity;

namespace NG
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
        {

        }
    }

    public class Teste
    {
        public void Test()
        {
            using var context = new BloggingContext();
            // Load all blogs, all related posts, and all related comments.
            var blogs1 = context.Set<Blog>()
                                .Include(b => new { b.Tags, b.Name })
                                .Where(w=> w.BlogId == 1)
                                .ToList();
        }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<string> Posts { get; set; }
    }
}
