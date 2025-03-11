# FileUploadExperiment

This Visual Studio 2022, ASP.NET MVC 6.0 web app is an experiment to try out code that lets users upload files to the server. This project is set up to use SQL Server LocalDb. This code is based on the article by Storm (2024), [file-ploads on GitHub](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/models/file-uploads/samples/), which is under an [MIT open source license](https://en.wikipedia.org/wiki/MIT_License).

## Revisions
3/13/24: Changed the file upload location from /Files in the root of the server drive to wwwroot/Files in the root of the web app. 
This is not necessarily a more secure location for the files, but it is a more convenient location since it is a known location
on all servers.

## References

[How To - File Upload Button](https://www.w3schools.com/howto/howto_html_file_upload_button.asp). W3Schools.

Storm, Rutger. [Upload files in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-6.0). Microsoft, 2024. 

MDN. [Using files from web applications](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications). Mozilla Developer Network. This tutorial shows you how to do a lot of different operations with files using just HTML and JavaScript, including:

[Upload a file to a server](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications#example_uploading_a_user-selected_file) using XMLHttpRequest (AJAX).
[Create thumbnails of images](https://developer.mozilla.org/en-US/docs/Web/API/File/Using_files_from_web_applications#example_using_object_urls_to_display_images).

