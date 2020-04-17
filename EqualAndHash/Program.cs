using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualAndHash
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode a = new ListNode(1);
            ListNode b = new ListNode(1);
            //ListNode b = a;

            Dictionary<object, object> d = new Dictionary<object, object>();
            d.Add(a, a);
            d.Add(b, b);

            if (a == b)
            {
                Console.WriteLine();
            }

            var h = a.GetHashCode();
            var h1 = a.GetHashCode();
            var h2 = b.GetHashCode();
            var res = d[a].Equals(d[b]);

            BookTest bt = new BookTest();
            bt.shouldTwoBookWithSameNameAuthor_return_equal();
        }

        public class Book
        {
            private String name;
            private String author;

            public Book(String name, String author)
            {
                this.name = name;
                this.author = author;
            }

            public override bool Equals(object o)
            {
                if (this == o) return true;
                if (o == null || this != o) return false;

                Book book = (Book)o;

                if (author != null ? !author.Equals(book.author) : book.author != null) return false;
                if (name != null ? !name.Equals(book.name) : book.name != null) return false;

                return true;
            }

            public override int GetHashCode()
            {
                int result = name != null ? name.GetHashCode() : 0;
                result = 31 * result + (author != null ? author.GetHashCode() : 0);
                return result;
            }
        }
        public class BookTest
        {
            public void shouldTwoBookWithSameNameAuthor_return_equal()
            {
                Book oneBook = new Book("A Book", "Jim");
                Book anotherBook = new Book("A Book", "Jim");

                oneBook.Equals(anotherBook);
                var a = oneBook.GetHashCode();
                var b = anotherBook.GetHashCode();
                // assertEquals(oneBook, anotherBook);
            }
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
