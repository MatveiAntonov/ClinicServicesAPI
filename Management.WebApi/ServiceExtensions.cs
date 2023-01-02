namespace Management.WebApi
{
	public static class ServiceExtensions
	{
		public static void ConfigureAuthenticationHandler(this IServiceCollection services)
			=> services.AddAuthentication("Bearer")
			.AddJwtBearer("Bearer", options =>
			{
				options.Authority = "https://localhost:5005";
				options.Audience = "serviceapi";
			});
	}
}
