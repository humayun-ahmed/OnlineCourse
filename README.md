# OnlineCourse Api

Restore Packages and build

Api Documentaton Url: http://localhost/OnlineCourse/docs/index

Connection String Have to change for both read and write
 <add name="OnlineCourseContext" connectionString="Data Source=.;Initial Catalog=cm-online-course;Persist Security Info=True;User ID=sa;Password=sa123" providerName="System.Data.SqlClient" />
 <add name="OnlineCourseReadContext" connectionString="Data Source=.;Initial Catalog=cm-online-course;Persist Security Info=True;User ID=sa;Password=sa123" providerName="System.Data.SqlClient" />
Pagination Get have to call with following json data:
{
  "Page": 1,
  "PageSize": 10,
  "Name":"Test"
}

#Api version
For api version CourseQueryController.Get and CourseQueryController.GetWithoutName both are same action but for different version like version 2 and version 1 respectively
For this have to add header in the request "api-version" and value would be 1 or 2



#Front End Ui

1. Install Node 8.9 or higher, NPM 5.5.1 or higher, angular cli latest
2. Go to the directory and run npm install to install the related node_modules
3. run ng serve 
4. Browse the application at http://localhost:4200/



