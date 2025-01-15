using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using main;

namespace mainweb.Pages
{
    /// <summary>
    /// The PageModel for the Index page.
    /// Handles the logic for the Index Razor page.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Logger for logging messages.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor for IndexModel.
        /// Initializes the logger.
        /// </summary>
        /// <param name="logger">The logger instance to use for logging messages.</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method called on GET requests to the Index page.
        /// Used to handle any logic when the page is requested.
        /// </summary>
        public void OnGet()
        {
            // Currently no logic here for the GET request
        }
    }
}
