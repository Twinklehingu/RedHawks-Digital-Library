using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Abstract class defined for page.
    /// </summary>
    public class ContactUSModel : PageModel
    {
        private readonly ILogger<ContactUSModel> _logger;
        /// <summary>
        /// default constructer is created.
        /// </summary>
        /// <param name="logger"></param>
        public ContactUSModel(ILogger<ContactUSModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet method to get the requestID from user activity. ////new change
        /// </summary>
        public void OnGet() {}
    }
}