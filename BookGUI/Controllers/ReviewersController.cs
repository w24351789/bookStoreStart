﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookGUI.Services;
using BookGUI.Services.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookGUI.Controllers
{
    public class ReviewersController : Controller
    {
        private readonly IReviewerRepositoryGUI _reviewerRepository;
        private readonly IReviewRepositoryGUI _reviewRepository;

        public ReviewersController(IReviewerRepositoryGUI reviewerRepository, IReviewRepositoryGUI reviewRepository)
        {
            _reviewerRepository = reviewerRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<ActionResult> Index()
        {
            var reviewers = await _reviewerRepository.GetReviewers();

            if(reviewers.Count() <= 0)
            {
                ViewBag.Message = "Did not have any reviewers in database";
            }

            return View(reviewers);
        }
        
        public async Task<ActionResult> GetReviewerById(int reviewerId)
        {
            //欲顯示reviewer 以及其每則review跟所評論的Book
            var reviewer = await _reviewerRepository.GetReviewerById(reviewerId);
            if(reviewer == null)
            {
                ViewBag.Message = $"Did not have {reviewerId}'s Id reviewer";
                ModelState.AddModelError("", "Some Error getting reviewer");
                reviewer = new ReviewerDto();
            }
            //取得
            var reviews = await _reviewerRepository.GetReviewsByAReviewer(reviewerId);
            if(reviews.Count() <= 0)
            {
                ViewBag.ReviewMessage = $"{reviewer.FirstName} {reviewer.LastName} did not have any reviews.";
            }

            IDictionary<ReviewDto, BookDto> reviewAndBook = new Dictionary<ReviewDto, BookDto>();
            foreach(var review in reviews)
            {
                var book = await _reviewRepository.GetBookForAReview(review.Id);
                reviewAndBook.Add(review, book);
            }

            return View(reviewer);
        }
    }
}