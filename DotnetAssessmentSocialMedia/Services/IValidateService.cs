using DotnetAssessmentSocialMedia.Dtos;

namespace DotnetAssessmentSocialMedia.Controllers
{
    public interface IValidateService
    {
        bool AvailableUsername(string username);
        bool ExistUsername(string username);
        bool ExistTag(string label);
        bool UsernameMatchCredentials(string username, CredentialsDto credentials);
    }
}