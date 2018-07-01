using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.ViewModels
{
    class EducationTabViewModel :Screen
    {
        private DebugLog _logger = new DebugLog(typeof(EducationTabViewModel));

        public EducationTabViewModel()
        {
            DisplayName = "Education History";

            Activated += EducationTabViewModel_Activated;
            Deactivated += EducationTabViewModel_Deactivated;
        }

        private void EducationTabViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            _logger.Info("EducationTabViewModel was deactivated");
        }

        private void EducationTabViewModel_Activated(object sender, ActivationEventArgs e)
        {
            _logger.Info("EducationTabViewModel was activated");
        }
    }
}
