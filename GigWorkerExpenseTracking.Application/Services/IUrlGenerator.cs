namespace GigWorkerExpenseTracking.Application.Services
{
    public interface IUrlGenerator
    {
        string GenerateUrl(string path, object routeValues);
    }
}
