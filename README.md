# swagger-codegen-angular-aspnetcore
This repo contains the example, it shows how you can use the swagger codegen in your application. 


Install Swagger

	Goto startup.cs 
	
	In ConfigureServices method paste the following and change the name
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("DemoAPI", new Swashbuckle.AspNetCore.Swagger.Info()
		{
			Title = "Demo API",
			Description = "Purely designed for demonstration",
			Version = "v1"
		});
	});
	
	In Configure method paste the following
	 
	// Enable middleware to serve generated Swagger as a JSON endpoint.
	app.UseSwagger();
	
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/DemoAPI/swagger.json", "Demo API");
		c.RoutePrefix = string.Empty;
	});
			
Enable Cors

	Goto Startup.cs
	
	Declare the following on top 	
	readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
	
	In ConfigureServices method paste the following and change the name
	services.AddCors(options =>
	{
		options.AddPolicy(MyAllowSpecificOrigins,
		builder =>
		{
			builder.WithOrigins("http://example.com");
		});
	});
	
	In Configure method paste the following
	app.UseCors(MyAllowSpecificOrigins);
	

This code is copied from microsoft's documentation.