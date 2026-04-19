using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TAF.Business.PageObject.Pages;

public class InsightsPage: BasePage
{
    private readonly double _waitTimeSpanSeconds = 5;
    
    private readonly double _pollingInterval = 0.25;
    
    private readonly string _articleNotFoundMessage = "Article has not been found";
    
    public InsightsPage(IWebDriver driver) : base(driver) { }
    
    public ArticlePage OpenArticle(string articleHref)
    {
        var articleWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_waitTimeSpanSeconds))
        {
            PollingInterval = TimeSpan.FromSeconds(_pollingInterval),
            Message = _articleNotFoundMessage
        };
        
        var article = articleWait
            .Until(driver => driver.FindElement(By.XPath("//a[@href='" + articleHref + "']")));
        new Actions(Driver).ScrollToElement(article);
        article.Click();
        
        return new ArticlePage(Driver);
    }
}
