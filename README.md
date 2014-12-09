Passle ASP.Net MVC 4 feed example
==================

This solution is an example of how the Passle XML feed can be used in a 
ASP.NET MVC 4 application. It was implemented in ASP.NET MVC 4, and created in 
Visual Studio 2012. To see the example feed, simply run the solution.

The files which will be of most interest are: 

 `HtmlHelperXmlExtensions.cs` 
 
This is a `HtmlHelper` extension which has one static method `RenderFeed`. This 
method takes the Passle `shortcode`, page number and number of posts per page. It then collects the data using that information and transforms 
the `xml` using the `xslt` to generate the markup, which is returned as an 
`HtmlString`.

`ShowFeed.cshtml`

This is a Razor view which uses the `HtmlHelper` extension to render the feed.

-----------------------------------------------------------------------

Please note: 

  1. You'll need to replace the shortcode in the view with the shortcode of the Passle you are trying to display
> You can get this from the settings page of your Passle.
  2. The feed depends on JQuery >= v1.8.3 (It may work with some earlier versions of JQuery)
  3. The container `div` for the feed must have a class of `passle-shortcode`

-----------------------------------------------------------------------

© Passle Ltd, 2014