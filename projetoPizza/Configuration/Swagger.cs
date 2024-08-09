namespace projetoPizza.Configuration;
internal static class Swagger
{
    internal static void ConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                var descriptions = app.DescribeApiVersions();

                // build a swagger endpoint for each discovered API version
                foreach (var description in descriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    options.SwaggerEndpoint(url, name);
                    options.RoutePrefix = "";
                }
            });
    }
}