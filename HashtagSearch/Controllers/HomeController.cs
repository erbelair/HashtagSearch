﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TwitterClientLibrary.Services;

namespace HashtagSearch.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// We could always let the user select this from the form. For now, let's make it immutable.
		/// </summary>
		private const int TweetsPerPage = 10;

		private ISearchService _searchService;

		public HomeController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		public async Task<ActionResult> Index(string hashtag, long? maxId, long? lowestId, string first, string next, string oldHashtag)
		{
			// We could use a library such as FluentValidation to separate our validation logic here.
			var hasHashtag = !string.IsNullOrWhiteSpace(hashtag);

			if (Request.IsAjaxRequest())
			{
				if (hasHashtag)
				{
					if (!string.IsNullOrEmpty(next) && oldHashtag == hashtag)
					{
						maxId = lowestId - 1;
					}
					else if (!string.IsNullOrEmpty(first))
					{
						maxId = null;
					}

					return PartialView("TweetList", await _searchService.GetByHashtagAsync(hashtag, TweetsPerPage, maxId));
				}

				return PartialView("TweetList", null);
			}
			else if (hasHashtag)
			{
				ViewBag.Hashtag = hashtag;

				return View(await _searchService.GetByHashtagAsync(hashtag, TweetsPerPage, maxId));
			}

			return View();
		}
	}
}
