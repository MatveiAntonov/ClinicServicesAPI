namespace Management.WebApi
{
	public static class ServiceExtensions
	{
		public static void ConfigureAuthenticationHandler(this IServiceCollection services)
			=> services.AddAuthentication("Bearer")
			.AddJwtBearer("Bearer", options =>
			{
				//options.Authority = "http://localhost:6006";
				options.Authority = "http://authorization-server:6006";
				options.Audience = "serviceapi";
				options.RequireHttpsMetadata= false;
			});
	}
}
