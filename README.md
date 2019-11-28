# swagger-codegen-angular-aspnetcore
This repo contains the example, it shows how you can use the swagger codegen in your application. 


Install Swagger

	Install the following nuget packages in your solution
		Swashbuckle.AspNetCore.SwaggerGen 4.0.1
		Swashbuckle.AspNetCore.SwaggerUi  4.0.1
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


Swagger codegen

The Jar File
	To generate the client you need swagger codegen Jar file. There are couple of ways get the Jar files
	* Clone the swaggercode gen file from github and run the below command 
		mvn clean package
	* Download the file on from mvn reporsitory below is the line for that 
		https://mvnrepository.com/artifact/io.swagger/swagger-codegen-cli/2.4.10

	I have already downloaded the file and added in Helper folder in repo.

Generate the Angular Client
	To generate the client you need 
	* Swagger spec file: We have it as we have installed swagger in our app. You can get the link from the Landing page of your wep api. Or you can directly navigate to http://localhost:<port-on-which-you-api-running>/swagger/DemoAPI/swagger.json
	* Jar file: We have it in Helper folder.
	* Command to generate the client: Can be found in Helper/command-to-generate-angular-client.txt file with explanation.

	After running the command, in output folder you will see the complete angular application structure and apis and model will be generated. Now you need to compile this code and use because if you try to use this as it is. Your application will start compile this code and I don't recommend this approach. 

	The recommended approach is 
	* Compile the code and create a package
	* Publish the package in registry.
	* Install the package as part of you other Helper by mentioning it in the package.json file.

	Complie the package
	* Navigate to rool of generated client and make sure you have package.json file in your root folder. It must have been generated as part of client generation.
  * Run npm install
	
	After running npm install you have multiple option here. 
	* Run npm run build: it will create a package as it does for any angular application.
	* Run "./node_modules/.bin/tsc" including quotes this will actually compile the typescript file and create a dist folder with all the definition which will be ready to use in your application. 

	I recommend the second approach the reason is as part of generated client you don't have any component and html its just some typescript file so compiling it as a angular package will increase the size of compiled package so better just compile it using typescript compiler the end package will be smaller.

	Publish to registry
	Publishing the package can be found on internet. Assuming you have .npmrc file to publish the package you need a package.json file so that you can specify the version. I have added sample package.json in Helper folder. Just add this file in dist folder and run npm publish. 

	Install the package in your angular application.
	* Make an entry of the package in the package.json file ex. "sample-webapi": "1.0.0"
	* Run npm install

Start using the client in your application	
	Open app.module.ts file in your angular application.
	* Import the following
		import { HttpClientModule } from '@angular/common/http';
		import { ApiModule, BASE_PATH } from 'sample-webapi';
	* Add HttpClientModule, ApiModule, in import section	
	* Add following in the provider, you need to change url of your api application.
		{ provide: BASE_PATH, useValue: 'http://localhost:65099' }
	
	Finally your app module should like 
		import { BrowserModule } from '@angular/platform-browser';
		import { NgModule } from '@angular/core';
		import { HttpClientModule } from '@angular/common/http';
		import { ApiModule, BASE_PATH } from 'sample-webapi';

		import { AppRoutingModule } from './app-routing.module';
		import { AppComponent } from './app.component';

		@NgModule({
			declarations: [
				AppComponent,
			],
			imports: [
				BrowserModule,
				AppRoutingModule,
				HttpClientModule,
				ApiModule,
			],
			providers: [{ provide: BASE_PATH, useValue: 'http://localhost:65099' }],
			bootstrap: [AppComponent]
		})
		export class AppModule { }

	Now you are good to use the User API in your agnular application. Below is one example 
		import { Component, OnInit } from '@angular/core';
		import { UserService } from 'sample-webapi';

		@Component({
			selector: 'app-root',
			templateUrl: './app.component.html',
			styleUrls: ['./app.component.css']
		})
		export class AppComponent implements OnInit {
			title = 'SampleClientApp';

			constructor(private userService: UserService) {
			}

			ngOnInit(): void {
				this.userService.getUsers().subscribe(elem => {
					console.log(elem);
				});
			}
		}
