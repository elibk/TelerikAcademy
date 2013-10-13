using Forum.Data;
using Forum.Models;
using Forum.Services.Attributes;
using Forum.Services.Controllers;
using Forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Forum.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private ForumContext db = new ForumContext();

         ////GET api/Posts
        public IQueryable<PostDetails> GetPosts([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();
            CheckSession(context, sessionKey);

            return this.GetPosts();
        }

        [ActionName("post")]
        public PostDetails GetPost(int id,[ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();
            CheckSession(context, sessionKey);

            return this.GetPosts().FirstOrDefault(x => x.Id == id);
        }

        //api/threads?sessionKey=.......&page=5&count=3
        public IQueryable<PostDetails> GetPosts(int page, int count,
           [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();
            CheckSession(context, sessionKey);
            var models = this.GetPosts()
                .Skip(page * count)
                .Take(count);
            return models;
        }


        //api/posts?keyword=web-services
        public IQueryable<PostDetails> GetPosts(string keyword, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var keywordToLower = keyword.ToLower();

            var context = new ForumContext();
            CheckSession(context, sessionKey);

            var postEntities =this.GetPosts();
            var models =
               (from post in postEntities
                         where (post.Tags.Where(t => t == keywordToLower).Count() > 0)
                         select post);

            return models;
        }

        //GET api/posts?tags=web,webapi
        public IQueryable<PostDetails> GetPostsTags(string tags, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var context = new ForumContext();
            CheckSession(context, sessionKey);

            IEnumerable<string> keywords = tags.Split(new char[]{',',' '}, StringSplitOptions.RemoveEmptyEntries);
            IQueryable<PostDetails> models = this.GetPosts();
            foreach (var keyword in keywords)
            {
                var keywordToLower = keyword.ToLower();

                models = (from post in models
                          where (post.Tags.Where(t => t == keywordToLower).Count() > 0) select post);

            }

            return models;
        }


//{ "title": "NEW POST",
//  "tags": ["post"],
//  "text": "this is just a test post" }

        // POST api/Posts
        public HttpResponseMessage PostPost(PostModel post, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new ForumContext();
                    using (context)
                    {
                         var user = CheckSession(context, sessionKey);

                        var newPost = new Post()
                        {
                            Title = post.Title,
                            PostDate = DateTime.Now,
                            Content = post.Content,
                            User = user,
                            
                        };

                        context.Posts.Add(newPost);
                        context.SaveChanges();

                        var tagTitlesFromTheTitle = post.Title.Split(new char[] {' ', '.', '!', '?', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        tagTitlesFromTheTitle.AddRange(post.Tags);

                        var loadedTags = new List<string>();

                        //var tran = new TransactionScope(
                            //TransactionScopeOption.RequiresNew, new TransactionOptions() 
                           // { IsolationLevel = IsolationLevel.ReadUncommitted});
                        //using (tran)
                       // {
                        foreach (var tagTitle in tagTitlesFromTheTitle)
                            {
                                var tagTitleToLower = tagTitle.ToLower();

                                var currentTag = context.Tags.FirstOrDefault(t => t.Title == tagTitleToLower);


                                if (currentTag == null)
                                {
                                    context.Tags.Add( new Tag{ Title = tagTitleToLower} );
                                    context.SaveChanges();
                                    currentTag = context.Tags.FirstOrDefault(t => t.Title == tagTitleToLower);
                                }

                               // Debug.Assert(currentTag != null);

                                currentTag.Posts.Add(newPost);

                               // loadedTags.Add(currentTag);
                                context.SaveChanges();
                            }

                           // tran.Complete();
                        //}

                       // newPost.Tags = loadedTags;
                        

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                post);
                        return response;
                    }
                });

            return responseMsg;
        }


        //Put api/posts/{postId}/comment
        [ActionName("comment")]
        public HttpResponseMessage PutComment(int postId, [FromBody]CommentModel comment, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new ForumContext();
                    using (context)
                    {
                        var user = CheckSession(context, sessionKey);

                       
                        var post = (from p in context.Posts
                                    where (p.Id == postId)
                                    select p).FirstOrDefault();

                        if (post == null)
                        {
                            throw new InvalidOperationException("No post found.");
                        }

                        var newComment = new Comment()
                        {
                            Text = comment.Text,
                            User = user,
                            PostDate = DateTime.Now,
                            Post = post
                        };


                        context.Comments.Add(newComment);

                        context.SaveChanges();

                        post.Comments.Add(newComment);

                        context.SaveChanges();
                        var response =
                            this.Request.CreateResponse(HttpStatusCode.OK, string.Empty);
                        return response;
                    }
                });

            return responseMsg;
        }

        private User CheckSession(ForumContext context, string sessionKey)
        {
          //  var sessionKey = this.Request.Headers.GetValues("X-sessionKey").FirstOrDefault();

            if (sessionKey == null)
            {
                throw new InvalidOperationException("No session key found.");
            }

            var user = context.Users.FirstOrDefault(
                usr => usr.SessionKey == sessionKey);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid session key.");
            }

            return user;
        }

//// GET api/Posts
        private IQueryable<PostDetails> GetPosts()
        {
            var context = new ForumContext();

          

            var postEntities = context.Posts;
            var models =
                (from post in postEntities
                 select new PostDetails()
                 {
                     Id = post.Id,
                     Title = post.Title,
                     PostDate = post.PostDate,
                     Content = post.Content,
                     CreatedBy = post.User.DisplayName,
                     Comments = (from commentEntity in post.Comments
                                 select new CommentModel()
                                 {
                                     Text = commentEntity.Text,
                                     CreatedBy = commentEntity.User.DisplayName,
                                     PostDate = commentEntity.PostDate
                                 }),
                     Tags = (from tagEntity in post.Tags
                             orderby tagEntity.Title
                             select tagEntity.Title)
                 });
            return models.OrderByDescending(p => p.PostDate);


        }
    }
}