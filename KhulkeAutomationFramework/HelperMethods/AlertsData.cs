using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.HelperMethods
{
    internal class AlertsData
    {

        public static Dictionary<string, string> allAlerts = new Dictionary<string, string>(){
            {"MobileValidationAlert", "Please enter a valid no."},
            {"EmailWithoutDotComAlert", "invalid data"},
            {"PostCreatedAlert", "Your post has been created."},
            {"PostDeletedAlert","Successfully Deleted" },
            {"TextPostSizeLimitAlert","" },
            {"TextBlankPostAlert","" },
            {"AudioBlankPostAlert","" },
            {"AudioBigSizeALert","Upload a file less than 250 MB" },
            {"AudioTimeLimitAlert","Max. duration for Audio should be 2min 30sec only." },
            {"VideoBlankPostAlert","" },
            {"VideoBigSizeALert","Upload a file less than 15 MB" },
            {"VideoTimeLimitAlert","Max. duration for Video should be 2min 30sec only." },
            {"DocBlankPostAlert","" },
            {"DocBigSizeALert","Upload a file less than 15 MB" },
            {"ImageBlankPostAlert","" },
            {"ImageBigSizeALert","Upload a file less than 15 MB" },
            {"SharePostAlert","Successfully Copied!" },
            {"BlankPost","Enter some value" },
            {"InvalidUser","You are not registered with us. Kindly create an account to login." },
            {"InvalidPassword","Username or password not correct." }
        };
       

    }
}
