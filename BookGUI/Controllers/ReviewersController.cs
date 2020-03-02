using System;
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

        public ReviewersController(IReviewerRepositoryGUI reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
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
            var reviewer = await _reviewerRepository.GetReviewerById(reviewerId);
            if(reviewer == null)
            {
                ViewBag.Message = $"Did not have {reviewerId}'s Id reviewer";
                ModelState.AddModelError("", "Some Error getting reviewer");
                reviewer = new ReviewerDto();
            }

            return View(reviewer);
        }
    }
}