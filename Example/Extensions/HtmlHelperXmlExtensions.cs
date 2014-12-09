using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Xsl;

namespace Example.Extensions
{
    public static class HtmlHelperXmlExtensions
    {
        /// <summary>
        /// Render Passle feed
        /// </summary>
        /// <param name="helper">Html helper class</param>
        /// <param name="shortcode">Passle shortcode</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="postsPerPage">Posts to display per page</param>
        /// <returns>Html string output</returns>
        public static HtmlString RenderFeed(this HtmlHelper helper, String shortcode, int pageNumber, int postsPerPage)
        {
            string xmlPath = String.Format("https://www.passle.net/pluginfeed/{0}/{1}/{2}",
                shortcode,
                pageNumber,
                postsPerPage
            );
            string xsltPath = "https://d14tqcyg1o920w.cloudfront.net/Wordpress/XSLT/PassleFeed.xsl";
            IDictionary<string, string> parameters = null;

            return RenderXml(helper, xmlPath, xsltPath, parameters);
        }

        /// <summary>
        /// Parse xml feed
        /// </summary>
        /// <param name="helper">Html helper class</param>
        /// <param name="xmlPath">Path to xml</param>
        /// <param name="xsltPath">Path to xslt</param>
        /// <param name="parameters">Optional paramaters</param>
        /// <returns>Html string output</returns>
        public static HtmlString RenderXml(this HtmlHelper helper, string xmlPath, string xsltPath, IDictionary<string, string> parameters)
        {
            XsltArgumentList args = new XsltArgumentList();
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    args.AddParam(key, string.Empty, parameters[key]);
                }
            }

            XslCompiledTransform t = new XslCompiledTransform();
            t.Load(xsltPath);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;

            using (XmlReader reader = XmlReader.Create(xmlPath, settings))
            {
                StringWriter writer = new StringWriter();
                t.Transform(reader, args, writer);
                return new HtmlString(writer.ToString());
            }
        }
    }
}