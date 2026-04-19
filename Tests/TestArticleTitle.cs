using OpenQA.Selenium;
using TAF.Business.PageObject.Pages;
using TAF.Core;
using TAF.Core.WebDriver;

namespace TAF.Tests;

[TestClass]
public sealed class TestArticleTitle
{
    private BrowserType _browserType;
    
    private IWebDriver _driver;
    
    private IndexPage _indexPage;
    
    private Logger _logger;

    private string _appURL = "https://www.epam.com";
    
    private string _articleHref = "/insights/blogs/is-ai-driven-cybersecurity-" +
                                  "mesh-architecture-the-next-big-shift-in-security-operations";

    private string _articleName = 
        "Is AI-Driven Cybersecurity Mesh Architecture the Next Big Shift in Security Operations?";

    [TestInitialize]
    public void Initialize()
    {
        _browserType = (BrowserType) Enum.Parse(typeof(BrowserType), Configuration.BrowserType);
        _driver = WebDriverFactory.CreateWebDriver(_browserType);
        _indexPage = new IndexPage(_driver);
        _logger = new Logger();
    }
    
    [TestMethod]
    public void TestArticleTitles()
    {
        _logger.Information("Starting the test 'TestArticleTitles'.");
        _indexPage.Open(_appURL);
        _indexPage.AcceptAllCookies();
        _indexPage.ClickHamburgerMenuButton();
        _indexPage.ClickInsightsButton();
        var insightsPage = _indexPage.ClickAIInsightsButton();
        var articlePage = insightsPage.OpenArticle(_articleHref);
        
        _logger.Information("The article names are equal: " + 
                            articlePage.GetArticleName().Equals(_articleName));
        Assert.AreEqual(articlePage.GetArticleName(), _articleName, 
            "The article names do not coincide.");
        _logger.Information("Ending the test 'TestArticleTitles'.");
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
