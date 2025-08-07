using LearningService.Services;

namespace LearningApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<ISeminarVideoService, SeminarVideoService>();
        services.AddScoped<IShortVideoService, ShortVideoService>();
        services.AddScoped<IVideoOfCourseService, VideoOfCourseService>();
        return services;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}