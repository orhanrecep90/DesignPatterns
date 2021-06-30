using System;

namespace Prototype
{
    public class Category
    {
        public int RowNumber { get; set; }
        public string CategoryName { get; set; }
    }

    public class BlogPost
    {
        public DateTime CreateTime { get; set; }
        public string Header { get; set; }
        public bool Status { get; set; }
        public Category BlogCategory { get; set; }
        public BlogPost ShallowCopy()
        {
            return (BlogPost)this.MemberwiseClone();
        }
        public BlogPost DeepCopy()
        {
            BlogPost clone = (BlogPost)this.MemberwiseClone();
            clone.BlogCategory = new Category { RowNumber = BlogCategory.RowNumber, CategoryName = BlogCategory.CategoryName };
            return clone;
        }
        public override string ToString()
        {
            return $"Header={Header}, CreateTime={CreateTime}, Status={Status}, BlogCategory.CategoryName={BlogCategory.CategoryName}, BlogCategory.RowNumber={BlogCategory.RowNumber}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BlogPost blog1 = new BlogPost
            {
                CreateTime = new DateTime(2021, 5, 10),
                Header = "Prototype ",
                Status = false,
                BlogCategory = new Category
                {
                    CategoryName = "Design Patterns",
                    RowNumber = 1
                }
            };
            var shallowBlog = blog1.ShallowCopy();
            var deepBlog = blog1.DeepCopy();

            Console.WriteLine("blog1       " + blog1.ToString());
            Console.WriteLine("shallowBlog " + shallowBlog.ToString());
            Console.WriteLine("deepBlog    " + deepBlog.ToString());

            blog1.CreateTime = new DateTime(2000, 1, 1);
            blog1.Header = "Discipline";
            blog1.Status = true;
            blog1.BlogCategory.CategoryName = "Self-improvement";
            blog1.BlogCategory.RowNumber = 2;
            Console.WriteLine("****After blog1 values were changed****");
            Console.WriteLine("blog1       " + blog1.ToString());
            Console.WriteLine("shallowBlog " + shallowBlog.ToString());
            Console.WriteLine("deepBlog    " + deepBlog.ToString());
            Console.ReadLine();


        }
    }
}
