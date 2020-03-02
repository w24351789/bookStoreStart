namespace BookGUI.Infrastructure
{
    public static class API
    {
        public static class Country
        {
            public static string GetCountries(string baseUri) => $"{baseUri}/countries";
            public static string GetCountryById(string baseUri, int countryId) => $"{baseUri}/countries/{countryId}";
            public static string GetAuthorsFromCountry(string baseUri, int countryId) => $"{baseUri}/countries/{countryId}/authors";

            public static string GetCountryFromAnAuthor(string baseUri, int authorId) => $"{baseUri}/countries/authors/{authorId}";
        }

        public static class Category
        {
            public static string GetCategories(string baseUri) => $"{baseUri}/categories";
            public static string GetCategoryById(string baseUri, int categoryId) => $"{baseUri}/categories/{categoryId}";
            public static string GetBooksFromACategory(string baseUri, int categoryId) => $"{baseUri}/categories/{categoryId}/books";
            public static string GetCategoryOfABook(string baseUri, int bookId) => $"{baseUri}/categories/books/{bookId}";
        }

        public static class Reviewer
        {
            public static string GetReviewers(string baseUri) => $"{baseUri}/reviewers";
            public static string GetReviewerById(string baseUri, int reviewerId) => $"{baseUri}/reviewers/{reviewerId}";
            public static string GetReviewerByAReview(string baseUri, int reviewId) => $"{baseUri}/reviewers/{reviewId}/reviewer";
            public static string GetReviewsByAReviewer(string baseUri, int reviewerId) => $"{baseUri}/reviewers/{reviewerId}/reviews";
        }

        public static class Review
        {
            public static string GetReviews(string baseUri) => $"{baseUri}/reviews";
            public static string GetReviewById(string baseUri, int reviewId) => $"{baseUri}/reviews/{reviewId}";

            public static string GetReviewsForABook(string baseUri, int bookId) => 
        }
    }
}
