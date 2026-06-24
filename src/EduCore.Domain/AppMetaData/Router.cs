namespace EduCore.Domain.AppMetaData;

public static class Router
{
    public const string SingleRoute = "/{Id}";

    public const string root = "Api";
    public const string version = "v1";
    public const string Rule = root + "/" + version;

    public static class AuthenticationRouting
    {
        public const string prefix = Rule + "/Authentication";
        public const string ConfirmEmail = prefix + "/ConfirmEmail";
        public const string SignIn = prefix + "/SignIn";
        public const string RefreshToken = prefix + "/RefreshToken";
        public const string RevokeToken = prefix + "/RevokeToken";
        public const string SendResetPassword = prefix + "/SendResetPassword";
        public const string ConfirmResetPassword = prefix + "/ConfirmResetPassword";
        public const string ResetPassword = prefix + "/ResetPassword";
        public const string SignInWithGoogleAsync = prefix + "/SignInWithGoogleAsync";
    }

    public static class ApplicationUserRouting
    {
        public const string prefix = Rule + "/User";
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
        public const string DeleteProfilePicture = prefix + "/Delete-Profile-Picture";
        public const string ChangePassword = prefix + "/ChangePassword";
        public const string Paginated = prefix + "/Paginated";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string AddInstructorRole = prefix + "/Add-Instructor-Role";
    }

    public static class AuthorizationRouting
    {
        public const string prefix = Rule + "/Authorization/Roles";
        public const string List = prefix + "/List";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
        public const string ManageUserRoles = prefix + "/ManageUserRoles/{userId}";
        public const string UpdateUserRoles = prefix + "/UpdateUserRoles";
    }
    public static class CategoryRouting
    {
        public const string prefix = Rule + "/Category";
        public const string List = prefix + "/List";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
    }

    public static class CourseRouting
    {
        public const string prefix = Rule + "/Course";
        public const string Paginated = prefix + "/Paginated";
        public const string ByCategoryIdPaginated = prefix + "/By-Category-Id-Paginated";
        public const string ByInstructorIdPaginated = prefix + "/By-Instructor-Id-Paginated";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
    }
    public static class SectionRouting
    {
        public const string prefix = Rule + "/Section";
        public const string Paginated = prefix + "/Paginated";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
    }
    public static class ContentRouting
    {
        public const string prefix = Rule + "/Content";
        public const string List = prefix + "/List";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
    }
    public static class CartRouting
    {
        public const string prefix = Rule + "/Cart";
        public const string Add = prefix + "/Items/Add" + "/{CourseId}";
        public const string Delete = prefix + "/Items/Delete" + "/{CourseId}";
        public const string Clear = prefix + "/Clear";
        public const string List = prefix + "/List";
    }

    public static class OrderRouting
    {
        public const string prefix = Rule + "/Order";
        public const string Paginated = prefix + "/Paginated";
        public const string ByCustomerId = prefix + "/ByCustomerId";
        public const string GetById = prefix + "/GetById" + SingleRoute;
        public const string Create = prefix + "/Create/{CartId}";
    }

    public static class EnrollmentRouting
    {
        public const string prefix = Rule + "/Enrollment";
        public const string Paginated = prefix + "/Paginated";
    }

    public static class CourseProgressRouting
    {
        public const string prefix = Rule + "/Progress";
        public const string ChangeContentStatus = prefix + "/Change-Content-Status";
        public const string GetCourseProgress = prefix + "/Get-Course-Progress/{CourseId}";
    }

    public static class CourseCertificateRouting
    {
        public const string prefix = Rule + "/Certificate";
        public const string GetCourseCertificate = prefix + "/{CourseId}";
    }

    public static class FeedbackRouting
    {
        public const string prefix = Rule + "/Feedback";
        public const string Paginated = prefix + "/Paginated";
        public const string Create = prefix + "/Create";
        public const string Edit = prefix + "/Edit";
        public const string Delete = prefix + "/Delete" + SingleRoute;
    }

    public static class PaymentRouting
    {
        public const string prefix = Rule + "/Payment";
        public const string CreatePaymentIntent = Rule + "/CreatePaymentIntent/{CartId}";
    }
    }
