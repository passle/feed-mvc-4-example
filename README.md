Passle ASP.Net MVC C# feed example
==================

This solution is an example of how the Passle XML feed can be used in a 
ASP.NET MVC application when using C#. It was implemented 
in ASP.NET, and created in Visual Studio 2012. To see the example 
feed, simply run the solution.

These are the steps for embedding your Passle blog into your website. The 
following steps assume that your site was built using Visual Studio and MVC.
Your website will also need to have JQuery included (version 1.8.3 or higher).

1.  Please open the example solution using Visual Studio (VS).

2.  Copy the following file (from the example solution) into your VS solution:
    `/Example/Extensions/HtmlHelperXmlExtensions.cs`

3.  In your VS solution, open the html file (the View) that you wish to embed the blog into (this may be an `.aspx` or `.cshtml` file).

4.  In this View, include a `using` or `import` statement which specifies the location (namespace) where you have copied the `HtmlHelperXmlExtensions.cs` file to (in your VS solution). For example, in a Razor View: 
    
        @using PassleFeed_ASPNET_MVC_Example.Extensions

    In an ASPX view:

        <%@ Import namespace="PassleFeed_ASPNET_MVC_Example.Extensionse" %>

    This means that the `HtmlHelperXmlExtensions.cs` file will be included in this View.

5.  Include the following CSS files in the <head> tag for your html document (View):
        
        <link id="dynamic-css-link" href="https://www.passle.net/Style/PublishedPassleCSS?passleId=@passleFeedShortCode" rel="stylesheet" >
        <link href="https://d14tqcyg1o920w.cloudfront.net/Wordpress/css/WordPressPlugin.css" rel="stylesheet" >
        <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Goudy+Bookletter+1911|Open+Sans:300,400,600,700|Sansita+One:400,600,700|Satisfy:400,600,700">

6.  Include the following JavaScript file in the <head> tag for your html document (View):

        <script type="text/javascript" src="https://d14tqcyg1o920w.cloudfront.net/Wordpress/js/wordpressplugin.js"></script>

7.  You will need to add some ASP.NET code to your View (html document) to initialise some variables.
Assuming the you are using the Razor view engine, this code may look like this:

        @{
            var passleFeedShortCode = "2cxn";
            var passleFeedNumberOfPostsToDisplayPerPage = 15;
            var passleFeedPageToDisplay = 1;
        }

 - `passleFeedShortCode` is the unique identifier for your blog. You can get this from the settings page of your Passle.
 - `passleFeedNumberOfPosts`ToDisplayPerPage specifies how many posts to display.
 - `passleFeedPageToDisplay` specifies which batch of posts to show (for example, if you decide to show 15 posts per page, setting this to 1 will show the first 15, setting it to 2 will show the second 15, and so on).

8.  Finally, add the following code to your html document (the View) where you want the blog to appear.

        <div class="passle-shortcode">
            @Html.RenderFeed(
                passleFeedShortCode, 
                passleFeedPageToDisplay, 
                passleFeedNumberOfPostsToDisplayPerPage
            )
        </div>

Build and run your solution.

-----------------------------------------------------------------------

Please note: 

  1. You'll need to replace the shortcode in the view with the shortcode of the Passle you are trying to display
> You can get this from the settings page of your Passle.
  2. The feed depends on JQuery >= v1.8.3 
  3. The container `div` for the feed must have a class of `passle-shortcode`

-----------------------------------------------------------------------

© Passle Ltd, 2014