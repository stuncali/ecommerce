using System.Collections.Generic;

namespace Ecommerce.Web.Models
{
    public class BaseViewModel
    {
        public BaseViewModel(){
            ErrorMessages = new List<string>();
            WarningMessages = new List<string>();
        }

        public string SuccessMessage { get; set; }

        public List<string> ErrorMessages { get; set; }

        public List<string> WarningMessages { get; set; }
    }
}
