﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RedditSharpTests.Things
{
    [Collection("AuthenticatedTests")]
    public class SubredditTests
    {
        private AuthenticatedTestsFixture authFixture;
        public SubredditTests(AuthenticatedTestsFixture authenticatedFixture)
        {
            authFixture = authenticatedFixture;
        }

        [Fact]
        public async Task GetContributors()
        {
            RedditSharp.WebAgent agent = new RedditSharp.WebAgent(authFixture.AccessToken);
            RedditSharp.Reddit reddit = new RedditSharp.Reddit(agent);
            var sub = await reddit.GetSubredditAsync(authFixture.Config["TestSubreddit"]);
            var contribs = await sub.GetContributors().ToList();

            Assert.NotEmpty(contribs);
            Assert.Contains<string>(authFixture.TestUserName.ToLower(), contribs.Select(c => c.Name.ToLower()));
        }
        
        [Fact]
        public async Task SubmitPost()
        {
            RedditSharp.WebAgent agent = new RedditSharp.WebAgent(authFixture.AccessToken);
            RedditSharp.Reddit reddit = new RedditSharp.Reddit(agent,true);

            var sub = await reddit.GetSubredditAsync(authFixture.Config["TestSubreddit"]);
            var post = await sub.SubmitPostAsync("ThisIsASubmittedPost", "https://github.com/CrustyJew/RedditSharp/issues/76", resubmit:true);
            Assert.NotNull(post);
            await post.DelAsync();
        }

        [Fact]
        public async Task GetRALLComments() 
        {
            RedditSharp.WebAgent agent = new RedditSharp.WebAgent(authFixture.AccessToken);
            RedditSharp.Reddit reddit = new RedditSharp.Reddit(agent, true);

            var comments = reddit.RSlashAll.GetComments(5);
            Assert.Equal(5, await comments.Count());
        }

        [Fact]
        public async Task PageComments() {
            RedditSharp.WebAgent agent = new RedditSharp.WebAgent(authFixture.AccessToken);
            RedditSharp.Reddit reddit = new RedditSharp.Reddit(agent, true);

            var comments = await reddit.RSlashAll.GetComments().Take(55).ToList();

            Assert.Equal(55, comments.Count);
            
        }
    }
}
