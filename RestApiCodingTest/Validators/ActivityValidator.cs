using RestApiCodingTest.Request;
using RestApiCodingTest.Models;

namespace RestApiCodingTest.Validators
{
    public interface IActivityValidator
    {
        string Validate(ActivityRequest activity);
        string Validate(Activity activity, UpdateActivityRequest dto);
    }

    public class ActivityValidator : IActivityValidator
    {
        public string Validate(ActivityRequest activity)
        {
           if(activity == null)
           {
                return "Activity cannot be null";
           }

            if (string.IsNullOrEmpty(activity.Name))
            {
                return "Activity Name cannot be empty";
            }

           if(activity.StaffId == Guid.Empty)
           {
                return "Activity Staff Id cannot be empty";
           }

           if (activity.MatterId == Guid.Empty)
           {
                return "Activity Matter Id cannot be empty";
           }

           if(activity.Type == ActivityType.Unknown)
           {
                return "Activity Type can not be Unknown";
           }

           if(activity.DateTimeFinished < activity.DateTimeStarted)
           {
                return "Activity End Date and Time cannot be before Start Date and Time";
           }

            if (activity.DateTimeStarted > activity.DateTimeFinished)
            {
                return "Activity Start Date and Time cannot be after End Date and Time";
            }

            return string.Empty;
        }

        public string Validate(Activity activity, UpdateActivityRequest dto)
        {
            if (dto == null)
            {
                return "Activity cannot be null";
            }

            if (dto.DateTimeFinished.HasValue && dto.DateTimeStarted.HasValue && dto.DateTimeFinished < dto.DateTimeStarted)
            {
                return "Activity End Date and Time cannot be before Start Date and Time";
            }

            if (dto.DateTimeFinished.HasValue && !dto.DateTimeStarted.HasValue && dto.DateTimeFinished < activity.DateTimeStarted)
            {
                return "Dto Activity End Date and Time cannot be before Start Date and Time";
            }

            if (dto.DateTimeFinished.HasValue && dto.DateTimeStarted.HasValue && dto.DateTimeStarted > dto.DateTimeFinished)
            {
                return "Activity Started Date and Time cannot be after End Date and Time";
            }

            if (!dto.DateTimeFinished.HasValue && dto.DateTimeStarted.HasValue && dto.DateTimeStarted > activity.DateTimeFinished)
            {
                return "Dto Activity Started Date and Time cannot be after End Date and Time";
            }

            return string.Empty;
        }
    }
}
