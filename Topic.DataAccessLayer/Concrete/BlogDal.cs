using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Concrete
{
    public class BlogDal : GenericRepository<Blog>, IBlogDal
    {
        public BlogDal(TopicContext context) : base(context)
        {
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.Category).ToList();    //blogları listelerken kategori id si değil ismi gözükmesi için bu metodu yazdık.
        }
    }
}
