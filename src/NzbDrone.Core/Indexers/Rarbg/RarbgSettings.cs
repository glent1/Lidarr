using System;
using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Indexers.Rarbg
{
    public class RarbgSettingsValidator : AbstractValidator<RarbgSettings>
    {
        public RarbgSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).ValidRootUrl();
        }
    }

    public class RarbgSettings : IProviderConfig
    {
        private static readonly RarbgSettingsValidator Validator = new RarbgSettingsValidator();

        public RarbgSettings()
        {
            BaseUrl = "https://torrentapi.org";
            RankedOnly = false;
        }

        [FieldDefinition(0, Label = "API URL", HelpText = "URL to Rarbg api, not the website.")]
        public string BaseUrl { get; set; }

        [FieldDefinition(1, Label = "Ranked Only", HelpText = "Only include ranked results.")]
        public bool RankedOnly { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}