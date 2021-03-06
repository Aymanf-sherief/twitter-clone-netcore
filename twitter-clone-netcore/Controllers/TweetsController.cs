﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitter_clone_netcore.Models;

namespace twitter_clone_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly TwitterCloneContext _context;

        public TweetsController(TwitterCloneContext context)
        {
            _context = context;
        }

        // GET: api/Tweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
        {
            return await _context.Tweets.ToListAsync();
        }

        // GET: api/Tweets/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Tweet>> GetTweet(int id)
        {
            var tweet = await _context.Tweets.FindAsync(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        // PUT: api/Tweets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<IActionResult> PutTweet(int id, Tweet tweet)
        {
            if (id != tweet.ID)
            {
                return BadRequest();
            }

            _context.Entry(tweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tweets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
        {
            User currentUser = _context.Users.Find(int.Parse(User.Identity.Name));
            tweet.User = currentUser;
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTweet", new { id = tweet.ID }, tweet);
        }

        // DELETE: api/Tweets/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Tweet>> DeleteTweet(int id)
        {
            var tweet = await _context.Tweets.FindAsync(id);
            if (tweet == null)
            {
                return NotFound();
            }

            _context.Tweets.Remove(tweet);
            await _context.SaveChangesAsync();

            return tweet;
        }

        private bool TweetExists(int id)
        {
            return _context.Tweets.Any(e => e.ID == id);
        }
    }
}
