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

        public int GetBlogCount()
        {
			return _context.Blogs.Count();
        }

        public List<Blog> GetBlogsByCategoryId(int id)
		{
			return _context.Blogs.Where(x => x.CategoryId == id).ToList();
		}

		public List<Blog> GetBlogsWithCategories()
		{
			return _context.Blogs.Include(x => x.Category).ToList();    //blogları listelerken kategori id si değil ismi gözükmesi için bu metodu yazdık.
		}

		public Blog GetBlogWithCategoryById(int id)	//id ye göre tek değer dönüyor metodda. Include:dahil et demek. yani blogları getirirken kategorilerini de dahil et.
		{
			return _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.BlogId == id);
		}
	}
}
